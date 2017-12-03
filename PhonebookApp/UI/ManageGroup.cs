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
    public partial class ManageGroup : Form
    {
        public ManageGroup()
        {
            InitializeComponent();
        }

        private void ManageGroupsbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmManageGroups frm = new frmManageGroups();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void MemberAddedToGroupbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Group frm = new Group();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
