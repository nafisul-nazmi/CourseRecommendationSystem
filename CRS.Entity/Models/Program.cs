using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class Program : BaseEntity
    {
        // Database fields
        public string ProgramName { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<ProgramCourseAssociation> ProgramCourseAssociations { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
