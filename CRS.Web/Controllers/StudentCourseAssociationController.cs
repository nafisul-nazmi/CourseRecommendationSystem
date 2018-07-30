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
    public class StudentCourseAssociationController : Controller
    {
        private IStudentService studentService;
        private ICourseService courseService;
        private IStudentCourseAssociationService studentCourseAssociationService;

        public StudentCourseAssociationController(IStudentService studentService, ICourseService courseService, IStudentCourseAssociationService studentCourseAssociationService)
        {
            this.studentService = studentService;
            this.courseService = courseService;
            this.studentCourseAssociationService = studentCourseAssociationService;
        }

        // GET: StudentCourseAssociation
        public ActionResult Index()
        {
            IEnumerable<StudentCourseAssociation> studentCourseAssociations = studentCourseAssociationService.GetAll();
            return View(studentCourseAssociations);
        }

        // GET: StudentCourseAssociation/Details/5
        public ActionResult Details(int id)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationService.Get(id);
            return View(studentCourseAssociation);
        }

        // GET: StudentCourseAssociation/Create
        public ActionResult Create()
        {
            StudentCourseAssociationViewModel studentCourseAssociationViewModel = new StudentCourseAssociationViewModel
            {
                StudentCourseAssociation = new StudentCourseAssociation(),
                Students = studentService.GetAll(),
                Courses = courseService.GetAll()
            };
            return View(studentCourseAssociationViewModel);
        }

        // POST: StudentCourseAssociation/Create
        [HttpPost]
        public ActionResult Create(StudentCourseAssociationViewModel studentCourseAssociationViewModel)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationViewModel.StudentCourseAssociation;
            try
            {
                studentCourseAssociationService.Add(studentCourseAssociation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(studentCourseAssociationViewModel);
            }
        }

        // GET: StudentCourseAssociation/Edit/5
        public ActionResult Edit(int id)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationService.Get(id);
            StudentCourseAssociationViewModel studentCourseAssociationViewModel = new StudentCourseAssociationViewModel
            {
                StudentCourseAssociation = studentCourseAssociation,
                Students = studentService.GetAll(),
                Courses = courseService.GetAll()
            };
            return View(studentCourseAssociationViewModel);
        }

        // POST: StudentCourseAssociation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentCourseAssociationViewModel studentCourseAssociationViewModel)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationViewModel.StudentCourseAssociation;
            try
            {
                studentCourseAssociationService.Edit(studentCourseAssociation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(studentCourseAssociationViewModel);
            }
        }

        // GET: StudentCourseAssociation/Delete/5
        public ActionResult Delete(int id)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationService.Get(id);
            return View(studentCourseAssociation);
        }

        // POST: StudentCourseAssociation/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourseAssociation studentCourseAssociation = studentCourseAssociationService.Get(id);
            try
            {
                studentCourseAssociationService.Delete(studentCourseAssociation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(studentCourseAssociation);
            }
        }
    }
}
