using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Services
{
    public class ProgramCourseAssociationService : GenericService<ProgramCourseAssociation>, IProgramCourseAssociationService
    {
        public ProgramCourseAssociationService(IProgramCourseAssociationRepository repository) : base(repository)
        { }
    }
}
