using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using QRCoder;

namespace PhonebookApp.UI
{
    public partial class UpdatePersonInfo : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public Nullable<Int64> groupid, relationshipId, bankEmailId, categoryId, jobTitleId, companyId, specializationId, professionId, ageGroupId, educationLevelId, highestDegreeId, religionId, genderId, maritalStatusId;
        //public string nUserId;
        public int currentPersonId, affectedRows1, affectedRows2, affectedRows3, rAdistrictid, wAdistrictid;
        public UpdatePersonInfo()
        {
            InitializeComponent();
        }

        private void UpdatePersonInfo_Load(object sender, EventArgs e)
        {
            FillCountry();
            //CountrycomboBox.SelectedItem = "Bangladesh";
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
            FillGroupName();            
            FillRADivisionCombo();
            FillGender();
            FillReligion();
            FillMaritalStatus();
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
        public void FillCountry()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Countries.CountryName) from Countries  order by Countries.CountryId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CountrycomboBox.Items.Add(rdr[0]);
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select RTRIM(CountryId) from Countries  where  Countries.CountryName='" +
                             CountrycomboBox.Text + "' ";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    countryid = (rdr.GetString(0));
                    //countryid = rdr.GetInt32(0);

                }

                //CountrycomboBox.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string ct = "select RTRIM(HighestDegrees.HighestDegree) from HighestDegrees  order by HighestDegrees.HighestDegreeId";
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

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText =
                    "SELECT CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName,CorporateAddresses.RoadName,Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN CorporateAddresses ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Divisions INNER JOIN Districts ON Divisions.Division_ID = Districts.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID where CompanyId= '" +
                    companyId + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtWAFlatName.Text = rdr["CFlatNo"].ToString();
                    txtWAHouseName.Text = rdr["CHouseNo"].ToString();
                    txtWARoadNo.Text = rdr["CRoadNo"].ToString();
                    txtWABlock.Text = rdr["CBlock"].ToString();
                    txtWAArea.Text = rdr["CArea"].ToString();
                    LandmarktextBox.Text = rdr["CLandmark"].ToString();
                    txtWAContactNo.Text = rdr["CContactNo"].ToString();
                    WABuildingNametextBox.Text = rdr["BuildingName"].ToString();
                    WARoadNametextBox.Text = rdr["RoadName"].ToString();
                    WAdivisiontextBox.Text = rdr["Division"].ToString();
                    WADistricttextBox.Text = rdr["District"].ToString();
                    WAThanatextBox.Text = rdr["Thana"].ToString();
                    WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
                    txtWAPostCode.Text = rdr["PostCode"].ToString();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }




                //con.Close();
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
       


        private void FillGender()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Gender.GenderName) from Gender  order by Gender.GenderId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    GendercomboBox.Items.Add(rdr[0]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FillMaritalStatus()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(MaritalStatus.MaritalStatusName) from MaritalStatus  order by MaritalStatus.MaritalStatusId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    maritalStatuscomboBox.Items.Add(rdr[0]);
                }

                con.Close();
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

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetWorkingAddress();



            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select CompanyId from Company  where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    //companyId = (rdr.GetString(0));
                    companyId = Convert.ToInt64(rdr["CompanyId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //} 
            FillWorkingAddress();
        }
       
        private void FillWorkingAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText =
                    "SELECT CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN CorporateAddresses ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Divisions INNER JOIN Districts ON Divisions.Division_ID = Districts.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID where CompanyId= '" +
                    companyId + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtWAFlatName.Text = rdr["CFlatNo"].ToString();
                    txtWAHouseName.Text = rdr["CHouseNo"].ToString();
                    txtWARoadNo.Text = rdr["CRoadNo"].ToString();
                    txtWABlock.Text = rdr["CBlock"].ToString();
                    txtWAArea.Text = rdr["CArea"].ToString();
                    LandmarktextBox.Text = rdr["CLandmark"].ToString();
                    txtWAContactNo.Text = rdr["CContactNo"].ToString();

                    WAdivisiontextBox.Text = rdr["Division"].ToString();
                    WADistricttextBox.Text = rdr["District"].ToString();
                    WAThanatextBox.Text = rdr["Thana"].ToString();
                    WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
                    txtWAPostCode.Text = rdr["PostCode"].ToString();

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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (CountrycomboBox.Text == "Bangladesh")
            {

                if (unKnownRA.Checked == false)
                {
                    UpdatePersonDetails();
                    UpdateWorkingAddress("ResidentialAddresses");
                    if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                    {
                        UpdateInfo();
                    }
                    MessageBox.Show("Updated successfully", "Record", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Reset1();
                    //CountrycomboBox.SelectedItem = "Bangladesh";
                    CountrycomboBox.Enabled = true;
                    EmailAddress();
                    cmbEmailAddress.ResetText();
                    FillCompanyName();
                    cmbCompanyName.ResetText();
                    FillJobTitle();
                    cmbJobTitle.ResetText();
                    FillGroupName();
                    GroupNamecomboBox.ResetText();
                    FillSpecialization();
                    cmbSpecialization.ResetText();
                    FillProfession();
                    cmbProfession.ResetText();
                    FillEducationLevel();
                    cmbEducationalLevel.ResetText();
                    FillHighestDegree();
                    cmbHighestDegree.ResetText();
                    FillAgeGroup();
                    cmbAgeGroup.ResetText();
                    FillRelationShip();
                    cmbRelationShip.ResetText();
                    unKnownRA.Checked = false;
                    groupBox7.Hide();
                    btnInsert.Hide();
                }
                else
                {
                    UpdatePersonDetails();
                    if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                    {
                        UpdateInfo();
                    }

                    MessageBox.Show("Updated successfully", "Record", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Reset1();
                    
                    CountrycomboBox.Enabled = true;
                    EmailAddress();
                    cmbEmailAddress.ResetText();
                    FillCompanyName();
                    cmbCompanyName.ResetText();
                    FillJobTitle();
                    cmbJobTitle.ResetText();
                    FillGroupName();
                    GroupNamecomboBox.ResetText();
                    FillSpecialization();
                    cmbSpecialization.ResetText();
                    FillProfession();
                    cmbProfession.ResetText();
                    FillEducationLevel();
                    cmbEducationalLevel.ResetText();
                    FillHighestDegree();
                    cmbHighestDegree.ResetText();
                    FillAgeGroup();
                    cmbAgeGroup.ResetText();
                    FillRelationShip();
                    cmbRelationShip.ResetText();
                    unKnownRA.Checked = false;
                    groupBox7.Hide();
                    btnInsert.Hide();
                   
                }
               
            }
            else
            {
                UpdatePersonDetails();
                UpdateForeignAddresses("ForeignAddress");
                if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                {
                    UpdateInfo();
                }
                MessageBox.Show("Updated successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset2();
                CountrycomboBox.Enabled = true;
                ResetWorkingAddress();
                EmailAddress();
                FillCompanyName();
                cmbCompanyName.ResetText();
                FillJobTitle();
                FillGroupName();
                GroupNamecomboBox.ResetText();
                FillSpecialization();
                FillProfession();
                FillEducationLevel();
                FillHighestDegree();
                FillAgeGroup();
                FillRelationShip();
                groupBox7.Hide();
                groupBox3.Show();
            }
        }

        private void UpdatePersonDetails()
        {
            SqlParameter p;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String query =
                "Update Persons set PersonName=@d1,NickName=@d2,FatherName=@d3,EmailBankId=@d4,CompanyId==@d5,JobTitleId=@d6,GroupId=@d7,SpecializationsId=@d8,ProfessionId=@d9,EducationLevelId=@d10,HighestDegreeId=@d11,AgeGroupId=@d12,RelationShipsId=@d13,Website=@d14,SkypeId=@d15,WhatsAppId=@d16,ImoNumber=@d17,CountryId=@d18,ReligionId=@d19,GenderId=@d20,MaritalStatusId=@d21,DateOfBirth=@d22,MarriageAnniversaryDate=@d23,UserId=@d24,Picture=@d25 where Persons.PersonsId='" +
                PersonIdtextBox.Text + "'"; 
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d1", txtPersonName.Text);
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(textNickName.Text) ? (object)DBNull.Value : textNickName.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text));

            cmd.Parameters.AddWithValue("@d4", (object)bankEmailId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d5", (object)companyId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d6", (object)jobTitleId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d7", (object)groupid ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d8", (object)specializationId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d9", (object)professionId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d10", (object)educationLevelId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d11", (object)highestDegreeId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d12", (object)ageGroupId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d13", (object)relationshipId ?? DBNull.Value);
            cmd.Parameters.Add(new SqlParameter("@d14",
                string.IsNullOrEmpty(txtWebsite.Text) ? (object)DBNull.Value : txtWebsite.Text));
            cmd.Parameters.Add(new SqlParameter("@d15",
                string.IsNullOrEmpty(txtSkypeId.Text) ? (object)DBNull.Value : txtSkypeId.Text));
            cmd.Parameters.Add(new SqlParameter("@d16",
                string.IsNullOrEmpty(txtWhatsApp.Text) ? (object)DBNull.Value : txtWhatsApp.Text));
            cmd.Parameters.Add(new SqlParameter("@d17",
                string.IsNullOrEmpty(txtImmo.Text) ? (object)DBNull.Value : txtImmo.Text));

            cmd.Parameters.AddWithValue("@d18", (object)countryid ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d19", (object)religionId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d20", (object)genderId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d21", (object)maritalStatusId ?? DBNull.Value);
            cmd.Parameters.Add(new SqlParameter("@d22",
                !BirthdateTimePicker.Checked ? (object)DBNull.Value : BirthdateTimePicker.Value));
            cmd.Parameters.Add(new SqlParameter("@d23",
                !AnniversarydateTimePicker.Checked ? (object)DBNull.Value : AnniversarydateTimePicker.Value));
            cmd.Parameters.AddWithValue("@d24", nUserId);
            if (userPictureBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(userPictureBox.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                p = new SqlParameter("@d25", SqlDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
            }
            else
            {
                cmd.Parameters.Add("@d25", SqlDbType.VarBinary, -1);
                cmd.Parameters["@d25"].Value = DBNull.Value;
            }
            rdr = cmd.ExecuteReader();
            con.Close();

        }
        private string GetQrdata()
        {
            string Qrdata = "Country:" + CountrycomboBox.Text + "\r\n";
            Qrdata += "Division:" + cmbRADivision.Text + "\r\n";
            Qrdata += "District:" + cmbRADistrict.Text + "\r\n";
            Qrdata += "Thana:" + cmbRAThana.Text + "\r\n";
            Qrdata += "Post:" + cmbRAPost.Text + "\r\n";
            Qrdata += "Post Code:" + txtRAPostCode.Text + "\r\n";
            Qrdata += "Area / Village :" + (string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text) +
                      "\r\n";
            Qrdata += "Block/Sector/Zone:" + (string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text) +
                      "\r\n";
            Qrdata += "Nearest Landmark:" + (string.IsNullOrEmpty(nearestLandMarkTextBox.Text)
                          ? (object)DBNull.Value
                          : nearestLandMarkTextBox.Text) + "\r\n";
            Qrdata += "Road Name:" +
                      (string.IsNullOrEmpty(roadNameTextBox.Text) ? (object)DBNull.Value : roadNameTextBox.Text) + "\r\n";
            Qrdata += "Road#:" + (string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text) + "\r\n";
            Qrdata += "Building Name:" + (string.IsNullOrEmpty(buildingNameTextBox.Text)
                          ? (object)DBNull.Value
                          : buildingNameTextBox.Text) + "\r\n";
            Qrdata += "Holding#:" + (string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text) +
                      "\r\n";
            Qrdata += "Flat or Level#:" + (string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text) +
                      "\r\n";
            Qrdata += "Contact#:" + (string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text);
            return Qrdata;
        }

        private void UpdateWorkingAddress(string tblName1)
        {
            string tableName = tblName1;

            if (tableName == "ResidentialAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "Update " + tableName +
                                 " set PostOfficeId=@d2,RFlatNo=@d3,RHouseNo==@d4,RRoadNo=@d5,RBlock=@d6,RArea=@d7,RContactNo=@d8,BuildingName=@d9,RoadName=@d10,LandMark=@d11,AdressQR=@d12 where ResidentialAddresses.PersonsId='" +
                                 PersonIdtextBox.Text + "'";
                                 
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(postofficeIdRA) ? (object)DBNull.Value : postofficeIdRA));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d8",
                    string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d9",
                    string.IsNullOrEmpty(buildingNameTextBox.Text) ? (object)DBNull.Value : buildingNameTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d10",
                    string.IsNullOrEmpty(roadNameTextBox.Text) ? (object)DBNull.Value : roadNameTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d11",
                    string.IsNullOrEmpty(nearestLandMarkTextBox.Text) ? (object)DBNull.Value : nearestLandMarkTextBox.Text));
                var Qrdata = GetQrdata();
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
                //qrCode.GetGraphic()
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d12", SqlDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
                rdr = cmd.ExecuteReader();
                con.Close();
            }
        }

        private void UpdateInfo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update GroupMember set GroupId=@d1,UserId=@d2 where GroupMember.PersonsId='" +
                               PersonIdtextBox.Text + "'";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", (object)groupid ?? DBNull.Value);               
                cmd.Parameters.AddWithValue("@d2", nUserId);
                rdr = cmd.ExecuteReader();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateForeignAddresses(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qury = "Update " + tableName + " set Street=@d1,State=@d2,PostalCode@d3 where ForeignAddress.PersonsId='" +
                          PersonIdtextBox.Text + "'";
            cmd = new SqlCommand(Qury);
            cmd.Connection = con;
            
            cmd.Parameters.Add(new SqlParameter("@d1",
                string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(PostalCodetextBox.Text) ? (object)DBNull.Value : PostalCodetextBox.Text));
            rdr = cmd.ExecuteReader();
            con.Close();
        }

        private void Reset1()
        {
            PersonIdtextBox.Clear();
            relationshipId = bankEmailId = groupid = jobTitleId = companyId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();           
            cmbEmailAddress.SelectedIndex = -1;
            cmbCompanyName.Items.Clear();           
            cmbCompanyName.SelectedIndex = -1;
            GroupNamecomboBox.Items.Clear();           
            GroupNamecomboBox.SelectedIndex = -1;
            cmbAgeGroup.Items.Clear();          
            cmbAgeGroup.SelectedIndex = -1;
            cmbProfession.Items.Clear();            
            cmbProfession.SelectedIndex = -1;
            cmbEducationalLevel.Items.Clear();           
            cmbEducationalLevel.SelectedIndex = -1;
            cmbHighestDegree.Items.Clear();
            cmbHighestDegree.SelectedIndex = -1;
            cmbJobTitle.Items.Clear();
            cmbJobTitle.SelectedIndex = -1;
            cmbSpecialization.Items.Clear();
            cmbSpecialization.SelectedIndex = -1;
            cmbRelationShip.Items.Clear();          
            cmbRelationShip.SelectedIndex = -1;
            txtWebsite.Clear();
            txtSkypeId.Clear();
            txtWhatsApp.Clear();
            txtImmo.Clear();
            ResetResidentialAddress();
            ResetWorkingAddress();
            ResetAdditionalInformation();
        }
        private void Reset2()
        {
            PersonIdtextBox.Clear();
            relationshipId = bankEmailId = groupid = jobTitleId = companyId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();           
            cmbEmailAddress.SelectedIndex = -1;
            cmbCompanyName.Items.Clear();          
            cmbCompanyName.SelectedIndex = -1;
            GroupNamecomboBox.Items.Clear();          
            GroupNamecomboBox.SelectedIndex = -1;
            cmbAgeGroup.Items.Clear();         
            cmbAgeGroup.SelectedIndex = -1;
            cmbProfession.Items.Clear();        
            cmbProfession.SelectedIndex = -1;
            cmbEducationalLevel.Items.Clear();          
            cmbEducationalLevel.SelectedIndex = -1;
            cmbHighestDegree.Items.Clear();          
            cmbHighestDegree.SelectedIndex = -1;
            cmbJobTitle.Items.Clear();          
            cmbJobTitle.SelectedIndex = -1;
            cmbSpecialization.Items.Clear();          
            cmbSpecialization.SelectedIndex = -1;
            cmbRelationShip.Items.Clear();        
            cmbRelationShip.SelectedIndex = -1;
            txtWebsite.Clear();
            txtSkypeId.Clear();
            txtWhatsApp.Clear();
            txtImmo.Clear();
            ResetForeignAddress();
            ResetAdditionalInformation();
        }

        public void ResetForeignAddress()
        {
            StreettextBox.Clear();
            StatetextBox.Clear();
            PostalCodetextBox.Clear();
        }

        public void ResetResidentialAddress()
        {
            txtRAFlatNo.Clear();
            txtRAHouseNo.Clear();
            txtRARoadNo.Clear();
            txtRABlock.Clear();
            txtRAArea.Clear();
            txtRAContactNo.Clear();
            buildingNameTextBox.Clear();
            roadNameTextBox.Clear();
            nearestLandMarkTextBox.Clear();
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
            LandmarktextBox.Clear();
            WABuildingNametextBox.Clear();
            WARoadNametextBox.Clear();  
            txtWAPostCode.Clear();
            WAPostOfficetextBox.Clear();
            WAThanatextBox.Clear();
            WADistricttextBox.Clear();
            WAdivisiontextBox.Clear();
        }

        public void ResetAdditionalInformation()
        {
            BirthdateTimePicker.ResetText();
            GendercomboBox.SelectedIndex = -1;
            ReligioncomboBox.SelectedIndex = -1;
            maritalStatuscomboBox.SelectedIndex = -1;
            AnniversarydateTimePicker.ResetText();
        }

        private void unKnownRA_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownRA.Checked == true)
            {
                Reset2Star();
                groupBox5.Enabled = false;
                ResetResidentialAddress();


            }
            else
            {

                groupBox5.Enabled = true;
                groupBox5.Enabled = true;
                FillStar2();
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

        private void cmbCompanyName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ResetWorkingAddress();



            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select CompanyId from Company  where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    //companyId = (rdr.GetString(0));
                    companyId = Convert.ToInt64(rdr["CompanyId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //} 
            FillWorkingAddress();
        }

        private void cmbRADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRADistrict.Items.Clear();
            cmbRADistrict.ResetText();
            cmbRAThana.Items.Clear();
            cmbRAThana.ResetText();
            cmbRAPost.Items.Clear();
            cmbRAPost.ResetText();

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
                cmbRADistrict.Items.Clear();
                cmbRADistrict.ResetText();
                cmbRAThana.Items.Clear();
                cmbRAThana.ResetText();
                cmbRAThana.SelectedIndex = -1;
                cmbRAPost.Items.Clear();
                cmbRAPost.ResetText();
                cmbRAPost.SelectedIndex = -1;
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
            cmbRAThana.Enabled = false;
            cmbRAPost.Enabled = false;
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
                cmbRAThana.Items.Clear();
                cmbRAThana.ResetText();
                cmbRAPost.Items.Clear();
                cmbRAPost.ResetText();
                cmbRAPost.SelectedIndex = -1;
                cmbRAPost.Enabled = false;
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

        private void cmbRAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select D_ID from Districts WHERE District= '" + cmbRADistrict.Text + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                rAdistrictid = rdr.GetInt32(0);
                //districtIdRA = (rdr.GetString(0));
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
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + rAdistrictid + "'";
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
                cmbRAPost.ResetText();
                // cPostOfficeCombo.Text = "";
                txtRAPostCode.Clear();
                cmbRAPost.Enabled = true;
                cmbRAPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdC + "' order by PostOffice.T_ID desc";
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
            cmbRAPost.SelectedIndex = -1;

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

    }
}
