using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CRS.Entity.Generics;

namespace CRS.Entity.Models
{
    public class Department : BaseEntity
    {
        // Database fields
        [Column("DepartmentId")]
        [Key]
        public override int Id { get; set; }
        public string DepartmentName { get; set; }

        // Navigation properties
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
