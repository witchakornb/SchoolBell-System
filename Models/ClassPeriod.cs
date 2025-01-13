using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBellSystem.Models
{
    public class ClassPeriod
    {
        public required string Name { get; set; }    // เช่น "Period 1"
        public TimeSpan StartTime { get; set; }     // เวลาเริ่มคาบ (กำหนดอัตโนมัติ)
        public int Duration { get; set; }          // ระยะเวลาคาบ (นาที) ที่รับจากผู้ใช้

        // คำนวณเวลาหมดคาบจาก Duration
        public TimeSpan EndTime => StartTime + TimeSpan.FromMinutes(Duration);
    }
}
