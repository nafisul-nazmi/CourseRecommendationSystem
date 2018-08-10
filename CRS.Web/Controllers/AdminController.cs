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
    public class AdminController : AdminSecuredController
    {
        private IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable<Admin> admins = adminService.GetAll();
            return View(admins);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            Admin admin = adminService.Get(id);
            return View(admin);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Admin admin = new Admin();
            return View(admin);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            try
            {
                adminService.Add(admin);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(admin);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Admin admin = adminService.Get(id);
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Admin admin)
        {
            try
            {
                adminService.Edit(admin);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(admin);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Admin admin = adminService.Get(id);
            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = adminService.Get(id);
            try
            {
                adminService.Delete(admin);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(admin);
            }
        }
    }
}
