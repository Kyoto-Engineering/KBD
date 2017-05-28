﻿using System;
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
using QRCoder;

namespace PhonebookApp.UI
{
    public partial class frmUpdateCompany : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id, fullName, submittedBy, districtIdC, districtIdT, divisionIdC, divisionIdT, thanaIdC, thanaIdC2, thanaIdT, postofficeIdC, postOfficeIdT, userType1;
        public int companyid, companytypeid, clientTypeId, natureOfClientId, industrycategoryid, addressTypeId1, addressTypeId2, superviserId, bankEmailId, bankCPEmailId;
        public int cdistrict_id, tdistrict_id;
        private int affectedRows1, affectedRows2;
        public frmUpdateCompany()
        {
            InitializeComponent();
        }


        private void frmCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            frm.Show();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            FillCompanyType();
            FillIndustryCategory();
            FillNatureOfClient();
            FillCDivisionCombo();
            FillTDivisionCombo();
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

        public void FillCDivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division asc ";
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
        private void FillIndustryCategory()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select IndustryCategory from IndustryCategorys";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IndustryCategorycomboBox.Items.Add(rdr.GetValue(0).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void IndustryCategorycomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT IndustryCategoryId from IndustryCategorys WHERE IndustryCategory= '" + IndustryCategorycomboBox.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    industrycategoryid = rdr.GetInt32(0);
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

        private void cmbCompanytype_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cmbNatureOfClient_SelectedIndexChanged(object sender, EventArgs e)
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
                    natureOfClientId = rdr.GetInt32(0);
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cThanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //cmd = con.CreateCommand();

            //cmd.CommandText = "select D_ID from Districts WHERE District= '" + cDistCombo.Text + "'";

            //rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //    cdistrict_id = rdr.GetInt32(0);
            //}
            //if ((rdr != null))
            //{
            //    rdr.Close();
            //}
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + districtIdC + "'";
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
                cPostCodeTextBox.Clear();
                cPostOfficeCombo.Enabled = true;
                cPostOfficeCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();               
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

        private void tThenaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //cmd = con.CreateCommand();

            //cmd.CommandText = "select D_ID from Districts WHERE District= '" + tDistrictCombo.Text + "'";

            //rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //    tdistrict_id = rdr.GetInt32(0);
            //}
            //if ((rdr != null))
            //{
            //    rdr.Close();
            //}
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + districtIdT + "'";
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

        private void ResetTradingAddress()
        {

            tFlatNoTextBox.Clear();
            tHouseNoTextBox.Clear();
            tBuldingNameTextBox.Clear();
            tRoadNoTextBox.Clear();
            tRoadNameTextBox.Clear();
            tAreaTextBox.Clear();
            FblocktextBox.Clear();
            tLandmarktextBox.Clear();
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

        private void sameAsCorporatAddCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sameAsCorporatAddCheckBox.Checked)
            {

                if (notApplicableCheckBox.Checked)
                {
                    notApplicableCheckBox.CheckedChanged -= notApplicableCheckBox_CheckedChanged;
                    notApplicableCheckBox.Checked = false;
                    notApplicableCheckBox.CheckedChanged += notApplicableCheckBox_CheckedChanged;
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //1.Corporate Address Applicable  & Tradding Address not Applicable
                if (notApplicableCheckBox.Checked)
                {
                    UpdateCompany();
                    GetCompanyIdAndSaveOrUpdateCompanyAddress("CorporateAddresses");
                }
                //2.Corporate Address Applicable  & Tradding Address Same as  Corporate Address                                        
                if (sameAsCorporatAddCheckBox.Checked)
                {
                    UpdateCompany();
                    GetCompanyIdAndSaveOrUpdateCompanyAddress("CorporateAddresses");
                    GetCompanyIdAndSaveOrUpdateCompanyAddress("TraddingAddresses");
                    //UpdateTASameAsCA("TraddingAddresses");
                }
                //3.Corporate Address Applicable  & Tradding Address  Applicable
                if (sameAsCorporatAddCheckBox.Checked == false && notApplicableCheckBox.Checked == false)
                {
                    UpdateCompany();
                    GetCompanyIdAndSaveOrUpdateCompanyAddress("CorporateAddresses");
                    GetCompanyIdAndSaveOrUpdateCompanyAddress("TraddingAddresses");
                }
                
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();

            }
            catch (FormatException formatException)
            {
                MessageBox.Show("Please Enter Input in Correct Format", formatException.Message);
            }
        }

        public void UpdateCompany()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query =
                    "update Company set CompanyName=@d1,Email=@nemail,ContactNo=@nphone,IdentificationNo=@nidenti,WebSiteUrl=@nweburl, UserId=@d2, DateAndTime=@d3,CompanyTypeId=@d4,IndustryCategoryId=@d5,NatureOfCompanyId=@d6  Where Company.CompanyId='" +
                    CompanyIdtextBox.Text + "'";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", CompanyNameTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@nemail",
                    string.IsNullOrEmpty(EmailtextBox.Text) ? (object)DBNull.Value : EmailtextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@nphone",
                    string.IsNullOrEmpty(ContactNotextBox.Text) ? (object)DBNull.Value : ContactNotextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@nidenti",
                    string.IsNullOrEmpty(IdentificationNotextBox.Text)
                        ? (object)DBNull.Value
                        : IdentificationNotextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@nweburl",
                    string.IsNullOrEmpty(WebSiteUrltextBox.Text) ? (object)DBNull.Value : WebSiteUrltextBox.Text));
                cmd.Parameters.AddWithValue("@d2", user_id);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d4", companytypeid);
                cmd.Parameters.AddWithValue("@d5", industrycategoryid);
                cmd.Parameters.AddWithValue("@d6", natureOfClientId);
                rdr = cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCompanyIdAndSaveOrUpdateCompanyAddress(string tableName)
        {
            string checkTable = tableName;
            if (checkTable == "CorporateAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select RTRIM(CorporateAddresses.CompanyId) from CorporateAddresses where CorporateAddresses.CompanyId='" + CompanyIdtextBox.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    UpdateCompanyAddress("CorporateAddresses");
                }
                else
                {
                    SaveTraddingAddress("CorporateAddresses");
                }
            }
            else if (checkTable == "TraddingAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select RTRIM(TraddingAddresses.CompanyId) from TraddingAddresses where TraddingAddresses.CompanyId='" + CompanyIdtextBox.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    UpdateCompanyAddress("TraddingAddresses");
                }
                else
                {
                    SaveTraddingAddress("TraddingAddresses");
                }
            }
        }

        private void UpdateCompanyAddress(string tablName1)
        {
            string corporatTable = tablName1;
            try
            {
                if (corporatTable == "CorporateAddresses")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update " + corporatTable + " set PostOfficeId=@d4,CFlatNo=@d5,CHouseNo=@d6,CRoadNo=@d7,CBlock=@d8,CArea=@d9,CLandmark=@d10,CContactNo=@d11,BuildingName=@d12,RoadName=@d13,AdressQR=@d14  Where  CorporateAddresses.CompanyId='" + CompanyIdtextBox.Text + "'";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
                    cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cLandmarktextBox.Text) ? (object)DBNull.Value : cLandmarktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d12", string.IsNullOrEmpty(cBuldingNameTextBox.Text) ? (object)DBNull.Value : cBuldingNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(cRoadNameTextBox.Text) ? (object)DBNull.Value : cRoadNameTextBox.Text));
                    var Qrdata = GetQrdata(cDivisionCombo.Text, cDistCombo.Text, cThanaCombo.Text, cPostOfficeCombo.Text, cPostCodeTextBox.Text, cAreaTextBox.Text, blocktextBox.Text, cLandmarktextBox.Text, cRoadNameTextBox.Text, cRoadNoTextBox.Text, cBuldingNameTextBox.Text, cHouseNoTextBox.Text, cFlatNoTextBox.Text, cContactNoTextBox.Text);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                    //qrCode.GetGraphic()
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] data = ms.GetBuffer();
                    SqlParameter p = new SqlParameter("@d14", SqlDbType.VarBinary);
                    p.Value = data;
                    cmd.Parameters.Add(p);
                    rdr = cmd.ExecuteReader();
                    con.Close();
                }

                else if (corporatTable == "TraddingAddresses")
                {
                    if (sameAsCorporatAddCheckBox.Checked == false && notApplicableCheckBox.Checked == false)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query = "Update " + corporatTable +
                                       " set PostOfficeId=@d4,TFlatNo=@d5,THouseNo=@d6,TRoadNo=@d7,TBlock=@d8,TArea=@d9,TLandmark=@d10,TContactNo=@d11,BuildingName=@d12,RoadName=@d13,AdressQR=@d14  Where  TraddingAddresses.CompanyId='" +
                                       CompanyIdtextBox.Text + "'";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@d4",
                            string.IsNullOrEmpty(postOfficeIdT) ? (object) DBNull.Value : postOfficeIdT));
                        cmd.Parameters.Add(new SqlParameter("@d5",
                            string.IsNullOrEmpty(tFlatNoTextBox.Text) ? (object) DBNull.Value : tFlatNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d6",
                            string.IsNullOrEmpty(tHouseNoTextBox.Text) ? (object) DBNull.Value : tHouseNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d7",
                            string.IsNullOrEmpty(tRoadNoTextBox.Text) ? (object) DBNull.Value : tRoadNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d8",
                            string.IsNullOrEmpty(FblocktextBox.Text) ? (object) DBNull.Value : FblocktextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d9",
                            string.IsNullOrEmpty(tAreaTextBox.Text) ? (object) DBNull.Value : tAreaTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d10",
                            string.IsNullOrEmpty(tLandmarktextBox.Text)
                                ? (object) DBNull.Value
                                : tLandmarktextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d11",
                            string.IsNullOrEmpty(tContactNoTextBox.Text)
                                ? (object) DBNull.Value
                                : tContactNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d12",
                            string.IsNullOrEmpty(tBuldingNameTextBox.Text)
                                ? (object) DBNull.Value
                                : tBuldingNameTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d13",
                            string.IsNullOrEmpty(tRoadNameTextBox.Text)
                                ? (object) DBNull.Value
                                : tRoadNameTextBox.Text));
                        var Qrdata = GetQrdata(tDivisionCombo.Text, tDistrictCombo.Text, tThenaCombo.Text, tPostCombo.Text, tPostCodeTextBox.Text, tAreaTextBox.Text, FblocktextBox.Text, tLandmarktextBox.Text, tRoadNameTextBox.Text, tRoadNoTextBox.Text, tBuldingNameTextBox.Text, tHouseNoTextBox.Text, tFlatNoTextBox.Text, tContactNoTextBox.Text);
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                        //qrCode.GetGraphic()
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] data = ms.GetBuffer();
                        SqlParameter p = new SqlParameter("@d14", SqlDbType.VarBinary);
                        p.Value = data;
                        cmd.Parameters.Add(p);
                        rdr = cmd.ExecuteReader();
                        con.Close();
                    }

                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query = "Update " + corporatTable +
                                       " set PostOfficeId=@d4,TFlatNo=@d5,THouseNo=@d6,TRoadNo=@d7,TBlock=@d8,TArea=@d9,TLandmark=@d10,TContactNo=@d11,BuildingName=@d12,RoadName=@d13,AdressQR=@d14  Where  TraddingAddresses.CompanyId='" +
                                       CompanyIdtextBox.Text + "'";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
                        cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cLandmarktextBox.Text) ? (object)DBNull.Value : cLandmarktextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d12", string.IsNullOrEmpty(cBuldingNameTextBox.Text) ? (object)DBNull.Value : cBuldingNameTextBox.Text));
                        cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(cRoadNameTextBox.Text) ? (object)DBNull.Value : cRoadNameTextBox.Text));
                        var Qrdata = GetQrdata(cDivisionCombo.Text, cDistCombo.Text, cThanaCombo.Text, cPostOfficeCombo.Text, cPostCodeTextBox.Text, cAreaTextBox.Text, blocktextBox.Text, cLandmarktextBox.Text, cRoadNameTextBox.Text, cRoadNoTextBox.Text, cBuldingNameTextBox.Text, cHouseNoTextBox.Text, cFlatNoTextBox.Text, cContactNoTextBox.Text);
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                        //qrCode.GetGraphic()
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] data = ms.GetBuffer();
                        SqlParameter p = new SqlParameter("@d14", SqlDbType.VarBinary);
                        p.Value = data;
                        cmd.Parameters.Add(p);
                        rdr = cmd.ExecuteReader();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTraddingAddress(string tblName1)
        {
            string tableName = tblName1;
            //if (tableName == "CorporateAddresses")
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string insertQ = "insert into " + tableName + "(PostOfficeId,CFlatNo,CHouseNo,CRoadNo,CBlock,CArea,CLandmark,CContactNo,CompanyId,BuildingName,RoadName) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            //    cmd = new SqlCommand(insertQ);
            //    cmd.Connection = con;
            //    cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
            //    cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cLandmarktextBox.Text) ? (object)DBNull.Value : cLandmarktextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));
            //    cmd.Parameters.AddWithValue("@d12", CompanyIdtextBox.Text);
            //    cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(cBuldingNameTextBox.Text) ? (object)DBNull.Value : cBuldingNameTextBox.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d14", string.IsNullOrEmpty(cRoadNameTextBox.Text) ? (object)DBNull.Value : cRoadNameTextBox.Text));

            //    affectedRows1 = (int)cmd.ExecuteScalar();
            //    con.Close();
            //}
         if (tableName == "TraddingAddresses")
            {
                if (sameAsCorporatAddCheckBox.Checked)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string Qry = "insert into " + tableName +
                                 "(PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TLandmark,TContactNo,CompanyId,BuildingName,RoadName,AdressQR) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)" +
                                 "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(Qry);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d4",
                        string.IsNullOrEmpty(postofficeIdC) ? (object) DBNull.Value : postofficeIdC));
                    cmd.Parameters.Add(new SqlParameter("@d5",
                        string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object) DBNull.Value : cFlatNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d6",
                        string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object) DBNull.Value : cHouseNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d7",
                        string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object) DBNull.Value : cRoadNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d8",
                        string.IsNullOrEmpty(blocktextBox.Text) ? (object) DBNull.Value : blocktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d9",
                        string.IsNullOrEmpty(cAreaTextBox.Text) ? (object) DBNull.Value : cAreaTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d10",
                        string.IsNullOrEmpty(cLandmarktextBox.Text) ? (object) DBNull.Value : cLandmarktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d11",
                        string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object) DBNull.Value : cContactNoTextBox.Text));
                    cmd.Parameters.AddWithValue("@d12", CompanyIdtextBox.Text);
                    cmd.Parameters.Add(new SqlParameter("@d13",
                        string.IsNullOrEmpty(cBuldingNameTextBox.Text)
                            ? (object) DBNull.Value
                            : cBuldingNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d14",
                        string.IsNullOrEmpty(cRoadNameTextBox.Text) ? (object) DBNull.Value : cRoadNameTextBox.Text));
                    var Qrdata = GetQrdata(cDivisionCombo.Text, cDistCombo.Text, cThanaCombo.Text, cPostOfficeCombo.Text, cPostCodeTextBox.Text, cAreaTextBox.Text, blocktextBox.Text, cLandmarktextBox.Text, cRoadNameTextBox.Text, cRoadNoTextBox.Text, cBuldingNameTextBox.Text, cHouseNoTextBox.Text, cFlatNoTextBox.Text, cContactNoTextBox.Text);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                    //qrCode.GetGraphic()
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] data = ms.GetBuffer();
                    SqlParameter p = new SqlParameter("@d15", SqlDbType.VarBinary);
                    p.Value = data;
                    cmd.Parameters.Add(p);
                    affectedRows2 = (int) cmd.ExecuteScalar();
                    con.Close();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string Qry = "insert into " + tableName + "(PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TLandmark,TContactNo,CompanyId,BuildingName,RoadName,AdressQR) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(Qry);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postOfficeIdT) ? (object)DBNull.Value : postOfficeIdT));
                    cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(tFlatNoTextBox.Text) ? (object)DBNull.Value : tFlatNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(tHouseNoTextBox.Text) ? (object)DBNull.Value : tHouseNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(tRoadNoTextBox.Text) ? (object)DBNull.Value : tRoadNoTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(FblocktextBox.Text) ? (object)DBNull.Value : FblocktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(tAreaTextBox.Text) ? (object)DBNull.Value : tAreaTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(tLandmarktextBox.Text) ? (object)DBNull.Value : tLandmarktextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(tContactNoTextBox.Text) ? (object)DBNull.Value : tContactNoTextBox.Text));
                    cmd.Parameters.AddWithValue("@d12", CompanyIdtextBox.Text);
                    cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(tBuldingNameTextBox.Text) ? (object)DBNull.Value : tBuldingNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@d14", string.IsNullOrEmpty(tRoadNameTextBox.Text) ? (object)DBNull.Value : tRoadNameTextBox.Text));
                    var Qrdata = GetQrdata(tDivisionCombo.Text, tDistrictCombo.Text, tThenaCombo.Text, tPostCombo.Text, tPostCodeTextBox.Text, tAreaTextBox.Text, FblocktextBox.Text, tLandmarktextBox.Text, tRoadNameTextBox.Text, tRoadNoTextBox.Text, tBuldingNameTextBox.Text, tHouseNoTextBox.Text, tFlatNoTextBox.Text, tContactNoTextBox.Text);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                    //qrCode.GetGraphic()
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] data = ms.GetBuffer();
                    SqlParameter p = new SqlParameter("@d15", SqlDbType.VarBinary);
                    p.Value = data;
                    cmd.Parameters.Add(p);
                    affectedRows2 = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }
        }

        private string GetQrdata(string Division, string District, string Thana, string Post, string PostCode, string Area, string Block, string LandMark, string roadName, string RoadNo, string buildingName, string HouseNo, string FlatNo, string ContactNo)
        {
            string Qrdata = "Country:Bangladesh\r\n";
            Qrdata += "Division:" + Division + "\r\n";
            Qrdata += "District:" + District + "\r\n";
            Qrdata += "Thana:" + Thana + "\r\n";
            Qrdata += "Post:" + Post + "\r\n";
            Qrdata += "Post Code:" + PostCode + "\r\n";
            Qrdata += "Area / Village :" + (string.IsNullOrEmpty(Area) ? "" : Area) +
                      "\r\n";
            Qrdata += "Block/Sector/Zone:" + (string.IsNullOrEmpty(Block) ? "" : Block) +
                      "\r\n";
            Qrdata += "Nearest Landmark:" + (string.IsNullOrEmpty(LandMark)
                          ? ""
                          : LandMark) + "\r\n";
            Qrdata += "Road Name:" +
                      (string.IsNullOrEmpty(roadName) ? "" : roadName) + "\r\n";
            Qrdata += "Road#:" + (string.IsNullOrEmpty(RoadNo) ? "" : RoadNo) + "\r\n";
            Qrdata += "Building Name:" + (string.IsNullOrEmpty(buildingName)
                          ? ""
                          : buildingName) + "\r\n";
            Qrdata += "Holding#:" + (string.IsNullOrEmpty(HouseNo) ? "" : HouseNo) +
                      "\r\n";
            Qrdata += "Flat or Level#:" + (string.IsNullOrEmpty(FlatNo) ? "" : FlatNo) +
                      "\r\n";
            Qrdata += "Contact#:" + (string.IsNullOrEmpty(ContactNo) ? "" : ContactNo);
            return Qrdata;
        }


        private void Reset()
        {
            CompanyIdtextBox.Clear();
            cmbCompanytype.SelectedIndex = -1;
            cmbNatureOfClient.SelectedIndex = -1;
            IndustryCategorycomboBox.SelectedIndex = -1;
            CompanyNameTextBox.Clear();
            EmailtextBox.Clear();
            ContactNotextBox.Clear();
            IdentificationNotextBox.Clear();
            WebSiteUrltextBox.Clear();
            cFlatNoTextBox.Clear();
            cHouseNoTextBox.Clear();
            cBuldingNameTextBox.Clear();
            cRoadNoTextBox.Clear();
            cRoadNameTextBox.Clear();
            blocktextBox.Clear();
            cAreaTextBox.Clear();
            cLandmarktextBox.Clear();
            cContactNoTextBox.Clear();
            cPostCodeTextBox.Clear();
            cPostOfficeCombo.SelectedIndex = -1;
            cThanaCombo.SelectedIndex = -1;
            cDistCombo.SelectedIndex = -1;
            cDivisionCombo.SelectedIndex = -1;
            notApplicableCheckBox.CheckedChanged -= notApplicableCheckBox_CheckedChanged;
            notApplicableCheckBox.Checked = false;
            notApplicableCheckBox.CheckedChanged += notApplicableCheckBox_CheckedChanged;

            sameAsCorporatAddCheckBox.CheckedChanged -= sameAsCorporatAddCheckBox_CheckedChanged;
            sameAsCorporatAddCheckBox.Checked = false;
            sameAsCorporatAddCheckBox.CheckedChanged += sameAsCorporatAddCheckBox_CheckedChanged;
            if ((notApplicableCheckBox.Checked == false) && (sameAsCorporatAddCheckBox.Checked == false))
            {
                ResetTradingAddress();
            }
            UpdateButton.Enabled = true;

        }

    }
}