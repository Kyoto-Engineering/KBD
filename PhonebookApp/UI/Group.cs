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
    public partial class Group : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public int groupId, personid;
        
        public Group()
        {
            InitializeComponent();
        }

        private void FillPersonDetailsGrid()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId  INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Group_Load(object sender, EventArgs e)
        {
            FillPersonDetailsGrid();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {


            if (dataGridView.SelectedRows.Count > 0)
            {                
                try
                {
                    DataGridViewRow dr = dataGridView.SelectedRows[0];
                    int personid = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
                    if (listView.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();                        
                        lst.Text=dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst.SubItems.Add(dr.Cells[4].Value.ToString());
                        lst.SubItems.Add(dr.Cells[5].Value.ToString());
                        lst.SubItems.Add(dr.Cells[6].Value.ToString());
                        lst.SubItems.Add(dr.Cells[7].Value.ToString());
                        lst.SubItems.Add(dr.Cells[8].Value.ToString());
                        lst.SubItems.Add(dr.Cells[9].Value.ToString());
                        listView.Items.Add(lst);
                    }
                    //String csVal = txtProductId.Text;

                    else if (listView.FindItemWithText(personid.ToString()) == null)
                    {
                        ListViewItem lst1 = new ListViewItem();                       
                        lst1.Text=dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[5].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[6].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[7].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[8].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[9].Value.ToString());
                        listView.Items.Add(lst1);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is not any row selected, please select row and Click Add Button!");
            }
            
        }

        private void SaveGroup()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into [Group] (GroupName) values (@d1)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", groupNametextBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("Submitted successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(groupNametextBox.Text))
            {
                MessageBox.Show("Please enter Group Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveGroup();
                try
                { 
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "insert into [GroupMember] (GroupId,PersonsId) values (@d1,@d2)" + "SELECT CONVERT(int,SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d1", groupId);
                    cmd.Parameters.AddWithValue("@d2", personid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Submitted successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

