using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.DAL.Interfaces
{
    public interface IPrerequisiteRepository : IGenericRepository<Prerequisite>
    {
        void DeleteCollection(IEnumerable<Prerequisite> prerequisites);
    }
}
