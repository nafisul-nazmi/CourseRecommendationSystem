using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class StudentHomeController : StudentSecuredController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}