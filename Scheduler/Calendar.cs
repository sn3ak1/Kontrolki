using System;
using System.Windows.Forms;

namespace Scheduler
{
    internal sealed partial class Calendar : UserControl
    {
        private const int RowCount = 28;
        private const int ColumnCount = 7;
        private const int RowHeight = 40;
        private const int RowWidth = 100;
        
        public event EventHandler<CalendarEventArgs> SlotClicked;
        public TableLayoutPanel TlpMain;

        public Calendar()
        {
            InitializeComponent();

            AutoScroll = true;
            
            AddTlpMain();
            AddTlpDays();
            AddTlpHours();
        }
        
        private void AddTlpMain()
        {
            TlpMain = new TableLayoutPanel();
            
            TlpMain.ColumnCount = ColumnCount;
            TlpMain.RowCount = RowCount;
            TlpMain.Height = RowCount * RowHeight+15;
            TlpMain.Width = ColumnCount * RowWidth +12;
            TlpMain.Top = 40;
            TlpMain.Left = 60;
            
            TlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            for (int i = 0; i < TlpMain.RowCount; i++)
            {
                TlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, RowHeight));
            }
            for (int i = 0; i < TlpMain.ColumnCount; i++)
            {
                TlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, RowWidth));
            }

            for (var i = 0; i < (RowCount*2)*ColumnCount; i++)
            {
                var button = new Button() {Dock = DockStyle.Fill};
                var i2 = i;
                button.Click += (o,e)=>
                    SlotClicked?.Invoke(this, new CalendarEventArgs(i2/ColumnCount, i2%ColumnCount));
                TlpMain.Controls.Add(button);
            }
            
            Controls.Add(TlpMain);
        }

        private void AddTlpDays()
        {
            var tlpDays = new TableLayoutPanel();
            
            tlpDays.ColumnCount = ColumnCount;
            tlpDays.RowCount = 1;
            tlpDays.Height = RowHeight;
            tlpDays.Width = 7 * RowWidth+12;
            tlpDays.Top = 10;
            tlpDays.Left = 60;
            
            tlpDays.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            for (int i = 0; i < tlpDays.RowCount; i++)
            {
                tlpDays.RowStyles.Add(new RowStyle(SizeType.Absolute, RowHeight));
            }
            for (int i = 0; i < tlpDays.ColumnCount; i++)
            {
                tlpDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, RowWidth));
            }

            var days = new[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            for (var i = 0; i < 7; i++)
            {
                tlpDays.Controls.Add(new Label(){Text = days[i]});
            }
            
            Controls.Add(tlpDays);
        }
        
        private void AddTlpHours()
        {
            var tlpHours = new TableLayoutPanel();
            
            tlpHours.ColumnCount = 1;
            tlpHours.RowCount = RowCount-1;
            tlpHours.Height = RowCount*RowHeight+15;
            tlpHours.Width = 60;
            tlpHours.Top = 40;
            tlpHours.Left = 10;
            
            tlpHours.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            for (int i = 0; i < tlpHours.RowCount; i++)
            {
                tlpHours.RowStyles.Add(new RowStyle(SizeType.Absolute, RowHeight));
            }
            for (int i = 0; i < tlpHours.ColumnCount; i++)
            {
                tlpHours.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            }

            for (var i = 0; i < RowCount/2-1; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    tlpHours.Controls.Add(new Label(){Text = (i+8)+(j%2==0? ":00" : ":30")});
                }
            }
            tlpHours.Controls.Add(new Label(){Text = "21:00"});

            Controls.Add(tlpHours);
        }
    }
    
    public class CalendarEventArgs : EventArgs
    {
        public CalendarEventArgs(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; }
        public int Col { get; }
    }
}