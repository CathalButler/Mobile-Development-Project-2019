using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Models
{
    // Define a day of week schema for timetable
    public class TimetableElement
    {
        public string dayOfWeek { get; set; }
        // Array list of modules for one day eg testing right now "Monday"
        public List<Module> Modules { get; set; }
    }
}
