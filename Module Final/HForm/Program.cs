using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
 

namespace HForm.MForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool exist = false;
            if (DataLayer.goodConfiguration() == true)
            {
                exist = DataLayer.register_();
                if (exist)
                {
                    Application.Run(new Login());
                }
                else
                {
                    Application.Run(new Register());
                }

            }
            else
            {
                Application.Run(new Configuration());

            }
        }
    }
}
