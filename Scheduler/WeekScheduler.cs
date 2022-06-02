using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class WeekScheduler : UserControl
    {
        private int _row;
        private int _col;

        private ICollection<CalendarEvent> CalendarEvents = new List<CalendarEvent>();

        private static System.Timers.Timer Timer;

        public event EventHandler<EventArgs> Reminder;

        
        public WeekScheduler()
        {
            InitializeComponent();
            
            SetTimer();

            
            comboBox3.Items.AddRange(new []{"green", "blue", "orange", "red"});
            
            for (var i = 0; i < 13; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    comboBox1.Items.Add((i+8)+(j%2==0? ":00" : ":30"));
                }
            }

            calendar1.SlotClicked += (o, e) =>
            {
                _row = e.Row;
                _col = e.Col;
                comboBox1.SelectedIndex = _row;
                comboBox2.Items.Clear();
                var items = new List<object>();
                for (var i = _row+1; i < comboBox1.Items.Count; i++)
                {
                    items.Add(comboBox1.Items[i]);
                }
                comboBox2.Items.AddRange(items.ToArray());
                comboBox2.SelectedIndex = 0;
            };

            button1.Click += (o, e) =>
            {
                var c = new CalendarEvent();
                c.Name = textBox1.Text;
                c.Row = _row;
                c.Col = _col;
                c.Duration = comboBox2.SelectedIndex+1;
                switch (comboBox3.SelectedItem)
                {
                    case "green":
                        c.Color = Color.GreenYellow;
                        break;
                    case "blue":
                        c.Color = Color.Aqua;
                        break;
                    case "orange":
                        c.Color = Color.Orange;
                        break;
                    case "red":
                        c.Color = Color.Red;
                        break;
                }

                c.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day + Math.Abs(c.Col - (int) DateTime.Now.DayOfWeek), 
                    8 + c.Row / 2, c.Row % 2 == 0? 0:30,0);
                CalendarEvents.Add(c);
                for (var i = 0; i < c.Duration; i++)
                {
                    var b = calendar1.TlpMain.Controls[(c.Row+i)*7+c.Col];
                    b.BackColor = c.Color;
                    b.Text = c.Name;
                }
            };
        }
        
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            Timer = new System.Timers.Timer(6000);
            // Hook up the Elapsed event for the timer. 
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            foreach (var calendarEvent in CalendarEvents)
            {
                if(DateTime.UtcNow.AddMinutes(15) > calendarEvent.DateTime)
                    Reminder?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}