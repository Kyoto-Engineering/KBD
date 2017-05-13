using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.LogInUI;
using PhonebookApp.UI;

namespace PhonebookApp
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
            Application.Run(new frmLogin());
            //Application.Run(new frm1());
            //Application.Run(new Group());
            //Application.Run(new GroupCreation());
            //Application.Run(new frmCategory());
            //Application.Run(new MainUI());
            //Application.Run( new CompanyCreation());
        }
    }
}
