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

    public partial class Ex : Form
    {
        Topic f5;
       
        // get & set the visiblity for the Ex buttons
        public string LabelText
        {get{ return label1.Text; } set{ label1.Text = value; }}
        public string Labe2Text
        {get{ return label2.Text; } set{ label2.Text = value; }}
        public string Labe3Text
        { get { return label3.Text; } set { label3.Text = value; } }
        public bool pic
        {get{ return pictureBox1.Visible; }set{ pictureBox1.Visible = value; }}
        public bool pic2
        { get { return pictureBox2.Visible; } set { pictureBox2.Visible = value; } }

        public Ex(Topic f)
        {
            InitializeComponent();
            f5 = f;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Visible = true;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel2.Enabled = false;
            if (GlobalVar.chk)
            {
                
                object result = null;
                string loc = "Example" + GlobalVar.Example;
                try
                {
                    GlobalVar.mat.Execute(@"cd 'C:\DigitalControl\Lecture'" + GlobalVar.Lec);
                    if (!File.Exists((@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "\\" + "Example" + GlobalVar.Example + ".png")))
                    {
                        GlobalVar.mat.Feval(loc, 0, out result);
                        GlobalVar.Ismatlabrunning = true;
                        GlobalVar.chk = false;
                    }
                }

                catch
                {
                    MessageBox.Show("Error in Matlab Code");
                }
            }
            label2.Text = File.ReadAllText(@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "\\"+"Example" + GlobalVar.Example + ".txt");
            if (File.Exists((@"C:\DigitalControl\Lecture" + GlobalVar.Lec +"\\"+ "Example" + GlobalVar.Example + ".png")))
            {
                 pictureBox1.Visible = true;
                 pictureBox1.Image = new Bitmap(@"C:\DigitalControl\Lecture" + GlobalVar.Lec +"\\"+ "Example" + GlobalVar.Example + ".png");
            }
        }

        private void Ex_Load(object sender, EventArgs e)
        {
            if (GlobalVar.Lec == 9 && GlobalVar.Example== 1)
            {
                pictureBox2.Image = new Bitmap(@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "Example" + GlobalVar.Example + "(Question).png");
                pictureBox2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.Enabled = true;
            object result = null;
            GlobalVar.mat.Execute(@"cd 'C:\DigitalControl\Lecture'" + GlobalVar.Lec);
            GlobalVar.mat.Feval("matlab2text", 0, out result);
            label3.Text = File.ReadAllText(@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "\\" + "Example" + GlobalVar.Example + "[TEXT].txt");
           
        }
       

    }
}

