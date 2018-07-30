using CRS.BLL.Interfaces;
using CRS.BLL.Services;
using CRS.DAL.Contexts;
using CRS.DAL.Interfaces;
using CRS.DAL.Repositories;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CRS.Web
{
    public static class UnityConfig
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
            container.RegisterType<IExamScheduleRepository, ExamScheduleRepository>();
            container.RegisterType<IWarehouseRepository, WarehouseRepository>();

            // Services
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IProgramService, ProgramService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<IProgramCourseAssociationService, ProgramCourseAssociationService>();
            container.RegisterType<IPrerequisiteService, PrerequisiteService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IStudentCourseAssociationService, StudentCourseAssociationService>();
            container.RegisterType<IExamScheduleService, ExamScheduleService>();
            container.RegisterType<IWarehouseService, WarehouseService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}