using CRS.BLL.Interfaces;
using CRS.Entity.Models;
using CRS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class CourseController : AdminSecuredController
    {
        private ICourseService courseService;
        private IPrerequisiteService prerequisiteService;
        private IDepartmentService departmentService;

        public CourseController(ICourseService courseService, IPrerequisiteService prerequisiteService, IDepartmentService departmentService)
        {
            this.courseService = courseService;
            this.prerequisiteService = prerequisiteService;
            this.departmentService = departmentService;
        }

        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> courses = courseService.GetAll().ToList();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = courseService.Get(id);
            IEnumerable<Prerequisite> prerequisites = prerequisiteService.GetAll().ToList();
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = course,
                Prerequisites = prerequisites.Where(x => x.CourseId == course.Id).Select(x => x.CoursePrerequisite).ToList()
            };
            return View(courseViewModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = new Course(),
                Departments = departmentService.GetAll(),
                AllCourses = courseService.GetAll()
            };
            return View(courseViewModel);
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            Course course = courseViewModel.Course;
            IEnumerable<int> prerequisites = courseViewModel.PrerequisiteIds;
            try
            {
                course = courseService.Add(course);
                if(prerequisites != null)
                {
                    foreach (int prerequisiteId in prerequisites)
                    {
                        Prerequisite prerequisite = new Prerequisite
                        {
                            CourseId = course.Id,
                            CoursePrerequisiteId = prerequisiteId
                        };
                        prerequisiteService.Add(prerequisite);
                    }
                } 
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(courseViewModel);
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = courseService.Get(id);
            IEnumerable<Prerequisite> prerequisites = prerequisiteService.GetAll().ToList();
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = course,
                Departments = departmentService.GetAll(),
                AllCourses = courseService.GetAll(),
                PrerequisiteIds = prerequisites.Where(x => x.CourseId == course.Id).Select(x => x.CoursePrerequisiteId.Value).ToList()
            };
            return View(courseViewModel);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel courseViewModel)
        {
            Course course = courseViewModel.Course;
            IEnumerable<int> prerequisites = courseViewModel.PrerequisiteIds;
            try
            {
                prerequisiteService.DeletePrequisiteByCourse(course.Id);
                courseService.Edit(course);
                if(prerequisites != null)
                {
                    foreach (int prerequisiteId in prerequisites)
                    {
                        Prerequisite prerequisite = new Prerequisite
                        {
                            CourseId = course.Id,
                            CoursePrerequisiteId = prerequisiteId
                        };
                        prerequisiteService.Add(prerequisite);
                    }
                }  
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(courseViewModel);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Course course = courseService.Get(id);
            IEnumerable<Prerequisite> prerequisites = prerequisiteService.GetAll().ToList();
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = course,
                Prerequisites = prerequisites.Where(x => x.CourseId == course.Id).Select(x => x.CoursePrerequisite).ToList()
            };
            return View(courseViewModel);
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = courseService.Get(id);
            try
            {
                prerequisiteService.DeleteAllByCourse(course.Id);
                courseService.Delete(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(course);
            }
        }
    }
}
