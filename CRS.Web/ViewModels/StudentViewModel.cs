using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRS.Web.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Program> Programs { get; set; }
    }
}