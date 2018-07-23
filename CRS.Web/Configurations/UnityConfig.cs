using CRS.BLL.Interfaces;
using CRS.BLL.Services;
using CRS.DAL.Contexts;
using CRS.DAL.Interfaces;
using CRS.DAL.Repositories;
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
            // Context
            container.RegisterType<DbContext, CRSContext>();

            // Repositories
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IProgramRepository, ProgramRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<IProgramCourseAssociationRepository, ProgramCourseAssociationRepository>();
            container.RegisterType<IPrerequisiteRepository, PrerequisiteRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentCourseAssociationRepository, StudentCourseAssociationRepository>();

            // Services
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IProgramService, ProgramService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<IProgramCourseAssociationService, ProgramCourseAssociationService>();
            container.RegisterType<IPrerequisiteService, PrerequisiteService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IStudentCourseAssociationService, StudentCourseAssociationService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}