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
            //this.Hide();
            Specialization frm = new Specialization();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void frmManageGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            MainUI frm = new MainUI();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void buttonProfession_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Profession frm = new Profession();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void buttonAgeGroup_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AgeGroup frm = new AgeGroup();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void Categorybutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmCategory frm = new frmCategory();
            //frm.Show();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void buttonEducationLevel_Click(object sender, EventArgs e)
        {
            ////this.Hide();
            EducationLevel frm = new EducationLevel();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void buttonJobTitle_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmJobTitle frm = new frmJobTitle();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void NewGroupCreationbutton_Click(object sender, EventArgs e)
        {
           
            GroupCreation frm = new GroupCreation();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        
    }
}
