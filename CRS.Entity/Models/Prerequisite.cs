using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class Prerequisite : BaseEntity
    {
        // Database fields
        [Column("PrerequisiteId")]
        [Key]
        public override int Id { get; set; }
        public int CourseId { get; set; }
        public int CoursePrerequisiteId { get; set; }

        // Navigation properties
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("CoursePrerequisiteId")]
        public virtual Course CoursePrerequisite { get; set; }
    }
}
