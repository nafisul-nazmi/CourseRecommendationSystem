using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRS.Web.ViewModels
{
    public class ExamScheduleViewModel
    {
        public ExamSchedule ExamSchedule { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}