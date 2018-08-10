using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Entity.Models
{
    public class ExamSchedule : BaseEntity
    {
        //Database fields
        [Column("ExamScheduleId")]
        [Key]
        public override int Id { get; set; }
        public int CourseId { get; set; }
        public int Day { get; set; }
        public int Slot { get; set; }

        //Navigation Properties
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
