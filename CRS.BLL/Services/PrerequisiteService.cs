using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Services
{
    public class PrerequisiteService : GenericService<Prerequisite>, IPrerequisiteService
    {
        public PrerequisiteService(IPrerequisiteRepository repository) : base(repository)
        { }
    }
}
