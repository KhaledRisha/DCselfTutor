using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DigitalControl
{
    
    public partial class Form1 : Form
    {
        Topic frm;
        private void OpenMainForm()
        {
            GlobalVar.newb = 2;
            this.Hide();           //Hide the main form before showing the secondary
            frm.ShowDialog();     //Show secondary form, code execution stop until frm2 is closed
            //  GlobalVar.Isnw = false;
            this.Show();           //When frm2 is closed, continue with the code (show main form)
        }

        public Form1(Load start)
        {
            InitializeComponent();  // set the component on the form
            frm = new Topic(this);  // creat run-time pointer to form Ex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lecture number 
            GlobalVar.Lec = 1;
            GlobalVar.newb = 2;
            // Make the needed button visable 
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVar.Lec = 2;
            GlobalVar.newb = 2;
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            GlobalVar.Lec = 3;
            GlobalVar.newb = 2;
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            GlobalVar.Lec = 4;
            GlobalVar.newb = 4;
            frm.butvis1 = true;
            frm.butvis2 = true;
            frm.butvis3 = true;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            GlobalVar.Lec = 5;
            GlobalVar.newb = 2;
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalVar.Lec = 6;
            GlobalVar.newb = 5;
            frm.butvis1 = true;
            frm.butvis2 = true;
            frm.butvis3 = true;
            frm.butvis4 = true;

            OpenMainForm();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GlobalVar.Lec = 7;
            GlobalVar.newb = 2;
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GlobalVar.Lec = 8;
            GlobalVar.newb = 2;
            frm.butvis1 = true;
            frm.butvis2 = false;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GlobalVar.Lec = 9;
            GlobalVar.newb = 3;
            frm.butvis1 = true;
            frm.butvis2 = true;
            frm.butvis3 = false;
            frm.butvis4 = false;
            OpenMainForm();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure??", "Exit?!", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                GlobalVar.mat.Quit();
                Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var dialogResult2 = MessageBox.Show("SOON");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check for the folder is created or not
            string dest = "C:\\DigitalControl";
            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);

            }
            // Put the m-files in the correct location
            string getpath = Path.GetDirectoryName(Application.ExecutablePath);
            string target = "Lectures";
            string sourcedirectory = Path.Combine(getpath, target);
            if (Directory.Exists(sourcedirectory))
            {
                foreach (string newPath in Directory.GetFiles(sourcedirectory, "*.*", SearchOption.AllDirectories))
                {
                    string check1 = Path.GetFileName(newPath);
                    string check2 = Path.Combine(dest, check1);
                    if (!File.Exists(check2))
                        File.Copy(newPath, newPath.Replace(sourcedirectory, dest), true);
                }
            }
            else
            {
                MessageBox.Show("Unable to find required files, plase get Lectures Folder");
                GlobalVar.Ismatlabrunning = false;
                Close();
            }
            object r = null;
            GlobalVar.mat.Execute(@"cd 'C:\DigitalControl'");
            GlobalVar.mat.Feval("initializer", 0, out r);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose required lecture then choose the example & Click Solve", "Help", MessageBoxButtons.OK);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();
            settingsForm.Show();
        }

    }
  
}
