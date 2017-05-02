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
using PhonebookApp.LogInUI;

namespace PhonebookApp.UI
{
    public partial class Group : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public int groupid, personid;
        public string user_id;

        public Group()
        {
            InitializeComponent();
        }

        public void FillGroupName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(GroupName) from [dbo].[Group]  order by GroupId";
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

        public void LoadGroupId()
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
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FillPersonDetailsGrid()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                //INNER Join Query
                //SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId  INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
                //Left Join Query
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel, convert(varchar, Persons.DateOfBirth,101) As DateOfBirth, Religion.ReligionName, MaritalStatus.MaritalStatusName, convert(varchar, Persons.MarriageAnniversaryDate,101) As MarriageAnniversaryDate FROM Persons left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Category ON Persons.CategoryId = Category.CategoryId  left JOIN Company ON Persons.CompanyId = Company.CompanyId  left JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  left JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  left JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId left JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId left JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId left JOIN Religion ON Persons.ReligionId=Religion.ReligionId left JOIN MaritalStatus ON Persons.MaritalStatusId=MaritalStatus.MaritalStatusId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView.Rows.Add();
                    dataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView.Rows[n].Cells[7].Value = item[7].ToString();
                    dataGridView.Rows[n].Cells[8].Value = item[8].ToString();
                    dataGridView.Rows[n].Cells[9].Value = item[9].ToString();
                    dataGridView.Rows[n].Cells[10].Value = item[10].ToString();
                    dataGridView.Rows[n].Cells[11].Value = item[11].ToString();
                    dataGridView.Rows[n].Cells[12].Value = item[12].ToString();
                    dataGridView.Rows[n].Cells[13].Value = item[13].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Group_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            FillPersonDetailsGrid();
            FillGroupName();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i <= dataGridView.SelectedRows.Count - 1; i++)
                    {
                        DataGridViewRow dr = dataGridView.SelectedRows[0];
                        personid = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
                        if (listView.Items.Count == 0)
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.Text = dr.Cells[0].Value.ToString();
                            lst.SubItems.Add(dr.Cells[1].Value.ToString());
                            lst.SubItems.Add(dr.Cells[2].Value.ToString());
                            lst.SubItems.Add(dr.Cells[3].Value.ToString());
                            lst.SubItems.Add(dr.Cells[4].Value.ToString());
                            lst.SubItems.Add(dr.Cells[5].Value.ToString());
                            lst.SubItems.Add(dr.Cells[6].Value.ToString());
                            lst.SubItems.Add(dr.Cells[7].Value.ToString());
                            lst.SubItems.Add(dr.Cells[8].Value.ToString());
                            lst.SubItems.Add(dr.Cells[9].Value.ToString());
                            lst.SubItems.Add(dr.Cells[10].Value.ToString());
                            lst.SubItems.Add(dr.Cells[11].Value.ToString());
                            lst.SubItems.Add(dr.Cells[12].Value.ToString());
                            lst.SubItems.Add(dr.Cells[13].Value.ToString());
                            listView.Items.Add(lst);
                        }


                        else if (listView.FindItemWithText(personid.ToString()) == null)
                        {
                            ListViewItem lst1 = new ListViewItem();
                            lst1.Text = dr.Cells[0].Value.ToString();
                            lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[5].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[6].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[7].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[8].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[9].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[10].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[11].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[12].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[13].Value.ToString());
                            listView.Items.Add(lst1);
                        }

                        else
                        {
                            MessageBox.Show("You Can Not Add Same Item More than one times", "error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is no row selected, please select row and Click Add Button!");
            }

        }

        private void SaveInfo()
        {
            try
            {
                for (int i = 0; i <= listView.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "insert into GroupMember(GroupId,PersonsId,UserId) values(@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d1", groupid);
                    cmd.Parameters.AddWithValue("@d2", listView.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@d3", user_id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
            {
                MessageBox.Show("Please select Group Name!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else if ( listView.Items.Count == 0)
            {
                MessageBox.Show("Please Added to List First!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadGroupId();
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select PersonsId from GroupMember where GroupId='" + groupid +
                                "' AND PersonsId='" + personid + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        MessageBox.Show("This Group Member Already Exists in these Group", "Error", MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                        GroupNamecomboBox.SelectedIndex = -1;

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }

                    SaveInfo();

                    MessageBox.Show("Submitted Successfully", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    GroupNamecomboBox.SelectedIndex = -1;
                    listView.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Group_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void GroupNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

