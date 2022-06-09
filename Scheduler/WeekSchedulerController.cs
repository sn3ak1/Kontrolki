using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace Scheduler
{
    public class WeekSchedulerController
    {
        private readonly ICollection<CalendarEvent> _calendarEvents;
        private static System.Timers.Timer _timer;
        private EventHandler<EventArgs> _reminder;
        
        public WeekSchedulerController(EventHandler<EventArgs> reminder)
        {
            _calendarEvents = new List<CalendarEvent>();
            _reminder = reminder;
            SetTimer();
        }

        public CalendarEvent GetCalendarEvent(int row, int col)
        {
            return _calendarEvents.Where(calendarEvent => calendarEvent.Col == col)
                .FirstOrDefault(calendarEvent => row >= calendarEvent.Row && row < calendarEvent.Row + calendarEvent.Duration);
        }

        public void AddEvent(int row, int col, string name, int duration, Color color)
        {
            var c = GetCalendarEvent(row, col);
            if(c==null)
            {
                c = new CalendarEvent() {Col = col, Row = row};
                _calendarEvents.Add(c);
            }
            c.Color = color;
            c.Duration = duration;
            c.Name = name;

            c.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day + Math.Abs(c.Col - (int) DateTime.Now.DayOfWeek), 
                8 + c.Row / 2, c.Row % 2 == 0? 0:30,0);
        }

        public CalendarEvent DeleteEvent(int row, int col)
        {
            var c = GetCalendarEvent(row, col);
            _calendarEvents.Remove(c);
            return c;
        }
        
        private void SetTimer()
        {
            _timer = new System.Timers.Timer(6000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            foreach (var calendarEvent in _calendarEvents)
            {
                if(DateTime.UtcNow.AddMinutes(15) > calendarEvent.DateTime)
                    _reminder?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}