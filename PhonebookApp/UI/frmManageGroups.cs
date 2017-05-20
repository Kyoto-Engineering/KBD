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
    public partial class frmManageGroups : Form
    {
        public frmManageGroups()
        {
            InitializeComponent();
        }

        private void buttonSpecialization_Click(object sender, EventArgs e)
        {
            this.Hide();
            Specialization frm = new Specialization();
            frm.Show();
        }

        private void frmManageGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void buttonProfession_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profession frm = new Profession();
            frm.Show();
        }

        private void buttonAgeGroup_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgeGroup frm = new AgeGroup();
            frm.Show();
        }

        private void Categorybutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCategory frm = new frmCategory();
            frm.Show();
        }

        private void buttonEducationLevel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EducationLevel frm = new EducationLevel();
            frm.Show();
        }

        private void buttonJobTitle_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmJobTitle frm = new frmJobTitle();
            frm.Show();
        }

        private void NewGroupCreationbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupCreation frm = new GroupCreation();
            frm.Show();
        }

        
    }
}
