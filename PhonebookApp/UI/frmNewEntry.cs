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
    public partial class frmNewEntry : Form
    {
        public frmNewEntry()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            CompanyCreation frm = new CompanyCreation();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frm1 frmX = new frm1();
            this.Visible = false;
            frmX.ShowDialog();
            this.Visible = true;
        }

        private void frmNewEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            MainUI frm = new MainUI();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
