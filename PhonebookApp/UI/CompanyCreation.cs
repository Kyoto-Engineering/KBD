using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Reports;

namespace PhonebookApp.UI
{
    public partial class CompanyCreation : Form
    {
        private delegate void ChangeFocusDelegate(Control ctl);
        private int affectedRows1, currentClientId, affectedRows2, affectedRows3, affectedRows12;
        private SqlConnection con;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;
        private SqlCommand cmd;
        public string user_id, fullName, submittedBy, districtIdC, districtIdT, divisionIdC, divisionIdT, thanaIdC, thanaIdC2, thanaIdT, postofficeIdC, postOfficeIdT, userType1;
        public int companyid, companytypeid, clientTypeId, natureOfClientId, industryCategoryId, addressTypeId1, addressTypeId2, superviserId, bankEmailId, bankCPEmailId;
        public int cdistrict_id, tdistrict_id;
        public CompanyCreation()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void SaveCompany()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "insert into Company(CompanyName, UserId, DateAndTime,CompanyTypeId,IndustryCategoryId,NatureOfCompanyId) values(@d1,@d2,@d3,@d4,@d5,@d6)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d1", CompanyNameTextBox.Text);
            cmd.Parameters.AddWithValue("@d2", user_id);
            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d4", companytypeid);
            cmd.Parameters.AddWithValue("@d5", industryCategoryId);
            cmd.Parameters.AddWithValue("@d6", natureOfClientId);

           
            companyid = (int)cmd.ExecuteScalar();
            con.Close();
        }

        private void TASameAsCA(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into " + tableName + "(PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qry);
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
            cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));
            cmd.Parameters.AddWithValue("@d11", companyid);
            affectedRows2 = (int)cmd.ExecuteScalar();
            con.Close();
        }
        private void SaveCorporateORTraddingAddress(string tblName1)
        {
            string tableName = tblName1;
            if (tableName == "CorporateAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PostOfficeId,CFlatNo,CHouseNo,CRoadNo,CBlock,CArea,CContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));

                cmd.Parameters.AddWithValue("@d11", companyid);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
            else if (tableName == "TraddingAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string Qry = "insert into " + tableName + "(PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(Qry);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postOfficeIdT) ? (object)DBNull.Value : postOfficeIdT));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(tFlatNoTextBox.Text) ? (object)DBNull.Value : tFlatNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(tHouseNoTextBox.Text) ? (object)DBNull.Value : tHouseNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(tRoadNoTextBox.Text) ? (object)DBNull.Value : tRoadNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(FblocktextBox.Text) ? (object)DBNull.Value : FblocktextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(tAreaTextBox.Text) ? (object)DBNull.Value : tAreaTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(tContactNoTextBox.Text) ? (object)DBNull.Value : tContactNoTextBox.Text));
                cmd.Parameters.AddWithValue("@d11", companyid);
                affectedRows2 = (int)cmd.ExecuteScalar();
                con.Close();
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(CompanyNameTextBox.Text))
            {
                MessageBox.Show("Please Enter Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CompanyNameTextBox.Focus();
                return;
            }
             if (cmbCompanytype.Text == "")
            {
                MessageBox.Show("Please Select Company Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompanytype.Focus();
                return;
            }

             if (IndustryCategorycomboBox.Text == "")
            {
                MessageBox.Show("Please select Industry Category", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                IndustryCategorycomboBox.Focus();
                return;

            }
             if (cmbNatureOfClient.Text == "")
            {
                MessageBox.Show("Please select Nature of Business", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmbNatureOfClient.Focus();
                return;

            }

             if (cDivisionCombo.Text == "")
            {
                MessageBox.Show("Please Select Corporate Division", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cDivisionCombo.Focus();
                return;

            }
             if (cDistCombo.Text == "")
            {
                MessageBox.Show("Please Select Corporate District", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cDistCombo.Focus();
                return;

            }
             if (cThanaCombo.Text == "")
            {
                MessageBox.Show("Please Enter Corporate Thana", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cThanaCombo.Focus();
                return;

            }
             if (cPostOfficeCombo.Text == "")
            {
                MessageBox.Show("Please Enter Corporate PostOffice", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cPostOfficeCombo.Focus();
                return;

            }
             if (cPostCodeTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Corporate PostCode", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cPostCodeTextBox.Focus();
                return;

            }
            if ((notApplicableCheckBox.Checked == false) && (sameAsCorporatAddCheckBox.Checked == false))
            {
                if (string.IsNullOrWhiteSpace(tDivisionCombo.Text))
                {
                    MessageBox.Show("Please select factory division", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tDivisionCombo.Focus();
                    return;
                }
                 if (string.IsNullOrWhiteSpace(tDistrictCombo.Text))
                {
                    MessageBox.Show("Please Select factory district", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tDistrictCombo.Focus();
                    return;

                }
                 if (string.IsNullOrWhiteSpace(tThenaCombo.Text))
                {
                    MessageBox.Show("Please select factory Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tThenaCombo.Focus();
                    return;
                }
                 if (string.IsNullOrWhiteSpace(tPostCombo.Text))
                {
                    MessageBox.Show("Please Select factory Post Name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;

                }
                 if (string.IsNullOrWhiteSpace(tPostCodeTextBox.Text))
                 {
                     MessageBox.Show("Please select factory Post Code", "Error", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                     return;

                 }
            }
                        
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select CompanyName from Company where CompanyName='" + CompanyNameTextBox.Text +
                                    "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("This Company Name Already Exists in the List", "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            CompanyNameTextBox.Text = "";
                            CompanyNameTextBox.Focus();


                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            return;
                        }
                        //1.Corporate Address Applicable  & Tradding Address not Applicable
                        if (notApplicableCheckBox.Checked)
                        {
                            SaveCompany();
                            SaveCorporateORTraddingAddress("CorporateAddresses");
                        }
                        //2.Corporate Address Applicable  & Tradding Address Same as  Corporate Address                                        
                        if (sameAsCorporatAddCheckBox.Checked)
                        {
                            SaveCompany();
                            SaveCorporateORTraddingAddress("CorporateAddresses");
                            TASameAsCA("TraddingAddresses");

                        }
                        //3.Corporate Address Applicable  & Tradding Address  Applicable
                        if (sameAsCorporatAddCheckBox.Checked == false && notApplicableCheckBox.Checked == false)
                        {
                            SaveCompany();
                            SaveCorporateORTraddingAddress("CorporateAddresses");
                            SaveCorporateORTraddingAddress("TraddingAddresses");
                        }
                        
                        MessageBox.Show("Registration Completed Successfully",
                            "Record",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();

                    }
                    catch (FormatException formatException)
                    {
                        MessageBox.Show("Please Enter Input in Correct Format", formatException.Message);
                    }

            
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void getDataButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetTradingAddress()
        {

            tFlatNoTextBox.Clear();
            tHouseNoTextBox.Clear();
            tRoadNoTextBox.Clear();
            tAreaTextBox.Clear();
            FblocktextBox.Clear();
            tContactNoTextBox.Text = "";

            tPostCodeTextBox.Clear();
            tPostCombo.SelectedIndex = -1;
            tThenaCombo.SelectedIndex = -1;
            tDistrictCombo.SelectedIndex = -1;
            tDivisionCombo.SelectedIndex = -1;




        }
        private void FilStar()
        {
            label47.Visible = true;
            label36.Visible = true;
            label40.Visible = true;
            label35.Visible = true;
            label45.Visible = true;
        }

        private void ResetStar()
        {
            label47.Visible = false;
            label36.Visible = false;
            label40.Visible = false;
            label35.Visible = false;
            label45.Visible = false;
        }

        private void Reset()
        {

            cmbCompanytype.SelectedIndex = -1;
            cmbNatureOfClient.SelectedIndex = -1;
           
            IndustryCategorycomboBox.SelectedIndex = -1;
            
            CompanyNameTextBox.Clear();
           


            cFlatNoTextBox.Clear();
            cHouseNoTextBox.Clear();
            cRoadNoTextBox.Clear();
            blocktextBox.Clear();
            cAreaTextBox.Clear();
            cContactNoTextBox.Clear();



            cPostCodeTextBox.Clear();
            cPostOfficeCombo.SelectedIndex = -1;
            cThanaCombo.SelectedIndex = -1;
            cDistCombo.SelectedIndex = -1;
            cDivisionCombo.SelectedIndex = -1;


            notApplicableCheckBox.CheckedChanged -= NotApplicableCheckBox_CheckedChanged;
            notApplicableCheckBox.Checked = false;
            notApplicableCheckBox.CheckedChanged += NotApplicableCheckBox_CheckedChanged;

            sameAsCorporatAddCheckBox.CheckedChanged -= sameAsCorporatAddCheckBox_CheckedChanged;
            sameAsCorporatAddCheckBox.Checked = false;
            sameAsCorporatAddCheckBox.CheckedChanged += sameAsCorporatAddCheckBox_CheckedChanged;
            if ((notApplicableCheckBox.Checked == false) && (sameAsCorporatAddCheckBox.Checked == false))
            {
                ResetTradingAddress();
            }



           
            saveButton.Enabled = true;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Reset();

        }

       
      

       
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cellNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}


            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void cPostCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            // (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void tPostCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        public void FillNatureOfClient()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(CompanyNature) from NatureOfCompanies order by NatureOfCompanyId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbNatureOfClient.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        public void FillIndustryCategory()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(IndustryCategory) from IndustryCategorys order by IndustryCategoryId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    IndustryCategorycomboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillCDivisionCombo()
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
                    cDivisionCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillTDivisionCombo()
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
                    tDivisionCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
        private void ClientRegistrationForm_Load(object sender, EventArgs e)
        {
            //userType1 = LoginForm.userType;
            //submittedBy = LoginForm.uId.ToString();


            user_id = frmLogin.uId.ToString();

            FillCompanyType();
            FillNatureOfClient();
            FillIndustryCategory();

            FillCDivisionCombo();
            FillTDivisionCombo();

            cDistCombo.Enabled = false;
            cThanaCombo.Enabled = false;
            cPostOfficeCombo.Enabled = false;

            tDistrictCombo.Enabled = false;
            tThenaCombo.Enabled = false;
            tPostCombo.Enabled = false;

        }


        private void FillCompanyType()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cta = "select CompanyTypeName from CompanyType order by CompanyTypeName asc";
                cmd = new SqlCommand(cta);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCompanytype.Items.Add(rdr.GetValue(0).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cDistCombo_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cDistCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdC = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cDistCombo.Text = cDistCombo.Text.Trim();
                cThanaCombo.Items.Clear();
                cThanaCombo.ResetText();
                cPostOfficeCombo.Items.Clear();
                cPostOfficeCombo.ResetText();
                cPostOfficeCombo.SelectedIndex = -1;
                cPostOfficeCombo.Enabled = false;
                cPostCodeTextBox.Clear();
                cThanaCombo.Enabled = true;
                cThanaCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdC + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cThanaCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tDistrictCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = tDistrictCombo.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    districtIdT = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                tDistrictCombo.Text = cDistCombo.Text.Trim();
                tThenaCombo.Items.Clear();
                tThenaCombo.ResetText();
                tPostCombo.Items.Clear();
                tPostCombo.ResetText();
                tPostCombo.SelectedIndex = -1;
                tPostCombo.Enabled = false;
                tPostCodeTextBox.Clear();
                tThenaCombo.Enabled = true;
                tPostCombo.Focus();

                //tDistrictCombo.Text = tDistrictCombo.Text.Trim();
                //tThenaCombo.Items.Clear();
                //tThenaCombo.Text = "";
                //tPostCombo.SelectedIndex = -1;
                //tPostCodeTextBox.Clear();
                //tThenaCombo.Enabled = true;
                //tThenaCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdT + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tThenaCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

      

      

        private void sameAsCorporatAddCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sameAsCorporatAddCheckBox.Checked)
            {

                if (notApplicableCheckBox.Checked)
                {
                    notApplicableCheckBox.CheckedChanged -= NotApplicableCheckBox_CheckedChanged;
                    notApplicableCheckBox.Checked = false;
                    notApplicableCheckBox.CheckedChanged += NotApplicableCheckBox_CheckedChanged;
                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }

            }
            else
            {
                if (notApplicableCheckBox.Checked)
                {
                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox3.Enabled = true;
                    ResetTradingAddress();
                    FilStar();
                }
            }

        }

        private void cDivisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            cDistCombo.Items.Clear();
            cDistCombo.ResetText();
            cThanaCombo.Items.Clear();
            cThanaCombo.ResetText();
            cPostOfficeCombo.Items.Clear();
            cPostOfficeCombo.ResetText();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT RTRIM(Divisions.Division_ID) from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cDivisionCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdC = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cDivisionCombo.Text = cDivisionCombo.Text.Trim();
                cDistCombo.Items.Clear();
                cDistCombo.ResetText();
                cThanaCombo.Items.Clear();
                cThanaCombo.ResetText();
                cThanaCombo.SelectedIndex = -1;
                cPostOfficeCombo.Items.Clear();
                cPostOfficeCombo.ResetText();
                cPostOfficeCombo.SelectedIndex = -1;
                cPostCodeTextBox.Clear();
                cDistCombo.Enabled = true;
                cDistCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdC + "'  order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cDistCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cThanaCombo.Enabled = false;
            cPostOfficeCombo.Enabled = false;
        }

        private void cThanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select D_ID from Districts WHERE District= '" + cDistCombo.Text + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                cdistrict_id = rdr.GetInt32(0);
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + cdistrict_id + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cThanaCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdC = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cThanaCombo.Text = cThanaCombo.Text.Trim();
                cPostOfficeCombo.Items.Clear();
                cPostOfficeCombo.ResetText();
                // cPostOfficeCombo.Text = "";
                cPostCodeTextBox.Clear();
                cPostOfficeCombo.Enabled = true;
                cPostOfficeCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdC + "' order by PostOffice.T_ID desc";
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdC + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cPostOfficeCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cPostOfficeCombo.SelectedIndex = -1;
        }

        private void cPostOfficeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cPostOfficeCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdC = (rdr.GetString(0));
                    cPostCodeTextBox.Text = (rdr.GetString(1));

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

        private void tDivisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tDistrictCombo.Items.Clear();
            tDistrictCombo.ResetText();
            tThenaCombo.Items.Clear();
            tThenaCombo.ResetText();
            tPostCombo.Items.Clear();
            tPostCombo.ResetText();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = tDivisionCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdT = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                tDivisionCombo.Text = tDivisionCombo.Text.Trim();
                tDistrictCombo.Items.Clear();
                tDistrictCombo.ResetText();
                tThenaCombo.Items.Clear();
                tThenaCombo.ResetText();
                tThenaCombo.SelectedIndex = -1;
                tPostCombo.Items.Clear();
                tPostCombo.ResetText();
                tPostCombo.SelectedIndex = -1;
                tPostCodeTextBox.Clear();
                tDistrictCombo.Enabled = true;
                tDistrictCombo.Focus();

                //tDivisionCombo.Text = tDivisionCombo.Text.Trim();
                //tDistrictCombo.Items.Clear();
                //tDistrictCombo.Text = "";
                //tThenaCombo.SelectedIndex = -1;
                //tPostCombo.SelectedIndex = -1;
                //tPostCodeTextBox.Clear();
                //tDistrictCombo.Enabled = true;
                //tDistrictCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdT + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tDistrictCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tThenaCombo.Enabled = false;
            tPostCombo.Enabled = false;
        }

        private void tThenaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select D_ID from Districts WHERE District= '" + tDistrictCombo.Text + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                tdistrict_id = rdr.GetInt32(0);
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + tdistrict_id + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = tThenaCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdT = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                tThenaCombo.Text = tThenaCombo.Text.Trim();
                tPostCombo.Items.Clear();
                tPostCombo.ResetText();
                tPostCodeTextBox.Clear();
                tPostCombo.Enabled = true;
                tPostCombo.Focus();

                //tThenaCombo.Text = tThenaCombo.Text.Trim();
                //tPostCombo.Items.Clear();
                //tPostCombo.Text = "";
                //tPostCodeTextBox.Clear();
                //tPostCombo.Enabled = true;
                //tPostCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdT + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tPostCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tPostCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = tPostCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postOfficeIdT = (rdr.GetString(0));
                    tPostCodeTextBox.Text = (rdr.GetString(1));

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

        private void NotApplicableCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void cellNumberTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;


        }

       
        private void notApplicableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (notApplicableCheckBox.Checked)
            {

                if (sameAsCorporatAddCheckBox.Checked)
                {
                    sameAsCorporatAddCheckBox.CheckedChanged -= sameAsCorporatAddCheckBox_CheckedChanged;
                    sameAsCorporatAddCheckBox.Checked = false;
                    sameAsCorporatAddCheckBox.CheckedChanged += sameAsCorporatAddCheckBox_CheckedChanged;
                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }

            }
            else
            {
                if (sameAsCorporatAddCheckBox.Checked)
                {
                    groupBox3.Enabled = false;
                    ResetTradingAddress();
                    ResetStar();
                }
                else
                {

                    groupBox3.Enabled = true;
                    ResetTradingAddress();
                    FilStar();
                }
            }
        }

     

      
       

        private void ClientRegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

       
       

       
        private void cPostOfficeCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cDivisionCombo.Focus();
            //}



            //else if (string.IsNullOrWhiteSpace(cDistCombo.Text))
            //{
            //    MessageBox.Show("Please  select District first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cDistCombo.Focus();
            //}
            //else if (string.IsNullOrWhiteSpace(cThanaCombo.Text))
            //{
            //    MessageBox.Show("Please  select thana name first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cThanaCombo.Focus();
            //}
        }

        private void cThanaCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //else if (string.IsNullOrWhiteSpace(cDistCombo.Text))
            //{
            //    MessageBox.Show("Please  select District first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   return;
            //}
        }

        private void cDistCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

       

       

        

        private void tPostCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(tDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tDivisionCombo.Focus();
            //}



            //else if (string.IsNullOrWhiteSpace(tDistrictCombo.Text))
            //{
            //    MessageBox.Show("Please  select District first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tDistrictCombo.Focus();
            //}
            //else if (string.IsNullOrWhiteSpace(tThenaCombo.Text))
            //{
            //    MessageBox.Show("Please  select thana name first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tThenaCombo.Focus();
            //}
        }

        private void tThenaCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(tDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tDivisionCombo.Focus();
            //}



            //else if (string.IsNullOrWhiteSpace(tDistrictCombo.Text))
            //{
            //    MessageBox.Show("Please  select District first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tDistrictCombo.Focus();
            //}
        }

        private void tDistrictCombo_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(tDivisionCombo.Text))
            //{
            //    MessageBox.Show("Please  select Division  first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tDivisionCombo.Focus();
            //}
        }

     

      
        private void cContactNoTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(cContactNoTextBox.Text))
            {
                decimal sum = 0;
                decimal num;
                num = Convert.ToDecimal(cContactNoTextBox.Text);
                while (num > 0)
                {
                    sum = sum + (num / 10);
                    num = num / 10;
                }

                if (sum == 0)
                {
                    cContactNoTextBox.Clear();
                }
            }
        }

        private void tContactNoTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(tContactNoTextBox.Text))
            {
                decimal sum = 0;
                decimal num;
                num = Convert.ToDecimal(tContactNoTextBox.Text);
                while (num > 0)
                {
                    sum = sum + (num / 10);
                    num = num / 10;
                }

                if (sum == 0)
                {
                    tContactNoTextBox.Clear();
                }
            }
        }

        private void cmbNatureOfClient_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT NatureOfCompanyId from NatureOfCompanies WHERE CompanyNature = '" + cmbNatureOfClient.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    natureOfClientId = (rdr.GetInt32(0));
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IndustryCategorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT IndustryCategoryId from IndustryCategorys WHERE IndustryCategory = '" + IndustryCategorycomboBox.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    industryCategoryId = (rdr.GetInt32(0));
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCompanytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT CompanyTypeId from CompanyType WHERE CompanyTypeName= '" + cmbCompanytype.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    companytypeid = rdr.GetInt32(0);
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

        private void CompanyNameTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CompanyNameTextBox.Text))
            {
                string companyname = CompanyNameTextBox.Text.Trim();
                Regex mRegxExpression;
                int Minlen = 3;

                mRegxExpression = new Regex(@"^[A-Za-z]+[\s][A-Za-z]+[.][A-Za-z]+$");

                if ((!mRegxExpression.IsMatch(companyname)) && (!(CompanyNameTextBox.Text.Length >= Minlen)))
                {

                    MessageBox.Show("Please type your valid Company Name.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CompanyNameTextBox.Clear();
                    CompanyNameTextBox.Focus();

                }
            }

        }

        private void tAreaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void CompanyNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCompanytype.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompanytype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IndustryCategorycomboBox.Focus();
                e.Handled = true;
            }
        }

        private void IndustryCategorycomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbNatureOfClient.Focus();
                e.Handled = true;
            }
        }

        private void cmbNatureOfClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cFlatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cFlatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cHouseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cHouseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cRoadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cRoadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                blocktextBox.Focus();
                e.Handled = true;
            }
        }

        private void blocktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cAreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cAreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cDivisionCombo.Focus();
                e.Handled = true;
            }
        }

        private void cDivisionCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cDistCombo.Focus();
                e.Handled = true;
            }
        }

        private void cDistCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cThanaCombo.Focus();
                e.Handled = true;
            }
        }

        private void cThanaCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cPostOfficeCombo.Focus();
                e.Handled = true;
            }
        }

        private void cPostOfficeCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cPostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cPostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tFlatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tFlatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tHouseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tHouseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tRoadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tRoadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FblocktextBox.Focus();
                e.Handled = true;
            }
        }

        private void FblocktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tAreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tAreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tDivisionCombo.Focus();
                e.Handled = true;
            }
        }

        private void tDivisionCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tDistrictCombo.Focus();
                e.Handled = true;
            }
        }

        private void tDistrictCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tThenaCombo.Focus();
                e.Handled = true;
            }
        }

        private void tThenaCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tPostCombo.Focus();
                e.Handled = true;
            }
        }

        private void tPostCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tPostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tPostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               saveButton_Click(this, new EventArgs());
            }
        }

        private void CompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText =
                "select " +
                "    Company.CompanyName, " +
                "    isnull(nullif([CorporateAddresses.CFlatNo], '') + ', ', '') + " +
                "    isnull(nullif([CorporateAddresses.CHouseNo], '') + ', ', '') + " +
                "    isnull(nullif([CorporateAddresses.CRoadNo], ''), '') + " +
                "    isnull(nullif([CorporateAddresses.CBlock], '') + ', ', '') + " +
                "    isnull(nullif([CorporateAddresses.CArea], '') + ', ', '') + " +
                "    isnull(nullif([CorporateAddresses.CContactNo], ''), '') + " +
                "    isnull(nullif([PostOffice.PostOfficeName], '') + ', ', '') + " +
                "    isnull(nullif([PostOffice.PostCode], '') + ', ', '') + " +
                "    isnull(nullif([Thanas.Thana], ''), '') + " +
                "    isnull(nullif([Districts.District], ''), '') as Address " +
                "FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID where Company.CompanyName like '" + CompanyNameTextBox.Text + "%' order by Company.CompanyId asc";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            //DataTable dt = new DataTable();        
            //    sda.Fill(dt);

            //    dataGridView1.DataSource = dt;
                con.Close();
            }
           
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //sda.Dispose();
                // handle your error
        }
    }
}