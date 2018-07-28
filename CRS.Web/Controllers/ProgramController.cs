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
    public class ProgramController : Controller
    {
        private IProgramService programService;
        private IDepartmentService departmentService;

        public ProgramController(IProgramService programService, IDepartmentService departmentService)
        {
            this.programService = programService;
            this.departmentService = departmentService;
        }

        // GET: Program
        public ActionResult Index()
        {
            IEnumerable<Program> programs = programService.GetAll();
            return View(programs);
        }

        // GET: Program/Details/5
        public ActionResult Details(int id)
        {
            Program program = programService.Get(id);
            return View(program);
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            ProgramViewModel programViewModel = new ProgramViewModel
            {
                Program = new Program(),
                Departments = departmentService.GetAll()
            };
            return View(programViewModel);
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramViewModel programViewModel)
        {
            Program program = programViewModel.Program;
            try
            {
                programService.Add(program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(program);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            Program program = programService.Get(id);
            ProgramViewModel programViewModel = new ProgramViewModel
            {
                Program = program,
                Departments = departmentService.GetAll()
            };
            return View(programViewModel);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramViewModel programViewModel)
        {
            Program program = programViewModel.Program;
            try
            {
                programService.Edit(program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(program);
            }
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int id)
        {
            Program program = programService.Get(id);
            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = programService.Get(id);
            try
            {
                programService.Delete(program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(program);
            }
        }
    }
}