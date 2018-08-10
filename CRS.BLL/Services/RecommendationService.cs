using CRS.BLL.Interfaces;
using CRS.BLL.Utilities;
using CRS.Entity.Models;
using CRS.Entity.SupportModels;
using SharpLearning.InputOutput.Csv;
using SharpLearning.RandomForest.Learners;
using SharpLearning.RandomForest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        private const string machineLearningModelsRelativePath = @"CRS.BLL\MachineLearningModelFiles\";
        private string machineLearningModelsAbsolutePath = ConfigurationManager.AppSettings["appRootPath"] + machineLearningModelsRelativePath;

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
            List<WarehousePredict> warehouses = CreateWarehouse(courseCombinations, studentId);
            var result = GetPrediction(warehouses);
            int maxIndex = 0;
            double maxValue = 0;
            for(int i = 0; i < result.Length; i++)
            {
                if(result[i] > maxValue)
                {
                    maxValue = result[i];
                    maxIndex = i;
                }
            }
            return courseCombinations[maxIndex];
        }

        private List<WarehousePredict> CreateWarehouse(List<List<Course>> courseCombinations, int studentId)
        {
            List<WarehousePredict> warehouses = new List<WarehousePredict>();
            double previousCGPA = studentService.Get(studentId).CGPA;
            foreach(var courseCombination in courseCombinations)
            {
                WarehousePredict warehouse = new WarehousePredict
                {
                    PerviousCGPA = previousCGPA
                };
                foreach(var course in courseCombination)
                {
                    warehouse.GetType().GetProperty(course.CourseName).SetValue(warehouse, 1, null);
                }
                warehouses.Add(warehouse);
            }
            return warehouses;
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

        private double[] GetPrediction(List<WarehousePredict> warehouses)
        {
            string modelFile = machineLearningModelsAbsolutePath + "random_forest_model.xml";
            if(!File.Exists(modelFile))
            {
                Train();
            }
            
            var loadedModel = RegressionForestModel.Load(() => new StreamReader(machineLearningModelsAbsolutePath + "random_forest_model.xml"));
            List<double> results = new List<double>();
            foreach(var warehouse in warehouses)
            {
                List<double> observation = new List<double>();
                var properties = warehouse.GetType().GetProperties();
                foreach(var property in properties)
                {
                    observation.Add(Convert.ToDouble(property.GetValue(warehouse, null)));
                }
                results.Add(loadedModel.Predict(observation.ToArray()));
            }
            return results.ToArray();
        }

        private void Train()
        {
            var parser = new CsvParser(() => new StreamReader(machineLearningModelsAbsolutePath + "warehouse_data.csv"), separator: ',');
            var targetName = "NextCGPA";
            var targets = parser.EnumerateRows(targetName).ToF64Vector();
            var observations = parser.EnumerateRows(x => x != targetName).ToF64Matrix();
            var learner = new RegressionRandomForestLearner(trees: numberOfTrees);
            var model = learner.Learn(observations, targets);
            model.Save(() => new StreamWriter(machineLearningModelsAbsolutePath + "random_forest_model.xml"));
        }

    }
}
