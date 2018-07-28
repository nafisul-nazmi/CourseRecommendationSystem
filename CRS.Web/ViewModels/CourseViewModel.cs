using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRS.Web.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}