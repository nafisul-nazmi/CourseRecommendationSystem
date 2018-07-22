using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CRS.DAL.Repositories
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
