using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhonebookApp.UI
{
    public partial class frmViewAndReport : Form
    {
        public frmViewAndReport()
        {
            InitializeComponent();
        }

        private void personDetailsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonDetail frmm = new PersonDetail();
            frmm.Show();
        }

        private void frmViewAndReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frmm = new MainUI();
            frmm.Show();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportUI frm = new ReportUI();
            frm.Show();
        }

        private void ViewCompanybutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanyGrid frm = new CompanyGrid();
            frm.Show();
        }
    }
}
