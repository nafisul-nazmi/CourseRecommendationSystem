using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.DAL.Repositories
{
    public class ExamScheduleRepository : GenericRepository<ExamSchedule>, IExamScheduleRepository
    {
        public ExamScheduleRepository(DbContext dbContext): base(dbContext)
        { }
    }
}
