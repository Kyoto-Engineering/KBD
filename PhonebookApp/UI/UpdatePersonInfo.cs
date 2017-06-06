using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using QRCoder;

namespace PhonebookApp.UI
{
    public partial class UpdatePersonInfo : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string companyId;
        public string countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public Nullable<Int64> groupid, relationshipId, bankEmailId, categoryId, jobTitleId, specializationId, professionId, ageGroupId, educationLevelId, highestDegreeId, religionId, genderId, maritalStatusId;
        //public string nUserId;
        public int currentPersonId, affectedRows1, affectedRows2, affectedRows3, rAdistrictid, wAdistrictid;
        private delegate void ChangeFocusDelegate(Control ctl);
        public UpdatePersonInfo()
        {
            InitializeComponent();
        }

        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        public void UpdatePersonInfo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        public void LoadControls()
        {
            FillCountry();
            //CountrycomboBox.SelectedItem = "Bangladesh";
            FillRelationShip();
            FillJobTitle();
            FillAgeGroup();
            //FillCompanyName();
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
            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select RTRIM(Company.CompanyName) from Company  order by Company.CompanyId";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        cmbCompanyName.Items.Add(rdr[0]);
            //    }

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = con.CreateCommand();

            //    cmd.CommandText =
            //        "SELECT CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName,CorporateAddresses.RoadName,Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN CorporateAddresses ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Divisions INNER JOIN Districts ON Divisions.Division_ID = Districts.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID where CompanyId= '" +
            //        companyId + "'";

            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        txtWAFlatName.Text = rdr["CFlatNo"].ToString();
            //        txtWAHouseName.Text = rdr["CHouseNo"].ToString();
            //        txtWARoadNo.Text = rdr["CRoadNo"].ToString();
            //        txtWABlock.Text = rdr["CBlock"].ToString();
            //        txtWAArea.Text = rdr["CArea"].ToString();
            //        LandmarktextBox.Text = rdr["CLandmark"].ToString();
            //        txtWAContactNo.Text = rdr["CContactNo"].ToString();
            //        WABuildingNametextBox.Text = rdr["BuildingName"].ToString();
            //        WARoadNametextBox.Text = rdr["RoadName"].ToString();
            //        WAdivisiontextBox.Text = rdr["Division"].ToString();
            //        WADistricttextBox.Text = rdr["District"].ToString();
            //        WAThanatextBox.Text = rdr["Thana"].ToString();
            //        WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
            //        txtWAPostCode.Text = rdr["PostCode"].ToString();

            //    }
            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }




            //    //con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            //ResetWorkingAddress();



            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select CompanyId from Company  where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    if (rdr.Read())
            //    {
            //        //companyId = (rdr.GetString(0));
            //        companyId = Convert.ToInt64(rdr["CompanyId"]);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ////} 
            //FillWorkingAddress();
        }

        //private void FillWorkingAddress()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        cmd = con.CreateCommand();

        //        cmd.CommandText =
        //            "SELECT CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN CorporateAddresses ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Divisions INNER JOIN Districts ON Divisions.Division_ID = Districts.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID where CompanyId= '" +
        //            companyId + "'";

        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            txtWAFlatName.Text = rdr["CFlatNo"].ToString();
        //            txtWAHouseName.Text = rdr["CHouseNo"].ToString();
        //            txtWARoadNo.Text = rdr["CRoadNo"].ToString();
        //            txtWABlock.Text = rdr["CBlock"].ToString();
        //            txtWAArea.Text = rdr["CArea"].ToString();
        //            LandmarktextBox.Text = rdr["CLandmark"].ToString();
        //            txtWAContactNo.Text = rdr["CContactNo"].ToString();

        //            WAdivisiontextBox.Text = rdr["Division"].ToString();
        //            WADistricttextBox.Text = rdr["District"].ToString();
        //            WAThanatextBox.Text = rdr["Thana"].ToString();
        //            WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
        //            txtWAPostCode.Text = rdr["PostCode"].ToString();

        //        }
        //        if ((rdr != null))
        //        {
        //            rdr.Close();
        //        }
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private bool ValidateControlls()
        {
            bool validate = true;

            if (string.IsNullOrWhiteSpace(txtPersonName.Text))
            {
                MessageBox.Show("Please Enter Person Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                txtPersonName.Focus();
            }

            else if (string.IsNullOrWhiteSpace(GendercomboBox.Text))
            {
                MessageBox.Show("Please Select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                GendercomboBox.Focus();
            }
            else if (CountrycomboBox.Text == "Bangladesh")
            {

                if (unKnownRA.Checked == false)
                {

                    if (string.IsNullOrEmpty(cmbRADivision.Text))
                    {
                        MessageBox.Show(@"Please select division", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        validate = false;
                        cmbRADivision.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbRADistrict.Text))
                    {
                        MessageBox.Show(@"Please Select district", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbRADistrict.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbRAThana.Text))
                    {
                        MessageBox.Show(@"Please select Thana", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        validate = false;
                        cmbRAThana.Focus();
                    }

                    else if (string.IsNullOrWhiteSpace(cmbRAPost.Text))
                    {
                        MessageBox.Show(@"Please Select Post Office", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbRAPost.Focus();
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(StreettextBox.Text) &&
                    string.IsNullOrWhiteSpace(StatetextBox.Text) &&
                    string.IsNullOrWhiteSpace(PostalCodetextBox.Text))
                {
                    MessageBox.Show("Please enter Addresses!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    StreettextBox.Focus();
                }
            }
            if (!ValidatePersonAddress())
            {
                validate = false;
            }
            return validate;
        }


        private bool ValidatePersonAddress()
        {
            string ct3;
            string address;
            List<PersonAddress> personAddresses = new List<PersonAddress>();
            bool value = true;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            if (CountrycomboBox.Text == "Bangladesh")
            {
                ct3 =
                    "select Persons.PersonName, EmailBank.Email, Company.CompanyName, Persons.WhatsAppId, isnull(nullif(ResidentialAddresses.RFlatNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RHouseNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RRoadNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RBlock,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RArea,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RContactNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.LandMark,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Persons Left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Company ON Persons.CompanyId = Company.CompanyId left JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId Left JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId Left JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID Left JOIN Districts ON Thanas.D_ID = Districts.D_ID where Persons.PersonName='" +
                    txtPersonName.Text + "' and Persons.PersonsId <>'" + PersonIdtextBox.Text + "'";

            }
            else
            {
                ct3 =
                    "select Persons.PersonName, EmailBank.Email, Company.CompanyName, Persons.WhatsAppId, isnull(nullif(ForeignAddress.Street,\'\') + \', \',\'\') + isnull(nullif(ForeignAddress.State,\'\') + \', \',\'\') + isnull(nullif(ForeignAddress.PostalCode,\'\') + \', \',\'\') as Addresss FROM Persons Left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Company ON Persons.CompanyId = Company.CompanyId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId where Persons.PersonName='" + txtPersonName.Text + "' and Persons.PersonsId <>'" + PersonIdtextBox.Text + "'";

            }
            cmd = new SqlCommand(ct3, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    PersonAddress x = new PersonAddress();
                    x.Person = rdr.GetString(0);

                    if (!DBNull.Value.Equals(rdr["Email"]))
                    {
                        x.Email = rdr.GetString(1);
                    }
                    else
                    {
                        x.Email = null;
                    }

                    if (!DBNull.Value.Equals(rdr["CompanyName"]))
                    {
                        x.Company = rdr.GetString(2);
                    }
                    else
                    {
                        x.Company = null;
                    }

                    if (!DBNull.Value.Equals(rdr["WhatsAppId"]))
                    {
                        x.Phone = rdr.GetString(3);
                    }
                    else
                    {
                        x.Phone = null;
                    }
                    //x.Address = rdr.GetString(4);
                    if (!DBNull.Value.Equals(rdr["Addresss"]))
                    {
                        x.Address = rdr.GetString(4);
                    }
                    else
                    {
                        x.Address = null;
                    }
                    personAddresses.Add(x);
                }
            }
            if (CountrycomboBox.Text == "Bangladesh")
            {
                address = string.IsNullOrWhiteSpace(txtRAFlatNo.Text) ? "" : (txtRAFlatNo.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRAHouseNo.Text) ? "" : (txtRAHouseNo.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRARoadNo.Text) ? "" : (txtRARoadNo.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRABlock.Text) ? "" : (txtRABlock.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRAArea.Text) ? "" : (txtRAArea.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRAContactNo.Text) ? "" : (txtRAContactNo.Text + ", ");
                address += string.IsNullOrWhiteSpace(buildingNameTextBox.Text) ? "" : (buildingNameTextBox.Text + ", ");
                address += string.IsNullOrWhiteSpace(roadNameTextBox.Text) ? "" : (roadNameTextBox.Text + ", ");
                address += string.IsNullOrWhiteSpace(nearestLandMarkTextBox.Text) ? "" : (nearestLandMarkTextBox.Text + ", ");
                address += string.IsNullOrWhiteSpace(cmbRAPost.Text) ? "" : (cmbRAPost.Text + ", ");
                address += string.IsNullOrWhiteSpace(txtRAPostCode.Text) ? "" : (txtRAPostCode.Text + ", ");
                address += string.IsNullOrWhiteSpace(cmbRAThana.Text) ? "" : (cmbRAThana.Text + ", ");
                address += string.IsNullOrWhiteSpace(cmbRADistrict.Text) ? "" : (cmbRADistrict.Text);
            }
            else
            {
                address = string.IsNullOrWhiteSpace(StreettextBox.Text) ? "" : (StreettextBox.Text + ", ");
                address += string.IsNullOrWhiteSpace(StatetextBox.Text) ? "" : (StatetextBox.Text + ", ");
                address += string.IsNullOrWhiteSpace(PostalCodetextBox.Text) ? "" : (PostalCodetextBox.Text + ", ");
            }
            foreach (PersonAddress p in personAddresses)
            {
                if (p.Person == txtPersonName.Text && p.Address == address)
                {
                    DialogResult dialogResult = MessageBox.Show("This Person name and Address already Exist.Do you Want to Continue? ", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        if (CountrycomboBox.Text == "Bangladesh")
                        {
                            ResetResidentialAddress();
                        }
                        else
                        {
                            ResetForeignAddress();
                        }
                        txtPersonName.Clear();
                        txtPersonName.Focus();
                        con.Close();
                        value = false;
                        break;
                    }
                }

                if (p.Person == txtPersonName.Text && p.Email == cmbEmailAddress.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("This Person name and Email already Exist.Do you Want to Continue? ", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        //MessageBox.Show(@"This Person name and Email Address already Exist,Please Input another one" + "\n",
                        //    "Error",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPersonName.Clear();
                        cmbEmailAddress.SelectedIndex = -1;
                        bankEmailId = null;
                        txtPersonName.Focus();
                        con.Close();
                        value = false;
                        break;
                    }
                    //else (dialogResult == DialogResult.Yes)
                    //{
                    //    value = true;
                    //}
                    
                }

                if (p.Person == txtPersonName.Text && p.Company == companyNametextBox.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("This Person name and Company already Exist.Do you Want to Continue? ", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        txtPersonName.Clear();
                        //cmbCompanyName.SelectedIndex = -1;
                        companyNametextBox.Clear();
                        ResetWorkingAddress();
                        companyId = null;
                        txtPersonName.Focus();
                        con.Close();
                        value = false;
                        break;
                    }
                }
                if (p.Person == txtPersonName.Text && p.Phone == txtWhatsApp.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("This Person name and Company already Exist.Do you Want to Continue? ", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        //MessageBox.Show(@"This Person name and Phone Number already Exist,Please Input another one" + "\n",
                        //    "Error",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPersonName.Clear();
                        txtWhatsApp.Clear();
                        txtPersonName.Focus();
                        con.Close();
                        value = false;
                        break;
                    }
                }

            }
            return value;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonName.Text) && string.IsNullOrEmpty(cmbEmailAddress.Text) &&
                string.IsNullOrEmpty(companyNametextBox.Text) && string.IsNullOrEmpty(txtWhatsApp.Text) &&
                (unKnownRA.Checked))
            {
                MessageBox.Show(@"Please insert Email or Company or Phone Number or Address", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (ValidateControlls())
            {
                if (CountrycomboBox.Text == "Bangladesh")
                {
                    if (unKnownRA.Checked == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("Aru You sure want to Update this Contact? ",
                            "Confirm",
                            MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
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
                            CountrycomboBox.SelectedIndex = -1;
                            CountrycomboBox.Enabled = false;
                            EmailAddress();
                            cmbEmailAddress.ResetText();
                            //FillCompanyName();
                            //cmbCompanyName.ResetText();
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
                            groupBox2.Visible = true;
                            groupBox2.Location=new Point(466,12);
                            groupBox3.Visible = false;
                            groupBox6.Visible = false;
                            groupBox7.Visible = true; 
                            groupBox7.Location=new Point(466,290);
                            btnInsert.Visible = false;
                            this.Close();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Aru You sure want to Update this Contact? ",
                            "Confirm",
                            MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            UpdatePersonDetails();
                            if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                            {
                                UpdateInfo();
                            }

                            MessageBox.Show("Updated successfully", "Record", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Reset1();
                            CountrycomboBox.SelectedIndex = -1;
                            CountrycomboBox.Enabled = false;
                            EmailAddress();
                            cmbEmailAddress.ResetText();
                            //FillCompanyName();
                            //cmbCompanyName.ResetText();
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
                            groupBox2.Visible = true;
                            groupBox2.Location = new Point(466, 12);
                            groupBox3.Visible = false;
                            groupBox6.Visible = false;
                            groupBox7.Visible = true;
                            groupBox7.Location = new Point(466, 290);
                            btnInsert.Visible = false;
                            this.Close();
                        }
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Aru You sure want to Update this Contact? ", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdatePersonDetails();
                        UpdateForeignAddresses("ForeignAddress");
                        if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                        {
                            UpdateInfo();
                        }
                        MessageBox.Show("Updated successfully", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset2();
                        CountrycomboBox.SelectedIndex = -1;
                        CountrycomboBox.Enabled = false;
                        ResetWorkingAddress();
                        EmailAddress();
                        //FillCompanyName();
                        //cmbCompanyName.ResetText();
                        FillJobTitle();
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
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox6.Visible = true;
                        groupBox7.Location = new Point(466, 12);
                        groupBox7.Visible = true;
                        groupBox7.Location = new Point(466, 155);
                        btnInsert.Visible = false;
                        this.Close();
                    }
                }
            }
        }

        private void UpdatePersonDetails()
        {
            SqlParameter p;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String query =
                "Update Persons set PersonName=@d1,NickName=@d2,FatherName=@d3,EmailBankId=@d4,CompanyId=@d5,JobTitleId=@d6,SpecializationsId=@d8,ProfessionId=@d9,EducationLevelId=@d10,HighestDegreeId=@d11,AgeGroupId=@d12,RelationShipsId=@d13,Website=@d14,SkypeId=@d15,WhatsAppId=@d16,ImoNumber=@d17,CountryId=@d18,ReligionId=@d19,GenderId=@d20,MaritalStatusId=@d21,DateOfBirth=@d22,MarriageAnniversaryDate=@d23,UserId=@d24,Picture=@d25 where Persons.PersonsId='" +
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
            //cmd.Parameters.AddWithValue("@d7", (object)groupid ?? DBNull.Value);
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

        private string GetFQrdata()
        {
            string Qrdata = "Country:" + CountrycomboBox.Text + "\r\n";
            Qrdata +=
                "Street:" + (string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text) +
                "\r\n";

            Qrdata +=
                "State:" + (string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text) +
                "\r\n";
            Qrdata +=
                "Postal Code:" + (string.IsNullOrEmpty(PostalCodetextBox.Text) ? (object)DBNull.Value : PostalCodetextBox.Text) +
                "\r\n";
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
                                 " set PostOfficeId=@d2,RFlatNo=@d3,RHouseNo=@d4,RRoadNo=@d5,RBlock=@d6,RArea=@d7,RContactNo=@d8,BuildingName=@d9,RoadName=@d10,LandMark=@d11,AdressQR=@d12 where ResidentialAddresses.PersonsId='" +
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
            string Qury = "Update " + tableName + " set Street=@d1,State=@d2,PostalCode=@d3,AdressQR=@d4 where ForeignAddress.PersonsId='" +
                          PersonIdtextBox.Text + "'";
            cmd = new SqlCommand(Qury);
            cmd.Connection = con;

            cmd.Parameters.Add(new SqlParameter("@d1",
                string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(PostalCodetextBox.Text) ? (object)DBNull.Value : PostalCodetextBox.Text));

            var Qrdata = GetFQrdata();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
            //qrCode.GetGraphic()
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] data = ms.GetBuffer();
            SqlParameter p = new SqlParameter("@d4", SqlDbType.VarBinary);
            p.Value = data;
            cmd.Parameters.Add(p);
            rdr = cmd.ExecuteReader();
            con.Close();
        }

        private void Reset1()
        {
            PersonIdtextBox.Clear();
            relationshipId = bankEmailId = groupid = jobTitleId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            companyNametextBox.Clear();
            //cmbCompanyName.Items.Clear();
            //cmbCompanyName.SelectedIndex = -1;
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
            userPictureBox.Image = null;
            ResetResidentialAddress();
            ResetWorkingAddress();
            ResetAdditionalInformation();
        }
        private void Reset2()
        {
            PersonIdtextBox.Clear();
            relationshipId = bankEmailId = groupid = jobTitleId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            companyNametextBox.Clear();
            //cmbCompanyName.Items.Clear();
            //cmbCompanyName.SelectedIndex = -1;
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
            userPictureBox.Image = null;
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
            //ResetWorkingAddress();
            //if (CountrycomboBox.Text == "Bangladesh")
            //{
            //    groupBox6.Hide();
            //    groupBox2.Show();
            //    groupBox2.Location = new Point(466, 12);
            //    groupBox3.Show();
            //    groupBox3.Location = new Point(466, 290);
            //    groupBox7.Show();
            //    groupBox7.Location = new Point(466, 534);
            //    btnInsert.Location = new Point(1045, 540);
            //}
            //else
            //{
            //    groupBox2.Hide();
            //    groupBox6.Show();
            //    groupBox6.Location = new Point(466, 12);
            //    groupBox3.Show();
            //    groupBox3.Location = new Point(466, 155);
            //    groupBox7.Show();
            //    groupBox7.Location = new Point(466, 410);
            //    btnInsert.Location=new Point(1045,416);
            //}
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select CompanyId from Company  where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    if (rdr.Read())
            //    {

            //        companyId = Convert.ToInt64(rdr["CompanyId"]);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //FillWorkingAddress();
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdRA + "' order by Districts.District asc";
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
                string ctk = "SELECT RTRIM(Districts.D_ID) FROM Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Districts.District=@find1 and Divisions.Division=@find2";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find1"].Value = cmbRADistrict.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find2"].Value = cmbRADivision.Text;
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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdRA + "' order by Thanas.Thana asc";
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
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //cmd = con.CreateCommand();

            //cmd.CommandText = "select D_ID from Districts WHERE District= '" + cmbRADistrict.Text + "'";

            //rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //    rAdistrictid = rdr.GetInt32(0);
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


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT RTRIM(Thanas.T_ID) FROM Thanas INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Thanas.Thana=@find1 and Districts.District=@find2 and Divisions.Division=@find3 AND Thanas.D_ID='" + districtIdRA + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find1"].Value = cmbRAThana.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find2"].Value = cmbRADistrict.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find3"].Value = cmbRADivision.Text;
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdRA + "' order by PostOffice.PostOfficeName asc";
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
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) FROM PostOffice INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where PostOffice.PostOfficeName=@find1 and  Thanas.Thana=@find2 and Districts.District=@find3 and Divisions.Division=@find4";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find1"].Value = cmbRAPost.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find2"].Value = cmbRAThana.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find3"].Value = cmbRADistrict.Text;
                cmd.Parameters.Add(new SqlParameter("@find4", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find4"].Value = cmbRADivision.Text;
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

        private void pictureBrowseButton_Click(object sender, EventArgs e)
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
                        pictureBrowseButton.Focus();
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

        private void CountrycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountrycomboBox.Text == "Bangladesh")
            {
                if (string.IsNullOrEmpty(companyNametextBox.Text))
                {
                    groupBox6.Hide();
                    groupBox2.Show();
                    groupBox7.Location = new Point(466, 12);
                    groupBox3.Hide();
                    groupBox7.Show();
                    groupBox7.Location = new Point(466, 295);
                    btnInsert.Location = new Point(860, 440);
                }
                else
                {
                    groupBox6.Hide();
                    groupBox2.Show();
                    groupBox7.Location = new Point(466, 12);
                    groupBox3.Show();
                    groupBox3.Location = new Point(466, 290);
                    groupBox7.Show();
                    groupBox7.Location = new Point(466, 533);
                    btnInsert.Location = new Point(1045, 540);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(companyNametextBox.Text))
                {
                    groupBox2.Hide();
                    groupBox3.Hide();
                    groupBox6.Show();
                    groupBox7.Show();
                    groupBox6.Location = new Point(466, 12);
                    groupBox7.Location = new Point(466, 155);
                    btnInsert.Location = new Point(860, 310);
                }
                else
                {
                    groupBox2.Hide();
                    groupBox6.Show();
                    groupBox6.Location = new Point(466, 12);
                    groupBox3.Show();
                    groupBox3.Location = new Point(466, 155);
                    groupBox7.Show();
                    groupBox7.Location = new Point(466, 410);
                    btnInsert.Location = new Point(1045, 416);
                }
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(CountryId) from Countries  where  Countries.CountryName='" +
                            CountrycomboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    countryid = (rdr.GetString(0));

                }
                con.Close();
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
                //string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Email  Here", "Input Here", "", -1, -1);

                InputBoxValidation validation = delegate(string val)
                {
                    if (val == "")
                        return "Value cannot be empty.";
                    if (!(new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$")).IsMatch(val))
                        return "Email address is not valid.";
                    return "";
                };

                string input = null;
                if (InputBox.Show("Please Input Email Here", "Input Here", ref input, validation) == DialogResult.OK)
                {

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
                else
                {
                    cmbEmailAddress.SelectedIndex = -1;
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

                        bankEmailId = Convert.ToInt64(rdr["EmailBankId"]);
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

        private void cmbJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJobTitle.Text == "Not In The List")
            {
                //string inputj = Microsoft.VisualBasic.Interaction.InputBox("Please Input JobTitle  Here", "Input Here", "", -1, -1);
                string inputj = null;
                InputBox.Show("Please Input Job Title Here", "Inpute Here", ref inputj);
                if (string.IsNullOrWhiteSpace(inputj))
                {
                    cmbJobTitle.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select JobTitleName from JobTitle where JobTitleName='" + inputj + "'";
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
                            string query1 = "insert into JobTitle(JobTitleName,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputj);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbJobTitle.Items.Clear();
                            FillJobTitle();
                            cmbJobTitle.SelectedText = inputj;

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
                    string ct = "select JobTitleId from JobTitle  where  JobTitle.JobTitleName='" + cmbJobTitle.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        jobTitleId = Convert.ToInt64(rdr["JobTitleId"]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialization.Text == "Not In The List")
            {
                //string inputs = Microsoft.VisualBasic.Interaction.InputBox("Please Input Specialization  Here", "Input Here", "", -1, -1);
                string inputs = null;
                InputBox.Show("Please Input Specialization Here", "Inpute Here", ref inputs);
                if (string.IsNullOrWhiteSpace(inputs))
                {
                    cmbSpecialization.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Specialization from Specializations where Specialization='" + inputs + "'";
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
                            string query1 = "insert into Specializations(Specialization,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputs);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbSpecialization.Items.Clear();
                            FillSpecialization();
                            cmbSpecialization.SelectedText = inputs;

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
                    string ct = "select SpecializationsId from Specializations  where  Specializations.Specialization='" + cmbSpecialization.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        specializationId = Convert.ToInt64(rdr["SpecializationsId"]);
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
                //string inputp = Microsoft.VisualBasic.Interaction.InputBox("Please Input Profession  Here", "Input Here", "", -1, -1);
                string inputp = null;
                InputBox.Show("Please Input Profession Here", "Inpute Here", ref inputp);
                if (string.IsNullOrWhiteSpace(inputp))
                {
                    cmbProfession.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select ProfessionName from Profession where ProfessionName='" + inputp + "'";
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
                            string query1 = "insert into Profession(ProfessionName,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputp);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbProfession.Items.Clear();
                            FillProfession();
                            cmbProfession.SelectedText = inputp;

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
                    string ct = "select ProfessionId from Profession  where  Profession.ProfessionName='" + cmbProfession.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        professionId = Convert.ToInt64(rdr["ProfessionId"]);
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
                //string inpute = Microsoft.VisualBasic.Interaction.InputBox("Please Input EducationLevel  Here", "Input Here", "", -1, -1);
                string inpute = null;
                InputBox.Show("Please Input Education Level Here", "Inpute Here", ref inpute);
                if (string.IsNullOrWhiteSpace(inpute))
                {
                    cmbEducationalLevel.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select EducationLevelName from EducationLevel where EducationLevelName='" + inpute + "'";
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
                            string query1 = "insert into EducationLevel(EducationLevelName,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inpute);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbEducationalLevel.Items.Clear();
                            FillEducationLevel();
                            cmbEducationalLevel.SelectedText = inpute;

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
                    string ct = "select EducationLevelId from EducationLevel  where  EducationLevel.EducationLevelName='" + cmbEducationalLevel.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        educationLevelId = Convert.ToInt64(rdr["EducationLevelId"]);

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
            if (cmbHighestDegree.Text == "Not In The List")
            {
                //string inputx = Microsoft.VisualBasic.Interaction.InputBox("Please Input Highest Degree  Here", "Input Here", "", -1, -1);
                string inputx = null;
                InputBox.Show("Please Input Highest Degree Here", "Inpute Here", ref inputx);
                if (string.IsNullOrWhiteSpace(inputx))
                {
                    cmbHighestDegree.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select HighestDegree from HighestDegrees where HighestDegree='" + inputx + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This EducationLevel  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbHighestDegree.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into HighestDegrees(HighestDegree,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputx);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbHighestDegree.Items.Clear();
                            FillHighestDegree();
                            cmbHighestDegree.SelectedText = inputx;

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
                    string ct = "select HighestDegreeId from HighestDegrees  where  HighestDegrees.HighestDegree='" + cmbHighestDegree.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        highestDegreeId = Convert.ToInt64(rdr["HighestDegreeId"]);

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbAgeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgeGroup.Text == "Not In The List")
            {
                //string inputa = Microsoft.VisualBasic.Interaction.InputBox("Please Input EducationLevel  Here", "Input Here", "", -1, -1);
                string inputa = null;
                InputBox.Show("Please Input Age Group Here", "Inpute Here", ref inputa);
                if (string.IsNullOrWhiteSpace(inputa))
                {
                    cmbAgeGroup.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AgeGroupLevel from AgeGroup where AgeGroupLevel='" + inputa + "'";
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
                            string query1 = "insert into AgeGroup(AgeGroupLevel,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputa);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbAgeGroup.Items.Clear();
                            FillAgeGroup();
                            cmbAgeGroup.SelectedText = inputa;

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
                    string ct = "select AgeGroupId from AgeGroup  where  AgeGroup.AgeGroupLevel='" + cmbAgeGroup.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ageGroupId = Convert.ToInt64(rdr["AgeGroupId"]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbRelationShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRelationShip.Text == "Not In The List")
            {
                //string inputr = Microsoft.VisualBasic.Interaction.InputBox("Please Input RelationShips  Here", "Input Here", "", -1, -1);
                string inputr = null;
                InputBox.Show("Please Input Relationship Here", "Inpute Here", ref inputr);
                if (string.IsNullOrWhiteSpace(inputr))
                {
                    cmbRelationShip.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select RelationShip from RelationShips where RelationShip='" + inputr + "'";
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
                            string query1 = "insert into RelationShips(RelationShip,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputr);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbRelationShip.Items.Clear();
                            FillRelationShip();
                            cmbRelationShip.SelectedText = inputr;

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
                    string ct = "select RelationShipsId from  RelationShips  where  RelationShips.RelationShip='" + cmbRelationShip.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        relationshipId = Convert.ToInt64(rdr["RelationShipsId"]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GendercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select GenderId from Gender  where  Gender.GenderName='" + GendercomboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    genderId = Convert.ToInt64(rdr["GenderId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    maritalStatusId = Convert.ToInt64(rdr["MaritalStatusId"]);
                }
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

        private void cmbCompanyName_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cmbCompanyName.Text))
            //{
            //    ResetWorkingAddress();
            //    companyId = null;
            //    if (CountrycomboBox.Text == "Bangladesh")
            //    {
            //        groupBox3.Hide();
            //        groupBox7.Location = new Point(466, 295);
            //        btnInsert.Location = new Point(860, 440);
            //    }
            //    else
            //    {
            //        groupBox3.Hide();
            //        groupBox7.Location = new Point(466, 155);
            //        btnInsert.Location=new Point(860,310);
            //    }
            //}
        }

        private void cmbEmailAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {
                bankEmailId = null;
            }
        }

        private void cmbJobTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbJobTitle.Text))
            {
                jobTitleId = null;
            }
        }

        private void GroupNamecomboBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
            {
                groupid = null;
            }
        }

        private void cmbSpecialization_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSpecialization.Text))
            {
                specializationId = null;
            }
        }

        private void cmbProfession_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbProfession.Text))
            {
                professionId = null;
            }
        }

        private void cmbEducationalLevel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbEducationalLevel.Text))
            {
                educationLevelId = null;
            }
        }

        private void cmbHighestDegree_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbHighestDegree.Text))
            {
                highestDegreeId = null;
            }
        }

        private void cmbAgeGroup_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbAgeGroup.Text))
            {
                ageGroupId = null;
            }
        }

        private void cmbRelationShip_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRelationShip.Text))
            {
                relationshipId = null;
            }
        }

        private void ReligioncomboBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReligioncomboBox.Text))
            {
                religionId = null;
            }
        }

        private void CountrycomboBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CountrycomboBox.Text))
            {
                MessageBox.Show("Please Select Country Of Res", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), CountrycomboBox);
            }
        }

        private void UpdatePersonInfo_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            frm.Show();
        }

        private void CompanySelectionbutton_Click(object sender, EventArgs e)
        {
            ResetWorkingAddress();
            if (CountrycomboBox.Text == "Bangladesh")
            {
                groupBox3.Show();
                groupBox3.Location = new Point(466, 290);
                groupBox7.Show();
                groupBox7.Location = new Point(466, 533);
            }
            else
            {
                groupBox3.Show();
                groupBox6.Show();
                groupBox7.Show();
                groupBox6.Location = new Point(466, 12);
                groupBox3.Location = new Point(466, 155);
                groupBox7.Location = new Point(466, 410);
            }
            using (var form = new CompanySelectionGrid())
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
                        "SELECT Company.CompanyName, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM Company left JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Company.CompanyId='" +
                        companyId + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        this.txtWAFlatName.Text = rdr["CFlatNo"].ToString();
                        this.txtWAHouseName.Text = rdr["CHouseNo"].ToString();
                        this.txtWARoadNo.Text = rdr["CRoadNo"].ToString();
                        this.txtWABlock.Text = rdr["CBlock"].ToString();
                        this.txtWAArea.Text = rdr["CArea"].ToString();
                        this.LandmarktextBox.Text = rdr["CLandmark"].ToString();
                        this.txtWAContactNo.Text = rdr["CContactNo"].ToString();
                        this.WABuildingNametextBox.Text = rdr["BuildingName"].ToString();
                        this.WARoadNametextBox.Text = rdr["RoadName"].ToString();
                        this.WAdivisiontextBox.Text = rdr["Division"].ToString();
                        this.WADistricttextBox.Text = rdr["District"].ToString();
                        this.WAThanatextBox.Text = rdr["Thana"].ToString();
                        this.WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
                        this.txtWAPostCode.Text = rdr["PostCode"].ToString();
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
    }
}
