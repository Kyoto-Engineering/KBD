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
    public partial class frmUpdateCompany : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id;
        public string countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public int currentPersonId, companytypeid,industrycategoryid, wAdistrictid,affectedRows1;
        public frmUpdateCompany()
        {
            InitializeComponent();
        }

        private void btnSaveCompany_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            //{
            //    MessageBox.Show("Please Enter  Company Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCompanyName.Focus();
            //}

            //else if (string.IsNullOrWhiteSpace(cmbCompanytype.Text))
            //{
            //    MessageBox.Show("Please Select Company Type", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);


            //}

            //else if (string.IsNullOrWhiteSpace(IndustryCategorycomboBox.Text))
            //{
            //    MessageBox.Show("Please select Industry Category", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);


            //}


            //else if (string.IsNullOrWhiteSpace(cmbWADivision.Text))
            //{
            //    MessageBox.Show("Please select division", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);


            //}
            //else if (string.IsNullOrWhiteSpace(cmbWADistrict.Text))
            //{
            //    MessageBox.Show("Please Select district", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);


            //}
            //else if (string.IsNullOrWhiteSpace(cmbWAThana.Text))
            //{
            //    MessageBox.Show("Please select Thana", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);


            //}
            //else if (string.IsNullOrWhiteSpace(cmbWAPost.Text))
            //{
            //    MessageBox.Show("Please Select Post Office Name", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);

            //}
            //else
            //{
            //    try
            //    {
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        string ct = "select CompanyName from Company where CompanyName='" + txtCompanyName.Text + "'";

            //        cmd = new SqlCommand(ct);
            //        cmd.Connection = con;
            //        rdr = cmd.ExecuteReader();

            //        if (rdr.Read())
            //        {
            //            MessageBox.Show("This Company Name Already Exists in the List", "Error", MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //            txtCompanyName.Text = "";
            //            txtCompanyName.Focus();


            //            if ((rdr != null))
            //            {
            //                rdr.Close();
            //            }
            //            return;
            //        }
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        string query = "insert into Company(CompanyName, UserId, DateAndTime) values(@d1,@d2,@d3)";
            //        cmd = new SqlCommand(query, con);
            //        cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text);
            //        cmd.Parameters.AddWithValue("@d2", user_id);
            //        cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //        txtCompanyName.Clear();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void SaveVendorAddress(string tblName1)
        {
            //string tableName = tblName1;

            //if (tableName == "WorkingAddresses")
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string insertQ = "insert into " + tableName +
            //                     "(PersonsId,PostOfficeId,WFlatNo,WHouseNo,WRoadNo,WBlock,WArea,WContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
            //                     "SELECT CONVERT(int, SCOPE_IDENTITY())";
            //    cmd = new SqlCommand(insertQ);
            //    cmd.Connection = con;
            //    cmd.Parameters.AddWithValue("@d1", currentPersonId);
            //    cmd.Parameters.Add(new SqlParameter("@d2",
            //        string.IsNullOrEmpty(postofficeIdWA) ? (object)DBNull.Value : postofficeIdWA));
            //    cmd.Parameters.Add(new SqlParameter("@d3",
            //        string.IsNullOrEmpty(txtWAFlatName.Text) ? (object)DBNull.Value : txtWAFlatName.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d4",
            //        string.IsNullOrEmpty(txtWAHouseName.Text) ? (object)DBNull.Value : txtWAHouseName.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d5",
            //        string.IsNullOrEmpty(txtWARoadNo.Text) ? (object)DBNull.Value : txtWARoadNo.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d6",
            //        string.IsNullOrEmpty(txtWABlock.Text) ? (object)DBNull.Value : txtWABlock.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d7",
            //        string.IsNullOrEmpty(txtWAArea.Text) ? (object)DBNull.Value : txtWAArea.Text));
            //    cmd.Parameters.Add(new SqlParameter("@d8",
            //        string.IsNullOrEmpty(txtWAContactNo.Text) ? (object)DBNull.Value : txtWAContactNo.Text));
            //    affectedRows1 = (int)cmd.ExecuteScalar();
            //    con.Close();
            //}
        }

        private void frmCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            FillIndustryCategory();
            FillCompanyType();
            FillDivisionCombo();
        }

        public void FillDivisionCombo()
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


        private void cmbWADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    cmbWADistrict.Items.Clear();
        //    cmbWADistrict.ResetText();
        //    cmbWAThana.Items.Clear();
        //    cmbWAThana.ResetText();
        //    cmbWAPost.Items.Clear();
        //    cmbWAPost.ResetText();

        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

        //        cmd = new SqlCommand(ctk);
        //        cmd.Connection = con;
        //        cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
        //        cmd.Parameters["@find"].Value = cmbWADivision.Text;
        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            divisionIdWA = (rdr.GetString(0));

        //        }

        //        if ((rdr != null))
        //        {
        //            rdr.Close();
        //        }
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }

        //        cmbWADivision.Text = cmbWADivision.Text.Trim();
        //        cmbWADistrict.Items.Clear();
        //        cmbWADistrict.ResetText();
        //        cmbWAThana.Items.Clear();
        //        cmbWAThana.ResetText();
        //        cmbWAThana.SelectedIndex = -1;
        //        cmbWAPost.Items.Clear();
        //        cmbWAPost.ResetText();
        //        cmbWAPost.SelectedIndex = -1;
        //        txtWAPostCode.Clear();
        //        cmbWADistrict.Enabled = true;
        //        cmbWADistrict.Focus();

        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdWA + "' order by Districts.Division_ID desc";
        //        cmd = new SqlCommand(ct);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cmbWADistrict.Items.Add(rdr[0]);
        //        }
        //        con.Close();

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    cmbWAThana.Enabled = false;
        //    cmbWAPost.Enabled = false;
        }

        private void cmbWADistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
            //    cmd = new SqlCommand(ctk);
            //    cmd.Connection = con;
            //    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
            //    cmd.Parameters["@find"].Value = cmbWADistrict.Text;
            //    rdr = cmd.ExecuteReader();

            //    if (rdr.Read())
            //    {
            //        districtIdWA = (rdr.GetString(0));
            //    }

            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //    cmbWADistrict.Text = cmbWADistrict.Text.Trim();
            //    cmbWAThana.Items.Clear();
            //    cmbWAThana.ResetText();
            //    cmbWAPost.Items.Clear();
            //    cmbWAPost.ResetText();
            //    cmbWAPost.SelectedIndex = -1;
            //    cmbWAPost.Enabled = false;
            //    txtWAPostCode.Clear();
            //    cmbWAThana.Enabled = true;
            //    cmbWAThana.Focus();



            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdWA + "' order by Thanas.D_ID desc";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        cmbWAThana.Items.Add(rdr[0]);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbWAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //cmd = con.CreateCommand();

            //cmd.CommandText = "select D_ID from Districts WHERE District= '" + cmbWADistrict.Text + "'";

            //rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //    wAdistrictid = rdr.GetInt32(0);
            //    //districtIdRA = (rdr.GetString(0));
            //}
            //if ((rdr != null))
            //{
            //    rdr.Close();
            //}
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}


            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + wAdistrictid + "'";
            //    cmd = new SqlCommand(ctk);
            //    cmd.Connection = con;
            //    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
            //    cmd.Parameters["@find"].Value = cmbWAThana.Text;
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        thanaIdWA = (rdr.GetString(0));

            //    }

            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }


            //    cmbWAThana.Text = cmbWAThana.Text.Trim();
            //    cmbWAPost.Items.Clear();
            //    cmbWAPost.ResetText();

            //    txtWAPostCode.Clear();
            //    cmbWAPost.Enabled = true;
            //    cmbWAPost.Focus();

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    //string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdC + "' order by PostOffice.T_ID desc";
            //    string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdWA + "' order by PostOffice.T_ID desc";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        cmbWAPost.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //cmbWAPost.SelectedIndex = -1;
        }

        private void cmbWAPost_SelectedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
            //    cmd = new SqlCommand(ctk);
            //    cmd.Connection = con;
            //    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
            //    cmd.Parameters["@find"].Value = cmbWAPost.Text;
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        postofficeIdWA = (rdr.GetString(0));
            //        txtWAPostCode.Text = (rdr.GetString(1));
            //    }

            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        private void tDivisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
