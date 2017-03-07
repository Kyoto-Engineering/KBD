using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.UI;

namespace PhonebookApp.LogInUI
{
    public partial class UserManagementUI : Form
    {
        public UserManagementUI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistration frm = new frmRegistration();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                     this.Hide();
            ChangePassword frm=new ChangePassword();
                      frm.Show();
        }

        private void UserManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
              this.Hide();
            MainUI frm= new MainUI();
              frm.Show();
        }
    }
}
