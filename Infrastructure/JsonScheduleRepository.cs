using Newtonsoft.Json;
using SchoolBellSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace SchoolBellSystem.Infrastructure
{
    public class JsonScheduleRepository : IScheduleRepository
    {
        private readonly string _filePath;

        public JsonScheduleRepository(string filePath)
        {
            _filePath = filePath;
        }

        public SchoolSchedule Load()
        {
            if (!File.Exists(_filePath))
                return new SchoolSchedule { BellSound = "defaultSound" };

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<SchoolSchedule>(json) ?? new SchoolSchedule { BellSound = "defaultSound" };
        }

        public void Save(SchoolSchedule schedule)
        {
            var json = JsonConvert.SerializeObject(schedule, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}