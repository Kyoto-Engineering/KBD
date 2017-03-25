using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.DbGateway;

namespace PhonebookApp.UI
{
    public partial class PersonDetail : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private SqlDataAdapter sda;

        public PersonDetail()
        {
            InitializeComponent();
        }

       
        private void PersonDetail_Load(object sender, EventArgs e)
        {
            FillPersonDetailsGrid();

        }
        private void FillPersonDetailsGrid()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            sda = new SqlDataAdapter("SELECT Persons.PersonName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId  INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
          
            con.Close();
        }
        private void PersonDetailsShow()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select RTRIM(Person.PersonName) PersonName,RTRIM(Person.Email) EmailAddress,RTRIM(Person.ContactNo) ContactNo,RTRIM(Person.Specialization) Specialization,RTRIM(Person.Profession) Profession,RTRIM(Person.EducationalLevel) EducationalLevel,RTRIM(Person.HighestDegree) HighestDegree,RTRIM(Person.AgeGroup) AgeGroup,RTRIM(Person.Company) Company,RTRIM(Category.CategoryName) CategoryName  from Person,Category  where Person.CategoryId=Category.CategoryId order by Person.PersonId  desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3],rdr[4],rdr[5],rdr[6],rdr[7],rdr[8],rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void PersonDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmPersonUpdate frm = new frmPersonUpdate();
                frm.Show();

                frm.txtPersonId.Text = dr.Cells[0].Value.ToString();
                frm.txtPersonName.Text = dr.Cells[1].Value.ToString();
                frm.txtEmail.Text = dr.Cells[2].Value.ToString();
                frm.txtMobile.Text = dr.Cells[3].Value.ToString();
                frm.cmbSpecialization.Text = dr.Cells[4].Value.ToString();

                frm.cmbProfession.Text = dr.Cells[5].Value.ToString();
                frm.cmbEducationalLevel.Text = dr.Cells[6].Value.ToString();
                frm.cmbHighestDegree.Text = dr.Cells[7].Value.ToString();


                frm.txtCompany.Text = dr.Cells[8].Value.ToString();

                frm.cmbCategoryName.Text = dr.Cells[9].Value.ToString();
                frm.cmbAgeGroup.Text = dr.Cells[10].Value.ToString();

                frm.h.Text = lk.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
