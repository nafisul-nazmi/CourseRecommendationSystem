using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class HomeController : AdminSecuredController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}