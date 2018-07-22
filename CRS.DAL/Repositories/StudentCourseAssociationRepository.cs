using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CRS.DAL.Repositories
{
    public class StudentCourseAssociationRepository : GenericRepository<StudentCourseAssociation>, IStudentCourseAssociationRepository
    {
        public StudentCourseAssociationRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
