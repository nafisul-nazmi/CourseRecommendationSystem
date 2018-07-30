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
    public class ExamScheduleController : Controller
    {
        private IExamScheduleService examScheduleService;
        private ICourseService courseService;

        public ExamScheduleController(IExamScheduleService examScheduleService, ICourseService courseService)
        {
            this.examScheduleService = examScheduleService;
            this.courseService = courseService;
        }

        // GET: ExamSchedule
        public ActionResult Index()
        {
            IEnumerable<ExamSchedule> examSchedules = examScheduleService.GetAll();
            return View(examSchedules);
        }

        // GET: ExamSchedule/Details/5
        public ActionResult Details(int id)
        {
            ExamSchedule examSchedule = examScheduleService.Get(id);
            return View(examSchedule);
        }

        // GET: ExamSchedule/Create
        public ActionResult Create()
        {
            ExamScheduleViewModel examScheduleViewModel = new ExamScheduleViewModel
            {
                ExamSchedule = new ExamSchedule(),
                Courses = courseService.GetAll()
            };
            return View(examScheduleViewModel);
        }

        // POST: ExamSchedule/Create
        [HttpPost]
        public ActionResult Create(ExamScheduleViewModel examScheduleViewModel)
        {
            ExamSchedule examSchedule = examScheduleViewModel.ExamSchedule;
            try
            {
                examScheduleService.Add(examSchedule);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamSchedule/Edit/5
        public ActionResult Edit(int id)
        {
            ExamSchedule examSchedule = examScheduleService.Get(id);
            ExamScheduleViewModel examScheduleViewModel = new ExamScheduleViewModel
            {
                ExamSchedule = examSchedule,
                Courses = courseService.GetAll()
            };
            return View(examScheduleViewModel);
        }

        // POST: ExamSchedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExamScheduleViewModel examScheduleViewModel)
        {
            ExamSchedule examSchedule = examScheduleViewModel.ExamSchedule;
            try
            {
                examScheduleService.Edit(examSchedule);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(examScheduleViewModel);
            }
        }

        // GET: ExamSchedule/Delete/5
        public ActionResult Delete(int id)
        {
            ExamSchedule examSchedule = examScheduleService.Get(id);
            return View(examSchedule);
        }

        // POST: ExamSchedule/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamSchedule examSchedule = examScheduleService.Get(id);
            try
            {
                examScheduleService.Delete(examSchedule);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(examSchedule);
            }
        }
    }
}
