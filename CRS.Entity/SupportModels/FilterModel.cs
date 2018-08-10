using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Entity.SupportModels
{
    public class FilterModel
    {
        public bool AvoidClashExams { get; set; }
        public bool AvoidTwoExamsInADay { get; set; }
        public bool AvoidThreeExamsInADay { get; set; }
        public bool AvoidRetakeable { get; set; }
        public double NumberOfCredits { get; set; }
    }
}
