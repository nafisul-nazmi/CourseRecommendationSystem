using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CRS.DAL.Contexts
{
    public class CRSContext : DbContext
    {
        public CRSContext() : base("CRS")
        { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Prerequisite> Prerequisites { get; set; }
        public DbSet<ProgramCourseAssociation> ProgramCourseAssociations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourseAssociation> StudentCourseAssociations { get; set; }

    }
}
