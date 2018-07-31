using CRS.BLL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class RecommendationController : StudentSecuredController
    {
        private IRecommendationService recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            this.recommendationService = recommendationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FilterModel filterModel)
        {

            throw new NotImplementedException();
        }
    }
}