using SchoolBellSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBellSystem.Infrastructure
{
    public interface IScheduleRepository
    {
        SchoolSchedule Load();
        void Save(SchoolSchedule schedule);
    }
}
