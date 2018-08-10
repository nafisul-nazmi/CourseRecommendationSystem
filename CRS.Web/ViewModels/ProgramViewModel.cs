using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRS.Web.ViewModels
{
    public class ProgramViewModel
    {
        public Program Program { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<int> CourseIds { get; set; }
    }
}