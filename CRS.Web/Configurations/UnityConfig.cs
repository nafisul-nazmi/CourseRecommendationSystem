using CRS.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CRS.Web.Configurations
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Add mappings here
            container.RegisterType<DbContext, CRSContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}