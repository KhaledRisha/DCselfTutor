using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace DigitalControl
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [STAThread]


        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Load());

            // Create the MATLAB instance 
           // MLApp.MLApp matlab = new MLApp.MLApp();
          //var activationContext = Type.GetTypeFromProgID("matlab.application.single");
               
            //// Change to the directory where the function is located 
            //matlab.Execute("1+2");

            //// Define the output 
            //object result = null;

            //// Call the MATLAB function myfunc
            //matlab.Feval("myfunc", 2, out result, 3.14, 42.0, "world");

            //// Display result 
            //object[] res = result as object[];
            //label1.Text = result.ToString();

         }
      }
}
