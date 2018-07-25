using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.BLL.Services
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(IStudentRepository repository) : base(repository)
        { }
    }
}
