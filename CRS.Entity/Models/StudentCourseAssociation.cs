using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class StudentCourseAssociation : BaseEntity
    {
        // Database fields
        [Column("StudentCourseAssociationId")]
        [Key]
        public override int Id { get; set; }
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
