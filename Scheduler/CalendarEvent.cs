using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler
{
    public class CalendarEvent
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public Color Color { get; set; }
        
        public int Duration { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}