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
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using PhonebookApp.Reports;
using PhonebookApp.UI;
using QRCoder;




namespace PhonebookApp.UI
{

    
    public partial class ForeignPerson : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string companyId = null;
        public string rAdistrictid, countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public Nullable<Int64> groupid, relationshipId, bankEmailId, categoryId, jobTitleId, specializationId, professionId, ageGroupId, educationLevelId, highestDegreeId, religionId, genderId, maritalStatusId;
        public int currentPersonId, affectedRows1, affectedRows2, affectedRows3, wAdistrictid;
        private delegate void ChangeFocusDelegate(Control ctl);
        public ForeignPerson()
        {
            InitializeComponent();
        }
        public void FillReligion()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Religion.ReligionName) from Religion  order by Religion.ReligionId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ReligioncomboBox.Items.Add(rdr[0]);
                }
                ReligioncomboBox.Items.Add("Not In The List");
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReligioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReligioncomboBox.Text == "Not In The List")
            {
                //string inputReligion = Microsoft.VisualBasic.Interaction.InputBox("Please Input Religion  Here", "Input Here", "", -1, -1);
                string inputReligion = null;
                InputBox.Show("Please Input Religion Here", "Inpute Here", ref inputReligion);
                if (string.IsNullOrWhiteSpace(inputReligion))
                {
                    ReligioncomboBox.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select ReligionName from Religion where ReligionName='" + inputReligion + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Religion Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        ReligioncomboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Religion (ReligionName,UserId) values (@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputReligion);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            ReligioncomboBox.Items.Clear();
                            FillReligion();
                            ReligioncomboBox.SelectedText = inputReligion;
                            

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
                    string ct = "select ReligionId from Religion  where  Religion.ReligionName='" + ReligioncomboBox.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        religionId = Convert.ToInt64(rdr["ReligionId"]);
                    }
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void maritalStatuscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select MaritalStatusId from MaritalStatus  where  MaritalStatus.MaritalStatusName='" + maritalStatuscomboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                   maritalStatusId = rdr.GetInt32(0) ;
                   

                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForeignSaveClick(object sender, EventArgs e)
        {
            {
                SqlParameter p;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String query =
                    "insert into ForeignPerson (FPersonName,Fpersonnickname,FFathersName,FMothersName,EmailBankId,Fwebsite,ReligionId, CompanyId,  GenderId, JobTitleId,SpecializationsId,MaritalStatusId, DateOfBirth,UserId,Picture, FcontactNum, FDepartment, PassportNo, Nationality) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtPersonNameForeign.Text);
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(textNickNameForeign.Text) ? (object)DBNull.Value : textNickNameForeign.Text));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(textFatherNameForeign.Text) ? (object)DBNull.Value : textFatherNameForeign.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(textMotherNameForeign.Text) ? (object)DBNull.Value : textMotherNameForeign.Text));

                cmd.Parameters.AddWithValue("@d5", (object)bankEmailId ?? DBNull.Value);
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(txtWebSiteForeign.Text) ? (object)DBNull.Value : txtWebSiteForeign.Text));

                cmd.Parameters.AddWithValue("@d7", (object)religionId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d8", (object)companyId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d9", (object)genderId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d10", (object)jobTitleId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d11", (object)specializationId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d12", (object)maritalStatusId ?? DBNull.Value);
                cmd.Parameters.Add(new SqlParameter("@d13",
                    !BirthdateTimePicker.Checked ? (object)DBNull.Value : BirthdateTimePicker.Value.Date));
                cmd.Parameters.AddWithValue("@d14", nUserId);


                if (userPictureBox.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    Bitmap bmpImage = new Bitmap(userPictureBox.Image);
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] data = ms.GetBuffer();
                    p = new SqlParameter("@d15", SqlDbType.VarBinary);
                    p.Value = data;
                    cmd.Parameters.Add(p);
                }
                else
                {
                    cmd.Parameters.Add("@d15", SqlDbType.VarBinary, -1);
                    cmd.Parameters["@d15"].Value = DBNull.Value;
                }

                cmd.Parameters.Add(new SqlParameter("@d16",
                    string.IsNullOrEmpty(textContactNumberForeignPerson.Text) ? (object)DBNull.Value : textContactNumberForeignPerson.Text));
                
                cmd.Parameters.Add(new SqlParameter("@d17",
                    string.IsNullOrEmpty(textdepartment.Text) ? (object)DBNull.Value : textdepartment.Text));
                

                
                cmd.Parameters.Add(new SqlParameter("@d18",
                    string.IsNullOrEmpty(textPassportNoForeign.Text) ? (object)DBNull.Value : textPassportNoForeign.Text));
                
                cmd.Parameters.Add(new SqlParameter("@d19",
                    string.IsNullOrEmpty(textNationalityForeign.Text) ? (object)DBNull.Value : textNationalityForeign.Text));

                
                
                    



                //string.IsNullOrEmpty(textNationalityForeign.Text) ? (object)DBNull.Value : textNationalityForeign.Text));
                //cmd.Parameters.AddWithValue("@d8", (object)professionId ?? DBNull.Value);

                //cmd.Parameters.AddWithValue("@d9", (object)educationLevelId ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@d10", (object)highestDegreeId ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@d11", (object)ageGroupId ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@d12", (object)relationshipId ?? DBNull.Value);
                //cmd.Parameters.Add(new SqlParameter("@d13",
                    //string.IsNullOrEmpty(txtWebsite.Text) ? (object)DBNull.Value : txtWebsite.Text));
                //cmd.Parameters.Add(new SqlParameter("@d14",
                    //string.IsNullOrEmpty(txtSkypeId.Text) ? (object)DBNull.Value : txtSkypeId.Text));
                //cmd.Parameters.Add(new SqlParameter("@d15",
                    //string.IsNullOrEmpty(txtWhatsApp.Text) ? (object)DBNull.Value : txtWhatsApp.Text));
                //cmd.Parameters.Add(new SqlParameter("@d16",
                    //string.IsNullOrEmpty(txtImmo.Text) ? (object)DBNull.Value : txtImmo.Text));
                //cmd.Parameters.AddWithValue("@d17", (object)countryid ?? DBNull.Value);
                
                
                
                
                //cmd.Parameters.Add(new SqlParameter("@d18",
                    //!AnniversarydateTimePicker.Checked ? (object)DBNull.Value : AnniversarydateTimePicker.Value.Date));
                
               
                //cmd.Parameters.Add(new SqlParameter("@d25",
                    //string.IsNullOrEmpty(department.Text) ? (object)DBNull.Value : department.Text));

                currentPersonId = (int)(cmd.ExecuteScalar());
                con.Close();
                
                MessageBox.Show("Saved successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            clearPersonForm();
        }

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png;*.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;

                openFileDialog1.FileName = "";
                //if (Image.FromFile(openFileDialog1.FileName).Height != 300)
                //{
                //    MessageBox.Show("Height Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Image.FromFile(openFileDialog1.FileName).Height != 300)
                    {
                        MessageBox.Show("Height Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Image.FromFile(openFileDialog1.FileName).Width != 300)
                    {
                        MessageBox.Show("Width Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //if (ValidFile(openFileDialog1.FileName, 300, 2176))
                        //{

                        userPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                        //pictureBrowseButton.Focus();
                    }
                    //else
                    //{
                    //    MessageBox.Show("Image Size is invalid");
                    //}
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new EmailSelectionGrid())
            {
                this.Visible = false;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bankEmailId = Convert.ToInt32(form.ReturnValue1);            //values preserved after close
                    string val = form.ReturnValue2;

                    //Do something here with these values

                    //for example
                    this.textBoxEmailForeign.Text = val;

                }
                this.Visible = true;
            }
            
        }

        private void CompanySelectionbutton_Click(object sender, EventArgs e)
        {
            using (var form = new ForeignCompanySelectionGrid())
            {
                this.Visible = false;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    companyId = form.ReturnValue2;

                    //Do something here with these values

                    //for example
                    this.companyNametextBox.Text = val;
                    SqlConnection con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 =
                        "SELECT Company.CompanyName, CompanyForeignAddress.FApartmentC, CompanyForeignAddress.FStreetC,CompanyForeignAddress.FStateC, CompanyForeignAddress.FCityC, CompanyForeignAddress.FZipcode,CompanyForeignAddress.FNearestlandmark , Countries.CountryName     FROM Company INNER JOIN CompanyForeignAddress ON Company.CompanyId = CompanyForeignAddress.CompanyId INNER JOIN Countries ON Countries.CountryId = CompanyForeignAddress.CountryId where Company.CompanyId='" +
                        companyId + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        this.fApartmentTextBox.Text = rdr["FApartmentC"].ToString();
                        this.fStreetTextBox.Text = rdr["FStreetC"].ToString();
                        this.fStateTextBox.Text = rdr["FStateC"].ToString();
                        this.fCityTextBox.Text = rdr["FCityC"].ToString();
                        this.fZipTextBox.Text = rdr["FZipcode"].ToString();
                        this.fLandmarkTextBox.Text = rdr["FNearestlandmark"].ToString();
                        this.textBox1.Text = rdr["CountryName"].ToString();


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
                this.Visible = true;
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void additionalInfobutton_Click(object sender, EventArgs e)
        {

        }

        private void ForeignPerson_Load(object sender, EventArgs e)
        {
            maritalcomboload();
            GendercomboBoxLoad();
            ReligioncomboBoxLoad();
            jobtitlecomboload();
            Specializationcomboload();
            nUserId = frmLogin.uId.ToString();

        }


        private void jobtitlecomboload()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select JobTitleName from JobTitle";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {

                cmbJobTitleForeign.Items.Add(rdr.GetString(0));

            }

            con.Close();

        }

        private void Specializationcomboload()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select RTRIM(Specializations.Specialization) from Specializations  where Specializations.Specialization is not null ";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                cmbSpecialization.Items.Add(rdr[0]);
            }
            //cmbSpecialization.Items.Add("Not In The List");
            con.Close();

        }



        private void maritalcomboload()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select MaritalStatusName from MaritalStatus";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {

                maritalStatuscomboBox.Items.Add(rdr.GetString(0));
            
            }

            con.Close();

        }


        private void GendercomboBoxLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select GenderName from Gender";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {

                GendercomboBox.Items.Add(rdr.GetString(0));

            }

            con.Close();

        }

        private void ReligioncomboBoxLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select ReligionName from Religion";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {

                ReligioncomboBox.Items.Add(rdr.GetString(0));

            }

            con.Close();

        }

        private void cmbJobTitleForeign_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qq = "select JobTitleId from JobTitle where JobTitleName = '" + cmbJobTitleForeign.Text + "'";
            cmd = new SqlCommand(qq,con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                jobTitleId = rdr.GetInt32(0);
            }
            con.Close();
            
        }

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qq = "select SpecializationsId from Specializations where Specialization = '" + cmbSpecialization.Text + "'";
            cmd = new SqlCommand(qq, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                specializationId = rdr.GetInt32(0);
            }
            con.Close();
            
        }

        private void clearPersonForm()
        {
            txtPersonNameForeign.Clear();
            textNickNameForeign.Clear();
            textFatherNameForeign.Clear();
            textMotherNameForeign.Clear();
            textBoxEmailForeign.Clear();
            companyNametextBox.Clear();
            txtWebSiteForeign.Clear();
            cmbJobTitleForeign.Items.Clear();
            maritalcomboload();
            GendercomboBox.Items.Clear();
            ReligioncomboBox.Items.Clear();
            fApartmentTextBox.Clear();
            fStreetTextBox.Clear();
            fCityTextBox.Clear();
            textBox1.Clear();
            fStateTextBox.Clear();
            fZipTextBox.Clear();
            fLandmarkTextBox.Clear();




            
           
            
            
            //LOAD

            //ForeignPerson_Load();
            jobtitlecomboload();
            Specializationcomboload();
            maritalcomboload();
            GendercomboBoxLoad();
            ReligioncomboBoxLoad();
            

        }

        private void Envelopbutton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            //ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            //paramField.Name = "GroupName";

            //set the parameter value
            // paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            //paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22_try_Spe";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            EnvelopSizeForeignPersonalAddressDetails cr = new EnvelopSizeForeignPersonalAddressDetails();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                //creating an object of ParameterField class
                //ParameterField paramField = new ParameterField();

                //creating an object of ParameterFields class
                //ParameterFields paramFields = new ParameterFields();

                //creating an object of ParameterDiscreteValue class
                //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                //set the parameter field name
                //paramField.Name = "GroupName";

                //set the parameter value
                // paramDiscreteValue.Value = x;

                //add the parameter value in the ParameterField object
                //paramField.CurrentValues.Add(paramDiscreteValue);

                //add the parameter in the ParameterFields object
                //paramFields.Add(paramField);

                //set the parameterfield information in the crystal report



                ReportViewer f2 = new ReportViewer();
                TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
                TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
                ConnectionInfo reportConInfo = new ConnectionInfo();
                Tables tables = default(Tables);
                //	Table table = default(Table);
                var with1 = reportConInfo;
                with1.ServerName = "tcp:KyotoServer,49172";
                with1.DatabaseName = "PhoneBookDBKD22_try_Spe";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                ForeignPersonalAddressDetailsEidGreetings cr = new ForeignPersonalAddressDetailsEidGreetings();
                tables = cr.Database.Tables;
                foreach (Table table in tables)
                {
                    reportLogonInfo = table.LogOnInfo;
                    reportLogonInfo.ConnectionInfo = reportConInfo;
                    table.ApplyLogOnInfo(reportLogonInfo);
                }
                //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
                //set the parameterfield information in the crystal report
                f2.crystalReportViewer1.ReportSource = cr;
                this.Visible = false;
                f2.ShowDialog();
                this.Visible = true;
            }
        }


    }
}
