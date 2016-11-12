using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace norwold.forms
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

            /**
             * 
            DialogResult result;
            using (var loginForm = new FrmLogon())
                result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // login was successful
                Application.Run(new frmMenu());
            }
            */



            Application.Run(new frmMenu());
            //Application.Run(new frmCharacters());
            //Application.Run(new frmDesigner());
        }
    }
}
