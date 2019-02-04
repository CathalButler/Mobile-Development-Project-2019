using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Models
{
    // Define a schema for module entrys
    public class Module
    {
        public string title { get; set; }
        public string time { get; set; }
        public string room { get; set; }
    }
}
