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
    public class CourseController : Controller
    {
        private ICourseService courseService;
        private IDepartmentService departmentService;

        public CourseController(ICourseService courseService, IDepartmentService departmentService)
        {
            this.courseService = courseService;
            this.departmentService = departmentService;
        }

        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> courses = courseService.GetAll();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = courseService.Get(id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = new Course(),
                Departments = departmentService.GetAll()
            };
            return View(courseViewModel);
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            Course course = courseViewModel.Course;
            try
            {
                courseService.Add(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(course);
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = courseService.Get(id);
            CourseViewModel courseViewModel = new CourseViewModel
            {
                Course = course,
                Departments = departmentService.GetAll()
            };
            return View(courseViewModel);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel courseViewModel)
        {
            Course course = courseViewModel.Course;
            try
            {
                courseService.Edit(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(course);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Course course = courseService.Get(id);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = courseService.Get(id);
            try
            {
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
