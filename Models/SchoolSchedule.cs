using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBellSystem.Models
{
    public class SchoolSchedule
    {
        public required string BellSound { get; set; }
        public List<ClassPeriod> Periods { get; set; } = new List<ClassPeriod>();
    }
}
