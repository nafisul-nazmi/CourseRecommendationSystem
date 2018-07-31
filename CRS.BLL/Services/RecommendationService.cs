using CRS.BLL.Interfaces;
using CRS.BLL.Utilities;
using CRS.Entity.Models;
using SharpLearning.RandomForest.Learners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.BLL.Services
{
    public class RecommendationService : IRecommendationService
    {
        private IWarehouseService warehouseService;
        private ICourseService courseService;
        private IStudentService studentService;
        private IStudentCourseAssociationService studentCourseAssociationService;
        private IProgramCourseAssociationService programCourseAssociationService;
        private IExamScheduleService examScheduleService;
        private IPrerequisiteService prerequisiteService;
        private int retakeAbleMark;
        private int numberOfTrees;

        public RecommendationService(IWarehouseService warehouseService, ICourseService courseService, IStudentService studentService, IStudentCourseAssociationService studentCourseAssociationService, IProgramCourseAssociationService programCourseAssociationService, IExamScheduleService examScheduleService, IPrerequisiteService prerequisiteService)
        {
            this.warehouseService = warehouseService;
            this.courseService = courseService;
            this.studentService = studentService;
            this.studentCourseAssociationService = studentCourseAssociationService;
            this.programCourseAssociationService = programCourseAssociationService;
            this.examScheduleService = examScheduleService;
            this.prerequisiteService = prerequisiteService;
            retakeAbleMark = 73;
            numberOfTrees = 10;
        }

        public List<Course> GetRecommendation(int studentId, FilterModel filterModel)
        {
            var availableCourses = GetUnlockedCourses(studentId).ToList();
            if(!filterModel.AvoidRetakeable)
            {
                availableCourses = availableCourses.Union(GetRetakeAbleCourses(studentId)).ToList();
            }
            var courseCombinations = CombinationGenerator.GetAllCombinations<Course>(availableCourses);
            courseCombinations = GetValidCreditCourseCombinations(courseCombinations, filterModel.NumberOfCredits);
            if(filterModel.AvoidClashExams)
            {
                courseCombinations = GetNoClashExamsCombinations(courseCombinations);
            }
            if(filterModel.AvoidTwoExamsInADay)
            {
                courseCombinations = GetNoMultipleExamsInADayCombinations(courseCombinations, 2);
            }
            if (filterModel.AvoidThreeExamsInADay)
            {
                courseCombinations = GetNoMultipleExamsInADayCombinations(courseCombinations, 3);
            }
            //return courseCombinations;
            return null;
        }

        private List<List<Course>> GetValidCreditCourseCombinations(List<List<Course>> courseCombinations, double numberOfCredits)
        {
            List<List<Course>> filteredCourses = new List<List<Course>>();
            foreach(var courseCombination in courseCombinations)
            {
                if(IsNumberOfCreditsValid(courseCombination, numberOfCredits))
                {
                    filteredCourses.Add(courseCombination);
                }
            }
            return filteredCourses;
        }

        private List<List<Course>> GetNoClashExamsCombinations(List<List<Course>> courseCombinations)
        {
            List<List<Course>> filteredCourses = new List<List<Course>>();
            foreach (var courseCombination in courseCombinations)
            {
                if (!IsClashExamPresent(courseCombination))
                {
                    filteredCourses.Add(courseCombination);
                }
            }
            return filteredCourses;
        }

        private List<List<Course>> GetNoMultipleExamsInADayCombinations(List<List<Course>> courseCombinations, int numberOfExams = 2)
        {
            List<List<Course>> filteredCourses = new List<List<Course>>();
            foreach (var courseCombination in courseCombinations)
            {
                if (!IsMultipleExamPresent(courseCombination, numberOfExams))
                {
                    filteredCourses.Add(courseCombination);
                }
            }
            return filteredCourses;
        }

        private IEnumerable<Course> GetUnlockedCourses(int studentId)
        {
            var completedCourses = studentCourseAssociationService.FindBy(x => x.StudentId == studentId).Select(x => x.Course).ToList();
            var studentProgram = studentService.Get(studentId).Program;
            var studentAllowedCourses = programCourseAssociationService.FindBy(x => x.ProgramId == studentProgram.Id).Select(x => x.Course).ToList();
            var studentNewAllowedCourses = studentAllowedCourses.Where(x => !completedCourses.Select(y => y.Id).ToList().Contains(x.Id));
            List<Course> unlockedCourses = new List<Course>();
            foreach(var course in studentNewAllowedCourses)
            {
                var prerequisites = prerequisiteService.FindBy(x => x.CourseId == course.Id).ToList();
                if(prerequisites == null || prerequisites.Count() == 0)
                {
                    unlockedCourses.Add(course);
                }
                else
                {
                    int prerequisiteCount = prerequisites.Count();
                    int counter = 0;
                    foreach(var prerequisite in prerequisites)
                    {
                        if(completedCourses.Select(x => x.Id).ToList().Contains(prerequisite.CoursePrerequisiteId.Value))
                        {
                            counter++;
                        }
                    }
                    if(counter == prerequisiteCount)
                    {
                        unlockedCourses.Add(course);
                    }
                }
            }
            return unlockedCourses;
        }

        private IEnumerable<Course> GetRetakeAbleCourses(int studentId)
        {
            return studentCourseAssociationService.FindBy(x => x.StudentId == studentId && x.Marks <= retakeAbleMark).Select(x => x.Course).ToList();
        }

        private bool IsClashExamPresent(IEnumerable<Course> courses)
        {
            int[,] slot = new int[6, 3];
            foreach(var course in courses)
            {
                ExamSchedule examSchedule = examScheduleService.FindBy(x => x.CourseId == course.Id).SingleOrDefault();
                if(examSchedule != null)
                {
                    slot[examSchedule.Day - 1, examSchedule.Slot - 1]++;
                }  
            }
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(slot[i, j] > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsMultipleExamPresent(IEnumerable<Course> courses, int numberOfExams = 2)
        {
            int[] days = new int[6];
            foreach (var course in courses)
            {
                ExamSchedule examSchedule = examScheduleService.FindBy(x => x.CourseId == course.Id).SingleOrDefault();
                if (examSchedule != null)
                {
                    days[examSchedule.Day - 1]++;
                }
            }
            for(int i = 0; i < 6; i++)
            {
                if(days[i] >= numberOfExams)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumberOfCreditsValid(IEnumerable<Course> courses, double numberOfCredits)
        {
            double totalCredits = courses.Select(x => x.CourseCredits).Sum();
            if(totalCredits == numberOfCredits)
            {
                return true;
            }
            return false;
        }

    }
}
