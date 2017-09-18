using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.LogInUI;

namespace PhonebookApp.UI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frm1  frm=new frm1();
            // frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmCategory frm=new frmCategory();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            UserManagementUI frm=new UserManagementUI();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmLogin frm=new frmLogin();
            this.Dispose();
            //frm.Show();
            
        }


       
        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //CompanyCreation frm = new CompanyCreation();
            //frm.Show();
        }

        private void buttonSpecialization_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Specialization frm = new Specialization();
            //frm.Show();
        }

        private void buttonProfession_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Profession frm = new Profession();
            //frm.Show();
        }

        private void buttonEducationLevel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //EducationLevel frm = new EducationLevel();
            //frm.Show();
        }

        private void buttonAgeGroup_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //AgeGroup frm = new AgeGroup();
            //frm.Show();
        }

        private void buttonJobTitle_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmJobTitle frm = new frmJobTitle();
            //frm.Show();
        }

        private void GroupCreationbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //GroupCreation frm = new GroupCreation();
            //frm.Show();
        }

        private void MemberAddedToGroupbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Group frm = new Group();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void personDetailsButton_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            //PersonDetail frm = new PersonDetail();
            //frm.Show();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ReportUI frm = new ReportUI();
            //frm.Show();
        }

        private void NewEntrybutton_Click(object sender, EventArgs e)
        {
        
            frmNewEntry frm = new frmNewEntry();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void ManageGroupsbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmManageGroups frm = new frmManageGroups();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void ViewAndReportbutton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true; 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Batch frmb = new Batch();
            this.Visible = false;
            frmb.ShowDialog();
            this.Visible = true; 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RemoveFromGroup rfg = new RemoveFromGroup();
            this.Visible = false;
            rfg.ShowDialog();
            this.Visible = true; 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Pod pod = new Pod();
            pod.ShowDialog();
            this.Visible = true;
        }

        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    RemoveFromGroup rfg = new RemoveFromGroup();
        //    this.Visible = false;
        //    rfg.ShowDialog();
        //    this.Visible = true; ;
        //}       
    }
}
