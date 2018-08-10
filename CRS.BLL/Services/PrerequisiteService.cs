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
        private IPrerequisiteRepository prerequisiteRepository;

        public PrerequisiteService(IPrerequisiteRepository repository) : base(repository)
        {
            this.prerequisiteRepository = repository;
        }

        public void DeletePrequisiteByCourse(int courseId)
        {
            IEnumerable<Prerequisite> prequisitesToDelete = repository.FindBy(x => x.CourseId == courseId);
            prerequisiteRepository.DeleteCollection(prequisitesToDelete);
        }

        public void DeleteAllByCourse(int courseId)
        {
            IEnumerable<Prerequisite> prequisitesToDelete = repository.FindBy(x => x.CourseId == courseId || x.CoursePrerequisiteId == courseId);
            prerequisiteRepository.DeleteCollection(prequisitesToDelete);
        }
    }
}
