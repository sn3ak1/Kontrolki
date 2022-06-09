using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class WeekScheduler : UserControl
    {
        private int _row;
        private int _col;
        
        public event EventHandler<EventArgs> Reminder;

        private WeekSchedulerController _weekSchedulerController;

        private Dictionary<string, Color> _colors = new Dictionary<string, Color>()
        {
            {"Green", Color.Green},
            {"Blue", Color.Aqua},
            {"Orange", Color.Orange},
            {"Red", Color.Red}
        };

        public WeekScheduler()
        {
            InitializeComponent();

            _weekSchedulerController = new WeekSchedulerController(Reminder);
            
            comboBox3.Items.AddRange(_colors.Select(x => x.Key).ToArray());
            comboBox3.SelectedIndex = 0;
            
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
                comboBox3.SelectedIndex = 0;
                textBox1.Text = "";
                comboBox2.Items.Clear();
                var items = new List<object>();
                var calendarEvent = _weekSchedulerController.GetCalendarEvent(_row, _col);
                if (calendarEvent != null)
                {
                    textBox1.Text = calendarEvent.Name;
                    comboBox3.SelectedItem = _colors.FirstOrDefault(x => x.Value == calendarEvent.Color).Key;
                    for (var i = calendarEvent.Row+1; i < comboBox1.Items.Count; i++)
                    {
                        items.Add(comboBox1.Items[i]);
                    }
                    comboBox2.Items.AddRange(items.ToArray());
                    comboBox2.SelectedIndex = calendarEvent.Duration - 1;
                    comboBox1.SelectedIndex = calendarEvent.Row;
                }
                else
                {
                    for (var i = _row+1; i < comboBox1.Items.Count; i++)
                    {
                        items.Add(comboBox1.Items[i]);
                    }
                    comboBox2.Items.AddRange(items.ToArray());
                    comboBox2.SelectedIndex = 0;
                }
            };

            button1.Click += (o, e) =>
            {
                var old = new CalendarEvent(_weekSchedulerController.GetCalendarEvent(_row, _col));
                _weekSchedulerController.AddEvent(_row,_col, textBox1.Text, 
                    comboBox2.SelectedIndex + 1, _colors[comboBox3.SelectedItem.ToString()]);
                var c = _weekSchedulerController.GetCalendarEvent(_row, _col) 
                        ?? _weekSchedulerController.GetCalendarEvent(old.Row, old.Col);
                for (var i = 0; i < c.Duration; i++)
                {
                    var b = calendar1.TlpMain.Controls[(c.Row+i)*7+c.Col];
                    b.BackColor = c.Color;
                    b.Text = c.Name;
                }

                if (old.Name==null || old.Duration <= c.Duration) return;
                {
                    for (var i = c.Duration; i < old.Duration; i++)
                    {
                        var b = calendar1.TlpMain.Controls[(c.Row+i)*7+c.Col];
                        b.BackColor = Color.White;
                        b.Text = "";
                    }
                }
            };

            button2.Click += (o, e) =>
            {
                var c = _weekSchedulerController.DeleteEvent(_row, _col);
                for (var i = 0; i < c.Duration; i++)
                {
                    var b = calendar1.TlpMain.Controls[(c.Row + i) * 7 + c.Col];
                    b.BackColor = Color.White;
                    b.Text = "";
                }
            };
        }
    }
}