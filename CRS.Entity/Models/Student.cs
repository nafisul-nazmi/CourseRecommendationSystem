using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class Student : BaseEntity
    {
        // Database fields
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double CGPA { get; set; }
        public int ProgramId { get; set; }

        // Navigation fields
        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }
        public virtual ICollection<StudentCourseAssociation> StudentCourseAssociations { get; set; }
    }
}
