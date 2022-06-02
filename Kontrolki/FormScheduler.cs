using System.Windows.Forms;
using Scheduler;

namespace Kontrolki
{
    public partial class FormScheduler : Form
    {
        public FormScheduler()
        {
            InitializeComponent();
            Height = 25 * 30;
            Width = 8 * 200;
            var weekScheduler = new WeekScheduler();
            Controls.Add(weekScheduler);
        }
    }
}