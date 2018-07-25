using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Services
{
    public class ProgramService : GenericService<Program>, IProgramService
    {
        public ProgramService(IProgramRepository repository) : base(repository)
        { }
    }
}
