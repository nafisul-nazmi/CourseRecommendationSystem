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
    public class StudentController : Controller
    {
        private IStudentService studentService;
        private IProgramService programService;

        public StudentController(IStudentService studentService, IProgramService programService)
        {
            this.studentService = studentService;
            this.programService = programService;
        }

        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> students = studentService.GetAll();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = studentService.Get(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel
            {
                Student = new Student(),
                Programs = programService.GetAll()
            };
            return View(studentViewModel);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            Student student = studentViewModel.Student;
            try
            {
                studentService.Add(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(studentViewModel);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = studentService.Get(id);
            StudentViewModel studentViewModel = new StudentViewModel
            {
                Student = student,
                Programs = programService.GetAll()
            };
            return View(studentViewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModel studentViewModel)
        {
            Student student = studentViewModel.Student;
            try
            {
                studentService.Edit(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(studentViewModel);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentService.Get(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentService.Get(id);
            try
            {
                studentService.Delete(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(student);
            }
        }
    }
}
