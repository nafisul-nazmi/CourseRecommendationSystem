using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class StudentCourseAssociation : BaseEntity
    {
        // Database fields
        public int StudentCourseAssociationId { get; set; }
        public double Marks { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
