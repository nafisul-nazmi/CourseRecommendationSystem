using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.BLL.Interfaces
{
    public interface IRecommendationService
    {
        IEnumerable<Course> GetUnlockedCourses(int studentId);
        IEnumerable<Course> GetRetakeAbleCourses(int studentId);
    }
}
