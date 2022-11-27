using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApp2
{
    public partial class FormTimeLogo : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public FormTimeLogo()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer.Enabled = true;
            timer.Interval = 3000;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
            timer.AutoReset = false;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.timer.Enabled = false;
            this.Dispose();
        }

        private void FormTimeLogo_Load(object sender, EventArgs e)
        {
            label1.Text = "Здравствуйте, " + MyElements.LogName + "!";

        }
    }
}
