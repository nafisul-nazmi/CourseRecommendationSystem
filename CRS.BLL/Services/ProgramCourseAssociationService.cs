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
        private IProgramCourseAssociationRepository programCourseAssociationRepository;

        public ProgramCourseAssociationService(IProgramCourseAssociationRepository repository) : base(repository)
        {
            this.programCourseAssociationRepository = repository;
        }

        public void DeleteAssociationByProgram(int programId)
        {
            IEnumerable<ProgramCourseAssociation> programCourseAssociations = repository.FindBy(x => x.ProgramId == programId);
            programCourseAssociationRepository.DeleteCollection(programCourseAssociations);
        }
    }
}
