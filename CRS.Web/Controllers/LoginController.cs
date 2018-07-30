using CRS.BLL.Interfaces;
using CRS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class LoginController : Controller
    {
        private IAdminService adminService;
        private IStudentService studentService;

        public LoginController(IAdminService adminService, IStudentService studentService)
        {
            this.adminService = adminService;
            this.studentService = studentService;
        }

        public ActionResult Index()
        {
            if(Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            string email = loginViewModel.Email;
            string password = loginViewModel.Password;
            var admin = adminService.FindBy(x => x.Email == email && x.Password == password).SingleOrDefault();
            var student = studentService.FindBy(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (admin != null)
            {
                Session["User"] = admin;
                return RedirectToAction("Index", "Home");
            }
            else if(student != null)
            {
                Session["User"] = student;
                return RedirectToAction("NOT IMPLEMENTED");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Email/Password";
                return View(loginViewModel);
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}