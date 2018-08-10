using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class Course : BaseEntity
    {
        // Database fields
        [Column("CourseId")]
        [Key]
        public override int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double CourseCredits { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<ProgramCourseAssociation> ProgramCourseAssociations { get; set; }
        public virtual ICollection<StudentCourseAssociation> StudentCourseAssociations { get; set; }
    }
}
