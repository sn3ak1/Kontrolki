using System.Windows.Forms;
using Scheduler;

namespace Kontrolki
{
    public partial class FormScheduler : Form
    {
        public FormScheduler()
        {
            InitializeComponent();
            var weekScheduler = new WeekScheduler();
            Controls.Add(weekScheduler);
        }
    }
}