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
   
    public partial class Topic : Form
    {
        // communcation with the forms 
        Form1 frm;
        Ex f;
        int i = 0;
        int j = 0;
        // get & set the visiblity for the Ex buttons
        public bool butvis1
        { get{ return button1.Visible;  } set { button1.Visible = value; } }
        public bool butvis2
        { get { return button2.Visible; } set { button2.Visible = value; } }
        public bool butvis3
        { get { return button3.Visible; } set { button3.Visible = value; } }
        public bool butvis4
        { get { return button5.Visible; } set { button5.Visible = value; } }
        private void OpenMainForm()
        {
            this.Hide();           //Hide the main form before showing the secondary
            f.ShowDialog();        //Show secondary form, code execution stop until frm2 is closed
            this.Show();           //When frm2 is closed, continue with the code (show main form)
        }
        private void setVar()
        {
            f.Labe2Text = "";       // Empty Lable 2
            f.Labe3Text = "";       // Empty Lable 3
            f.pic = false;          // Make pictureBox 1 unvisible 
            f.pic2 = false;         // Make pictureBox 2 unvisible 
            GlobalVar.chk = true;   // Set the ckh to run the matlab one time
            // Open the question 
            if (File.Exists((@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "Example" + GlobalVar.Example + "(Question).txt")))
            {
                f.LabelText = File.ReadAllText(@"C:\DigitalControl\Lecture" + GlobalVar.Lec + "Example" + GlobalVar.Example + "(Question).txt");
                OpenMainForm(); // Show the needed form
            }
            else
                MessageBox.Show("SOON");
        }
        private void nbutton()
        {

            GlobalVar.Example = GlobalVar.newb;
            setVar();
        }

        public void matnew(string openpath,string Qpath)
        {
            // Where to copy the files
            string dest = "C:\\DigitalControl";
            object r = null;
            object nname = null;
            object nname1 = null;
            object r1 = null;
            try
            {
                GlobalVar.mat.Feval("user_file", 0, out nname, openpath, GlobalVar.Lec.ToString(), GlobalVar.newb.ToString());
                GlobalVar.mat.Feval("user_filetxt", 0, out nname1, Qpath, GlobalVar.Lec.ToString(), GlobalVar.newb.ToString());
                GlobalVar.mat.Equals(dest);
                GlobalVar.mat.Feval("initializer_w_prepapp", 0, out r);
                GlobalVar.mat.Execute(dest + "\\Lecture" + GlobalVar.Lec);
                GlobalVar.mat.Feval("matlab2text", 0, out r1);
           }
           catch
           {
               MessageBox.Show("Error in matlab code");
           }
                
        }
        public Topic(Form1 fr)
        {
            InitializeComponent();        // set the component on the form
            f = new Ex(this);            // creat run-time pointer to form Ex;
            frm = fr;
            GlobalVar.Isnw = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GlobalVar.Example = 1;      // this is Example 1
            setVar();                   // run the function setVar to put the initial condition for the GUI comp. to reuse.
        }

        private void button2_Click(object sender, EventArgs e)
        {
         GlobalVar.Example = 2;
         setVar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalVar.Example = 3;
            setVar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlobalVar.Example = 4;
            setVar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
          
            // Add the M-file
            openFileDialog1.Filter = "m files (*.m)| *.m";
            openFileDialog1.ShowDialog();
            string openpath = openFileDialog1.FileName;
           // Add the Question
            openFileDialog1.Filter = "text files (*.txt)| *.txt";
            openFileDialog1.ShowDialog();
            string Qpath = openFileDialog1.FileName;
            // put the file in the right place to deal with it
            if (GlobalVar.newb <= 11)
            {
              //   GlobalVar.Isnw = true;
                // Run the matlab to preper the file 
                
                // If it a excist button run it 
                if (GlobalVar.newb == 2)
                { GlobalVar.Example = 2; button2.Visible = true; matnew(openpath, Qpath); }
                else if (GlobalVar.newb == 3)
                { GlobalVar.Example = 3; button3.Visible = true; matnew(openpath, Qpath); }
                else if (GlobalVar.newb == 4)
                { GlobalVar.Example = 4; button5.Visible = true; matnew(openpath, Qpath); }
                // For the new button 
                else
                {
                    // Cearte new button 
                    var button = new Button();
                    button.Visible = true;
                    button.UseVisualStyleBackColor = true;
                    button.Text = "Ex " + GlobalVar.newb;
                    button.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    // Put the button in the right place
                    button.Location = new Point(250 + i, 70 + j);
                    button.Size = new Size(100, 40);
                    // Add the button to the GUI
                    this.Controls.Add(button);
                    // Move it down 
                    j += 70;
                    matnew(openpath, Qpath);
                    nbutton();
                }
                // return to the top and move right
                if (j == 280)
                {
                    i += 150;
                    j = 0;
                }
                // for Adding new button 
                GlobalVar.newb++;
                
                
            }
            else
                MessageBox.Show("It's reached the limit"); // When it's reached the max. of buttons 
        }



    }

}
