using CRS.Entity.Models;
using CRS.Entity.SupportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.BLL.Interfaces
{
    public interface IRecommendationService
    {
        List<Course> GetRecommendation(int studentId, FilterModel filterModel);
    }
}
