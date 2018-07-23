using System;
using System.Collections.Generic;
using System.Text;
using CRS.Entity.Generics;

namespace CRS.Entity.Models
{
    public class Department : BaseEntity
    {
        // Database fields
        public string DepartmentName { get; set; }

        // Navigation properties
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
