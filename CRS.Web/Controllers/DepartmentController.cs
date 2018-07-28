using CRS.BLL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<Department> departments = departmentService.GetAll();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            Department department = departmentService.Get(id);
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            Department department = new Department();
            return View(department);
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                departmentService.Add(department);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(department);
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            Department department = departmentService.Get(id);
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                departmentService.Edit(department);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(department);
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            Department department = departmentService.Get(id);
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = departmentService.Get(id);
            try
            {
                departmentService.Delete(department);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(department);
            }
        }
    }
}