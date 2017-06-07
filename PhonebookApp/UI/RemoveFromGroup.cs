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
    public partial class RemoveFromGroup : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public int groupid, personid;
        public RemoveFromGroup()
        {
            InitializeComponent();
        }

        private void RemoveFromGroup_Load(object sender, EventArgs e)
        {
            FillGroupName();
        }

        public void FillGroupName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(GroupName) from [dbo].[Group]  order by GroupName asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    GroupNamecomboBox.Items.Add(rdr[0]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT GroupId from [dbo].[Group] WHERE GroupName= '" + GroupNamecomboBox.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    groupid = rdr.GetInt32(0);
                }
                con.Close();
                //if ((rdr != null))
                //{
                //    rdr.Close();
                //}
                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand(
                    "SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName, Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName,  AgeGroup.AgeGroupLevel, Persons.DateOfBirth, Religion.ReligionName, MaritalStatus.MaritalStatusName, Persons.MarriageAnniversaryDate FROM Persons LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT JOIN  JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN  Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId RIGHT OUTER JOIN GroupMember ON Persons.PersonsId = GroupMember.PersonsId LEFT OUTER JOIN [Group] ON GroupMember.GroupId = [Group].GroupId  where [Group].GroupName='" + GroupNamecomboBox.Text + "' order by Persons.PersonName asc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11],rdr[12]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
