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
using System.Windows.Forms.VisualStyles;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using PhonebookApp.Reports;

namespace PhonebookApp.UI
{
    public partial class Group : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public int groupid, personid, companyid;
        public string user_id;
        public List<Item> items=new List<Item>();
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
                SqlDataAdapter sda = new SqlDataAdapter(
                    "SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName, Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel, convert(varchar, Persons.DateOfBirth,101) As DateOfBirth, Religion.ReligionName, MaritalStatus.MaritalStatusName,convert(varchar, Persons.MarriageAnniversaryDate,101) As MarriageAnniversaryDate, Company.CompanyId FROM Persons LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId",
                    con);
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
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }



        private void addbutton_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            if (string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
            {
                MessageBox.Show(@"Please select Group Name!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please Select Row!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                LoadGroupId();

                for (int i = 0; i <= dataGridView.SelectedRows.Count - 1; i++)
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

                        MessageBox.Show("Person Id: " + personid + " Already Exists in this Group", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        GroupNamecomboBox.SelectedIndex = -1;

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                
                try
                {
                    //for (int i = 0; i <= dataGridView.SelectedRows.Count - 1; i++)
                    //{
                    DataGridViewRow dr = dataGridView.SelectedRows[0];
                    personid = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
                    //ListViewItem item = ListView.FindItemWithText(personid.ToString());
                    if (listView.Items.Count == 0)
                    {
                        Item x = new Item();
                        ListViewItem lst = new ListViewItem();
                        x.PersonId= lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[13].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst.SubItems.Add(x.GroupId = groupid.ToString());
                        items.Add(x);
                        listView.Items.Add(lst);
                    }
                  
                   

                    //foreach(ListViewItem item in listView.Items)
                    //{
                    //    // HashSet.Add() returns false if it already contains the key.
                    //     {}
                    //    duplicates.Add(item);
                    //}

                  

                    else 
                    {
                        Item x = new Item();
                        ListViewItem lst1 = new ListViewItem();
                        x.PersonId=lst1.Text = dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[13].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst1.SubItems.Add(x.GroupId = groupid.ToString());
                        if (GetValue(x))
                        {
                            listView.Items.Add(lst1);
                            items.Add(x);
                        }
                        else
                        {
                            MessageBox.Show("You Can Not Add Same Person in Same Group More than one times", "error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                       
                    }
                }
            
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }

        private bool GetValue(Item x)
        {
            bool xz = true;
            foreach (Item z in items)
            {
                if (z.GroupId == x.GroupId && z.PersonId == x.PersonId)
                {
                    xz = false;

                    break;
                }
            }
            return xz;
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
                //LoadGroupId();
                try
                {
                //    for (int i = 0; i <= listView.Items.Count - 1; i++)
                //    {
                //        con = new SqlConnection(cs.DBConn);
                //        con.Open();
                //        string ct = "select PersonsId from GroupMember where GroupId='" + groupid +
                //                    "' AND PersonsId='" + personid + "'";
                //        cmd = new SqlCommand(ct);
                //        cmd.Connection = con;
                //        rdr = cmd.ExecuteReader();

                //        if (rdr.Read())
                //        {

                //            MessageBox.Show("Person Id: "+ personid +" Already Exists in this Group", "Error", MessageBoxButtons.OK,
                //                MessageBoxIcon.Error);
                //            GroupNamecomboBox.SelectedIndex = -1;

                //            if ((rdr != null))
                //            {
                //                rdr.Close();
                //            }
                //            return;
                //        }
                //    }
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

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            
            //richTextBox1.Clear();
            //richTextBox2.Clear();
            personid = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
            companyid = Convert.ToInt32(string.IsNullOrEmpty(dataGridView.CurrentRow.Cells[13].Value.ToString()));

            DataGridViewRow dr = dataGridView.SelectedRows[0];
            if (string.IsNullOrEmpty(dr.Cells[0].Value.ToString()))
            {
                //richTextBox1.Text = "";
                groupBox2.Visible = false;
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select isnull(nullif(ResidentialAddresses.RFlatNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RHouseNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RRoadNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RBlock,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RArea,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RContactNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.LandMark,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Persons INNER JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId INNER JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID where Persons.PersonsId = '" + dr.Cells[0].Value.ToString() + "'";
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rdr.Read())
                    {
                        groupBox2.Visible = true;
                        richTextBox1.Text = rdr.GetString(0);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (string.IsNullOrEmpty(dr.Cells[13].Value.ToString()))
            {
                groupBox3.Visible = false;
                //richTextBox2.Text = "";
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select isnull(nullif(CorporateAddresses.CFlatNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CHouseNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CRoadNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CBlock,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CArea,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CLandmark,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CContactNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID where Company.CompanyId = '" + dr.Cells[13].Value.ToString() + "'";
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rdr.Read())
                    {
                        groupBox3.Visible = true;
                        richTextBox2.Text = rdr.GetString(0);
                    }
                   
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please Select a row from the list which you  want to remove", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
               
                   
                for (int i = listView.Items.Count - 1; i >= 0; i--)
                {
                    if (listView.Items[i].Selected)
                    {
                        foreach (Item zx in items)
                        {
                            if (zx.PersonId == listView.Items[i].SubItems[0].Text && zx.GroupId == listView.Items[i].SubItems[4].Text)
                            {
                                items.Remove(zx);
                                break;
                            }
                        }
                        listView.Items[i].Remove();
                    }
                }
            }
        }

        private void PersonSearchtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                //INNER Join Query
                //SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId  INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
                //Left Join Query
                SqlDataAdapter sda = new SqlDataAdapter(
                    "SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName, Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel, convert(varchar, Persons.DateOfBirth,101) As DateOfBirth, Religion.ReligionName, MaritalStatus.MaritalStatusName,convert(varchar, Persons.MarriageAnniversaryDate,101) As MarriageAnniversaryDate, Company.CompanyId FROM Persons LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId WHERE (Persons.PersonName LIKE '" + PersonSearchtextBox.Text + "%')",
                    con);
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

        private void CompanySearchtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                //INNER Join Query
                //SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId  INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
                //Left Join Query
                SqlDataAdapter sda = new SqlDataAdapter(
                    "SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName, Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel, convert(varchar, Persons.DateOfBirth,101) As DateOfBirth, Religion.ReligionName, MaritalStatus.MaritalStatusName,convert(varchar, Persons.MarriageAnniversaryDate,101) As MarriageAnniversaryDate, Company.CompanyId FROM Persons LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId WHERE (Company.CompanyName LIKE '" + CompanySearchtextBox.Text + "%')",
                    con);
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

        private void PersonSearchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CompanySearchtextBox.Clear();
        }

        private void CompanySearchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            PersonSearchtextBox.Clear();
        }

        private void A4SizeGroupAddressbutton_Click(object sender, EventArgs e)
        {
            ReportByGroupforA4 f2 = new ReportByGroupforA4();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void EidGreetingGroupAddressbutton_Click(object sender, EventArgs e)
        {
            ReportByGroupforEidGreeting f2 = new ReportByGroupforEidGreeting();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void EnvelopesizeGroupAddressbutton_Click(object sender, EventArgs e)
        {
            ReportByGroupforEnvelop f2 = new ReportByGroupforEnvelop();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;

        }
    }
}

