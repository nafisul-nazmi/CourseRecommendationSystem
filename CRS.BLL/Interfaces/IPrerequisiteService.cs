using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Interfaces
{
    public interface IPrerequisiteService : IGenericService<Prerequisite>
    {
        void DeletePrequisiteByCourse(int courseId);
        void DeleteAllByCourse(int courseId);
    }
}
