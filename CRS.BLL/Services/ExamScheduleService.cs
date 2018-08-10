using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.BLL.Services
{
    public class ExamScheduleService : GenericService<ExamSchedule>, IExamScheduleService
    {
        public ExamScheduleService(IExamScheduleRepository repository) : base(repository)
        { }
    }
}
