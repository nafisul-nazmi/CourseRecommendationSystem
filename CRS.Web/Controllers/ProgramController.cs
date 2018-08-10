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
    public class ProgramController : AdminSecuredController
    {
        private IProgramService programService;
        private IDepartmentService departmentService;
        private ICourseService courseService;
        private IProgramCourseAssociationService programCourseAssociationService;

        public ProgramController(IProgramService programService, IDepartmentService departmentService, ICourseService courseService, IProgramCourseAssociationService programCourseAssociationService)
        {
            this.programService = programService;
            this.departmentService = departmentService;
            this.courseService = courseService;
            this.programCourseAssociationService = programCourseAssociationService;
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
                Departments = departmentService.GetAll(),
                Courses = courseService.GetAll()
            };
            return View(programViewModel);
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramViewModel programViewModel)
        {
            Program program = programViewModel.Program;
            IEnumerable<int> courseIds = programViewModel.CourseIds;
            try
            {
                program = programService.Add(program);
                if(courseIds != null)
                {
                    foreach (int courseId in courseIds)
                    {
                        ProgramCourseAssociation programCourseAssociation = new ProgramCourseAssociation
                        {
                            ProgramId = program.Id,
                            CourseId = courseId
                        };
                        programCourseAssociationService.Add(programCourseAssociation);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(programViewModel);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            Program program = programService.Get(id);
            ProgramViewModel programViewModel = new ProgramViewModel
            {
                Program = program,
                Departments = departmentService.GetAll(),
                Courses = courseService.GetAll()
            };
            return View(programViewModel);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramViewModel programViewModel)
        {
            Program program = programViewModel.Program;
            IEnumerable<int> courseIds = programViewModel.CourseIds;
            try
            {
                programCourseAssociationService.DeleteAssociationByProgram(program.Id);
                programService.Edit(program);
                if(courseIds != null)
                {
                    foreach (int courseId in courseIds)
                    {
                        ProgramCourseAssociation programCourseAssociation = new ProgramCourseAssociation
                        {
                            ProgramId = program.Id,
                            CourseId = courseId
                        };
                        programCourseAssociationService.Add(programCourseAssociation);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(programViewModel);
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
                programCourseAssociationService.DeleteAssociationByProgram(program.Id);
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