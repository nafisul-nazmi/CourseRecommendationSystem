using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRS.Web.Controllers
{
    public class AdminSecuredController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["User"] == null || (Session["User"] as Admin) == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Login"},
                        {"action", "Index"}
                    }
                );
            }
        }
    }
}