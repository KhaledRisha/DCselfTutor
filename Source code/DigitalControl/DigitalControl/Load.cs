using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace DigitalControl
{

    public partial class Load : Form
    {
        Form1 start;
        bool busy;
        public Load()
        {
            InitializeComponent();
            start = new Form1(this);
            GlobalVar.ti = 0;
            GlobalVar.Ismatlabrunning = false;
            busy = true;
            for (int y = 0; y < 100000; y++)
            {
                progressBar1.Step = 1;
                progressBar1.PerformStep();
            }
            this.backgroundWorker1.RunWorkerAsync();
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Start();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            while (busy)
            { }
            if (GlobalVar.ti == 0)
            {
                this.Visible = false;

                    start.ShowDialog();
                GlobalVar.ti = 1;
                if (GlobalVar.Ismatlabrunning)
                {
                    GlobalVar.mat.Quit();
                }

            }
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var activationContext = Type.GetTypeFromProgID("matlab.application.single");
            GlobalVar.mat = (MLApp.MLApp)Activator.CreateInstance(activationContext);
            GlobalVar.Ismatlabrunning = true;
            busy = false;

        }
    }
}
