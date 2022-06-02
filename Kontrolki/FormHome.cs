using System;
using System.Windows.Forms;

namespace Kontrolki
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormPasswordValidation();
            form.Closed += (_, _) => this.Show();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new FormScheduler();
            form.Closed += (_, _) => this.Show();
            this.Hide();
            form.Show();
        }
    }
}