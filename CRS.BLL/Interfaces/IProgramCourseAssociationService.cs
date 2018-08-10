using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Interfaces
{
    public interface IProgramCourseAssociationService : IGenericService<ProgramCourseAssociation>
    {
        void DeleteAssociationByProgram(int programId);
    }
}
