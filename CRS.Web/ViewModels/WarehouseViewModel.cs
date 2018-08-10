using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRS.Web.ViewModels
{
    public class WarehouseViewModel
    {
        public Warehouse Warehouse { get; set; }
        public IEnumerable<Course> AllCourses { get; set; }
        public IEnumerable<string> SelectedCourses { get; set; }
    }
}