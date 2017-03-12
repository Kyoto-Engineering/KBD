using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.UI;


namespace PhonebookApp
{
    public partial class frm1 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string categoryId,jobTitleId,companyId,specializationId,professionId,ageGroupId,educationLevelId,highestDegreeId,relationshipId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public int currentPersonId, affectedRows1,affectedRows2, bankEmailId;
        public string  nUserId;
        public frm1()
        {
            InitializeComponent();
        }

       

       // Regex emailValidation = new Regex((@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"));

       // Regex mobileNoValidation = new Regex(@"^(?:\+88|01)?\d{11}$");
        private void WASameAsRA(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into " + tableName + "(PersonsId,PostOfficeId,WFlatNo,WHouseNo,WRoadNo,WBlock,WArea,WContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qry);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", currentPersonId);
            cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(postofficeIdRA) ? (object)DBNull.Value : postofficeIdRA));
            cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text));
            cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text));
            cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text));                           
            affectedRows2 = (int)cmd.ExecuteScalar();
            con.Close();
        }
        private void SaveWorkingAddress(string tblName1)
        {
            string tableName = tblName1;

            if (tableName == "ResidentialAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PersonsId,PostOfficeId,RFlatNo,RHouseNo,RRoadNo,RBlock,RArea,RContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", currentPersonId);
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(postofficeIdRA) ? (object)DBNull.Value : postofficeIdRA));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text));                
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
            else if (tableName == "WorkingAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PersonsId,PostOfficeId,WFlatNo,WHouseNo,WRoadNo,WBlock,WArea,WContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", currentPersonId);
                cmd.Parameters.Add(new SqlParameter("@d2",string.IsNullOrEmpty(postofficeIdWA) ? (object)DBNull.Value : postofficeIdWA));
                cmd.Parameters.Add(new SqlParameter("@d3",string.IsNullOrEmpty(txtWAFlatName.Text) ? (object)DBNull.Value : txtWAFlatName.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",string.IsNullOrEmpty(txtWAHouseName.Text) ? (object)DBNull.Value : txtWAHouseName.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",string.IsNullOrEmpty(txtWARoadNo.Text) ? (object)DBNull.Value : txtWARoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",string.IsNullOrEmpty(txtWABlock.Text) ? (object)DBNull.Value : txtWABlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",string.IsNullOrEmpty(txtWAArea.Text) ? (object)DBNull.Value : txtWAArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d8",string.IsNullOrEmpty(txtWAContactNo.Text) ? (object)DBNull.Value : txtWAContactNo.Text));               
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
           
           
        }
        public void ResetResidentialAddress()
        {
            txtRAFlatNo.Clear();
            txtRAHouseNo.Clear();
            txtRARoadNo.Clear();
            txtRABlock.Clear();
            txtRAArea.Clear();
            txtRAContactNo.Clear();
            txtRAPostCode.Clear();
            cmbRAPost.SelectedIndex = -1;
            cmbRAThana.SelectedIndex = -1;
            cmbRADistrict.SelectedIndex = -1;
            cmbRADivision.SelectedIndex = -1;


        }
        public void ResetWorkingAddress()
        {
            txtWAFlatName.Clear();
            txtWAHouseName.Clear();
            txtWARoadNo.Clear();
            txtWABlock.Clear();
            txtWAArea.Clear();
            txtWAContactNo.Clear();
            txtWAPostCode.Clear();
            cmbWAPost.SelectedIndex = -1;
            cmbWAThana.SelectedIndex = -1;
            cmbWADistrict.SelectedIndex = -1;
            cmbWADivision.SelectedIndex = -1;

        }
        private void Reset()
        {
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            cmbCompanyName.SelectedIndex = -1;
            cmbCategoryName.SelectedIndex = -1;
            cmbAgeGroup.SelectedIndex = -1;
            cmbProfession.SelectedIndex = -1;
            cmbEducationalLevel.SelectedIndex = -1;
            cmbHighestDegree.SelectedIndex = -1;
            cmbJobTitle.SelectedIndex = -1;
            cmbSpecialization.SelectedIndex = -1;
            cmbRelationShip.SelectedIndex = -1;
            txtWebsite.Clear();
            txtSkypeId.Clear();

            ResetResidentialAddress();
            ResetWorkingAddress();

        }

        private void SavePersonDetails()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String query = "insert into Persons(PersonName,NickName,FatherName,EmailBankId,CompanyId,JobTitleId,CategoryId,SpecializationsId,ProfessionId,EducationLevelId,HighestDegreeOfELId,AgeGroupId,RelationShip,Website,InternetCall) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d1", txtPersonName.Text);
            cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(textNickName.Text) ? (object)DBNull.Value : textNickName.Text));
            cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text));
            cmd.Parameters.AddWithValue("@d4", bankEmailId);
            cmd.Parameters.AddWithValue("@d5", Convert.ToInt32(companyId));
            cmd.Parameters.AddWithValue("@d6", Convert.ToInt32(jobTitleId));
            cmd.Parameters.AddWithValue("@d7", Convert.ToInt32(categoryId));
            cmd.Parameters.AddWithValue("@d8", Convert.ToInt32(specializationId));
            cmd.Parameters.AddWithValue("@d9", Convert.ToInt32(professionId));
            cmd.Parameters.AddWithValue("@d10", Convert.ToInt32(educationLevelId));
            cmd.Parameters.AddWithValue("@d11", Convert.ToInt32(highestDegreeId));
            cmd.Parameters.AddWithValue("@d12", Convert.ToInt32(ageGroupId));
            cmd.Parameters.AddWithValue("@d13", Convert.ToInt32(relationshipId));
            cmd.Parameters.Add(new SqlParameter("@d14", string.IsNullOrEmpty(txtWebsite.Text) ? (object)DBNull.Value : txtWebsite.Text));
            cmd.Parameters.Add(new SqlParameter("@d15", string.IsNullOrEmpty(txtSkypeId.Text) ? (object)DBNull.Value : txtSkypeId.Text));
            currentPersonId = (int)cmd.ExecuteScalar();
            con.Close();             
                       
        }
        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonName.Text))
            {
                MessageBox.Show("Please Enter Person Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (unKnownRA.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbRADivision.Text))
                {
                    MessageBox.Show("Please select Residential Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbRADistrict.Text))
                {
                    MessageBox.Show("Please Select Residential Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbRAThana.Text))
                {
                    MessageBox.Show("Please select Residential Address Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbRAPost.Text))
                {
                    MessageBox.Show("Please Select Residential Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtRAPostCode.Text))
                {
                    MessageBox.Show("Please select Residential Address Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }           
            }
            if (unKnownCheckBox.Checked == false && sameAsRACheckBox.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbWADivision.Text))
                {
                    MessageBox.Show("Please select Working Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbWADistrict.Text))
                {
                    MessageBox.Show("Please Select Working Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbWAThana.Text))
                {
                    MessageBox.Show("Please select Working Address Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbWAPost.Text))
                {
                    MessageBox.Show("Please Select Working Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtWAPostCode.Text))
                {
                    MessageBox.Show("Please select Working Address Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             }
           
                    try
                    {
                        //1.Residential Address Applicable  & Working Address not Applicable
                        if (unKnownCheckBox.Checked)
                        {
                            SavePersonDetails();
                            SaveWorkingAddress("ResidentialAddresses");
                        }
                        //2.Residential Address Applicable  & Working Address Same as  Corporate Address                                        
                        if (sameAsRACheckBox.Checked)
                        {
                            SavePersonDetails();
                            SaveWorkingAddress("ResidentialAddresses");
                            WASameAsRA("WorkingAddresses");

                        }
                        //3.Residential Address Applicable  & Working Address  Applicable
                        if (sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
                        {
                            SavePersonDetails();
                            SaveWorkingAddress("ResidentialAddresses");
                            SaveWorkingAddress("WorkingAddresses");
                        }                      
                        MessageBox.Show("Saved successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
               
          

           

        }

      
       

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cmbSpecialization_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cmbProfession_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cmbEducationalLevel_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cmbHighestDegree_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cmbAgeGroup_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btnAddC_Click(object sender, EventArgs e)
        {            
            this.Hide();
            frmCategory frm=new frmCategory();
             frm.Show();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cmbCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
        public void FillJobTitle()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(JobTitle.JobTitleName) from JobTitle  order by JobTitle.JobTitleId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbJobTitle.Items.Add(rdr[0]);
                }
                cmbJobTitle.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillCategory()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Category.CategoryName) from Category  order by Category.CategoryId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCategoryName.Items.Add(rdr[0]);
                }
                cmbCategoryName.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillAgeGroup()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(AgeGroup.AgeGroupLevel) from AgeGroup  order by AgeGroup.AgeGroupId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbAgeGroup.Items.Add(rdr[0]);
                }
                cmbAgeGroup.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillHighestDegree()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(EducationLevel.EducationLevelName) from EducationLevel  order by EducationLevel.EducationLevelId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbHighestDegree.Items.Add(rdr[0]);
                }
                cmbHighestDegree.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillEducationLevel()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(EducationLevel.EducationLevelName) from EducationLevel  order by EducationLevel.EducationLevelId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbEducationalLevel.Items.Add(rdr[0]);
                }
                cmbEducationalLevel.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillCompanyName()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Company.CompanyName) from Company  order by Company.CompanyId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCompanyName.Items.Add(rdr[0]);
                }
                cmbCompanyName.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillProfession()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Profession.ProfessionName) from Profession  order by Profession.ProfessionId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbProfession.Items.Add(rdr[0]);
                }
                cmbProfession.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSpecialization()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Specializations.Specialization) from Specializations  order by Specializations.SpecializationsId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSpecialization.Items.Add(rdr[0]);
                }
                cmbSpecialization.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillRADivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRADivision.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillWADivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWADivision.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FilStar()
        {
            label37.Visible = true;
            label35.Visible = true;
            label40.Visible = true;
            label39.Visible = true;
            label45.Visible = true;
        }

        private void ResetStar()
        {
            label37.Visible = false;
            label35.Visible = false;
            label40.Visible = false;
            label39.Visible = false;
            label45.Visible = false;
        }
        private void frm1_Load(object sender, EventArgs e)
        {
            FillRelationShip();
            FillJobTitle();
            FillAgeGroup();
            FillCompanyName();
            FillEducationLevel();
            FillHighestDegree();
            FillProfession();
            FillSpecialization();
            EmailAddress();
            nUserId = frmLogin.uId.ToString();
            FillCategory();
            FillWADivisionCombo();
            FillRADivisionCombo();
        }

        private void cmbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void personDetailsButton_Click(object sender, EventArgs e)
        {
           
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI  frm=new MainUI();
            frm.Show();
        }

        private void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
           
        }

        private void cmbCategoryName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (cmbCategoryName.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Category  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbCategoryName.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select CategoryName from Category where CategoryName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Category  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbCategoryName.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Category(CategoryName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbCategoryName.Items.Clear();
                            FillCategory();
                            cmbCategoryName.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(CategoryId) from Category  where  Category.CategoryName='" + cmbCategoryName.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        categoryId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbRADistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbRADistrict.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRADistrict.Text = cmbRADistrict.Text.Trim();
                cmbRAThana.SelectedIndex = -1;
                cmbRAThana.Items.Clear();                
                cmbRAPost.SelectedIndex = -1;
                cmbRAPost.Items.Clear();
                cmbRAThana.Enabled = true;
                cmbRAThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdRA + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRAThana.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbRADivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRADivision.Text = cmbRADivision.Text.Trim();                
                cmbRADistrict.SelectedIndex=-1;
                cmbRADistrict.Items.Clear();
                cmbRAThana.SelectedIndex = -1;
                cmbRAThana.Items.Clear();
                cmbRAPost.SelectedIndex = -1;
                cmbRAPost.Items.Clear();
                txtRAPostCode.Clear();
                cmbRADistrict.Enabled = true;
                cmbRADistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdRA + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRADistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbRAThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRAThana.Text = cmbRAThana.Text.Trim();
                cmbRAPost.Items.Clear();
                cmbRAPost.SelectedIndex=-1;
                cmbRAPost.Items.Clear();
                cmbRAPost.Enabled = true;
                cmbRAPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdRA + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRAPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRAPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbRAPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdRA = (rdr.GetString(0));
                    txtRAPostCode.Text = (rdr.GetString(1));

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

        private void cmbWADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbWADivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdWA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbWADivision.Text = cmbWADivision.Text.Trim();                
                cmbWADistrict.SelectedIndex=-1;
                cmbWADistrict.Items.Clear();
                cmbWAThana.SelectedIndex = -1;
                cmbWAThana.Items.Clear();
                cmbWAPost.Items.Clear();
                cmbWAPost.SelectedIndex = -1;               
                txtWAPostCode.Clear();
                cmbWADistrict.Enabled = true;
                cmbWADistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdWA + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWADistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWADistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbWADistrict.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    districtIdWA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbWADistrict.Text = cmbWADistrict.Text.Trim();
                cmbWAThana.SelectedIndex = -1;
                cmbWAThana.Items.Clear();                
                cmbWAPost.SelectedIndex = -1;
                cmbWAPost.Items.Clear();  
                txtWAPostCode.Clear();
                cmbWAThana.Enabled = true;
                cmbWAThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdWA + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWAThana.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbWAThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdWA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbWAThana.Text = cmbWAThana.Text.Trim();
                cmbWAPost.SelectedIndex = -1;
                cmbWAPost.Items.Clear();               
                txtWAPostCode.Clear();
                cmbWAPost.Enabled = true;
                cmbWAPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdWA + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWAPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWAPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbWAPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdWA = (rdr.GetString(0));
                    txtWAPostCode.Text = (rdr.GetString(1));

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
        private void FillRelationShip()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select RelationShip from RelationShips";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbRelationShip.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbRelationShip.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EmailAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Email from EmailBank";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmailAddress.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbEmailAddress.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailAddress.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Mode Of Conduct  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEmailAddress.SelectedIndex = -1;
                }

                else
                {

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string emailId = input.Trim();
                        Regex mRegxExpression;

                        mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                        if (!mRegxExpression.IsMatch(emailId))
                        {

                            MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }


                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Email from EmailBank where Email='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Email  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailAddress.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (Email, UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbEmailAddress.Items.Clear();
                            EmailAddress();
                            cmbEmailAddress.SelectedText = input;
 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT EmailBankId from EmailBank WHERE Email= '" + cmbEmailAddress.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        bankEmailId = rdr.GetInt32(0);
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
        }

        private void cmbWADivision_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbCompanyName.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Company Name  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbCompanyName.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select CompanyName from Company where CompanyName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Company Name  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbCompanyName.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Company (CompanyName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);                           
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbCompanyName.Items.Clear();
                            FillCompanyName();
                            cmbCompanyName.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(CompanyId) from Company  where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        companyId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSpecialization.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Specialization  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbSpecialization.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Specialization from Specializations where Specialization='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Specializations  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbSpecialization.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Specializations(Specialization) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbSpecialization.Items.Clear();
                            FillSpecialization();
                            cmbSpecialization.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(SpecializationsId) from Specializations  where  Specializations.Specialization='" + cmbSpecialization.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        specializationId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbProfession.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Profession  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbProfession.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select ProfessionName from Profession where ProfessionName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Profession  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbProfession.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Profession(ProfessionName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbProfession.Items.Clear();
                            FillProfession();
                            cmbProfession.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(ProfessionId) from Profession  where  Profession.ProfessionName='" + cmbProfession.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        professionId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbEducationalLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbEducationalLevel.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input EducationLevel  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEducationalLevel.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select EducationLevelName from EducationLevel where EducationLevelName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This EducationLevel  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEducationalLevel.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EducationLevel(EducationLevelName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbEducationalLevel.Items.Clear();
                            FillEducationLevel();
                            cmbEducationalLevel.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(EducationLevelId) from EducationLevel  where  EducationLevel.EducationLevelName='" + cmbEducationalLevel.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        educationLevelId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbHighestDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(EducationLevelId) from EducationLevel  where  EducationLevel.EducationLevelName='" + cmbHighestDegree.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    highestDegreeId = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAgeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbAgeGroup.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input EducationLevel  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbAgeGroup.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AgeGroupLevel from AgeGroup where AgeGroupLevel='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This AgeGroup  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbAgeGroup.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into AgeGroup(AgeGroupLevel) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbAgeGroup.Items.Clear();
                            FillAgeGroup();
                            cmbAgeGroup.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(AgeGroupId) from AgeGroup  where  AgeGroup.AgeGroupLevel='" + cmbAgeGroup.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ageGroupId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbJobTitle.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input JobTitle  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbJobTitle.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select JobTitleName from JobTitle where JobTitleName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This JobTitle  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbJobTitle.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into JobTitle(JobTitleName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbJobTitle.Items.Clear();
                            FillJobTitle();
                            cmbJobTitle.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(JobTitleId) from JobTitle  where  JobTitle.JobTitleName='" + cmbJobTitle.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        jobTitleId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtRAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtWAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void cmbRelationShip_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbRelationShip.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input RelationShips  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbRelationShip.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select RelationShip from RelationShips where RelationShip='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This RelationShips  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbRelationShip.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into RelationShips(RelationShip) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbRelationShip.Items.Clear();
                            FillRelationShip();
                            cmbRelationShip.SelectedText = input;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(RelationShipsId) from  RelationShips  where  RelationShips.RelationShip='" + cmbRelationShip.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        relationshipId = (rdr.GetString(0));
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void unKnownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownCheckBox.Checked)
            {

                if (sameAsRACheckBox.Checked)
                {
                    sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
                    sameAsRACheckBox.Checked = false;
                    sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;
                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }

            }
            else
            {
                if (sameAsRACheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetWorkingAddress();
                    FilStar();
                }
            }
        }

        private void sameAsRACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sameAsRACheckBox.Checked)
            {

                if (unKnownCheckBox.Checked)
                {
                    unKnownCheckBox.CheckedChanged -= unKnownCheckBox_CheckedChanged;
                    unKnownCheckBox.Checked = false;
                    unKnownCheckBox.CheckedChanged += unKnownCheckBox_CheckedChanged;
                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }

            }
            else
            {
                if (unKnownCheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetWorkingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetWorkingAddress();
                   FilStar();
                }
            }
        }

        private void FillStar2()
        {
            label32.Visible = true;
            label33.Visible = true;
            label34.Visible = true;
            label42.Visible = true;
            label44.Visible = true;
        }
        private void Reset2Star()
        {
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label42.Visible = false;
            label44.Visible = false;
        }
        private void unKnownRA_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownRA.Checked == true)
            {
                Reset2Star();
                groupBox5.Enabled = false;
                ResetResidentialAddress();
                sameAsRACheckBox.Visible = false;

            }
            else
            {
                sameAsRACheckBox.Visible = true;
                groupBox5.Enabled = true;
                groupBox5.Enabled = true;
                FillStar2();
            }
        }

        private void cmbRADistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbRADistrict.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRADistrict.Text = cmbRADistrict.Text.Trim();                
                cmbRAThana.SelectedIndex = -1;
                cmbRAThana.Items.Clear();
                cmbRAPost.SelectedIndex = -1;
                cmbRAPost.Items.Clear();
                txtRAPostCode.Clear();
                cmbRAThana.Enabled = true;
                cmbRAThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdRA + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRAThana.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRAThana_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbRAThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRAThana.Text = cmbRAThana.Text.Trim();               
                cmbRAPost.SelectedIndex=-1;
                cmbRAPost.Items.Clear();
                txtRAPostCode.Clear();
                cmbRAPost.Enabled = true;
                cmbRAPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdRA + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRAPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRAPost_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbRAPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdRA = (rdr.GetString(0));
                    txtRAPostCode.Text = (rdr.GetString(1));

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

        private void cmbWADivision_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbWADivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdWA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbWADivision.Text = cmbWADivision.Text.Trim();                
                cmbWADistrict.SelectedIndex=-1;
                cmbWADistrict.Items.Clear();
                cmbWAThana.SelectedIndex = -1;
                cmbWAThana.Items.Clear();
                cmbWAPost.SelectedIndex = -1;
                cmbWAPost.Items.Clear();
                txtWAPostCode.Clear();
                cmbWADistrict.Enabled = true;
                cmbWADistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdWA + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWADistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRADivision_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbRADivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdRA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbRADivision.Text = cmbRADivision.Text.Trim();              
                cmbRADistrict.SelectedIndex=-1;
                cmbRADistrict.Items.Clear();
                cmbRAThana.SelectedIndex = -1;
                cmbWAThana.Items.Clear();
                cmbRAPost.SelectedIndex = -1;
                cmbRAPost.Items.Clear();
                txtRAPostCode.Clear();
                cmbRADistrict.Enabled = true;
                cmbRADistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdRA + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbRADistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWADistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbWADistrict.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    districtIdWA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbWADistrict.Text = cmbWADistrict.Text.Trim();               
                cmbWAThana.SelectedIndex=-1;
                cmbWAThana.Items.Clear();
                cmbWAPost.SelectedIndex = -1;
                cmbWAPost.Items.Clear();
                txtWAPostCode.Clear();
                cmbWAThana.Enabled = true;
                cmbWAThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdWA + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWAThana.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWAThana_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbWAThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdWA = (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbWAThana.Text = cmbWAThana.Text.Trim();                                
                cmbWAPost.Items.Clear();
                cmbWAPost.SelectedIndex = -1;
                txtWAPostCode.Clear();
                cmbWAPost.Enabled = true;
                cmbWAPost.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdWA + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbWAPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbWAPost_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbWAPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdWA = (rdr.GetString(0));
                    txtWAPostCode.Text = (rdr.GetString(1));

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

       
           
       

    }
}

