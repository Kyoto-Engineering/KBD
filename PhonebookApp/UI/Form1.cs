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
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using PhonebookApp.UI;
using QRCoder;


namespace PhonebookApp
{
    public partial class frm1 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string companyId = null;
        public string rAdistrictid, countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public Nullable<Int64> groupid, relationshipId, bankEmailId, categoryId, jobTitleId, specializationId, professionId, ageGroupId, educationLevelId, highestDegreeId, religionId, genderId, maritalStatusId;
        //public string nUserId;
        public int currentPersonId, affectedRows1, affectedRows2, affectedRows3, wAdistrictid;
        private delegate void ChangeFocusDelegate(Control ctl);
        public frm1()
        {
            InitializeComponent();
        }

        // Regex emailValidation = new Regex((@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"));

        // Regex mobileNoValidation = new Regex(@"^(?:\+88|01)?\d{11}$");

        private void ForeignAddresses(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qury = "insert into " + tableName + "(PersonsId,Street,State,PostalCode,AdressQR) Values(@d1,@d2,@d3,@d4,@d5)" +
                          "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qury);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", currentPersonId);
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d4",
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
            SqlParameter p = new SqlParameter("@d5", SqlDbType.VarBinary);
            p.Value = data;
            cmd.Parameters.Add(p);
            affectedRows3 = (int)cmd.ExecuteScalar();
            con.Close();
        }


        //private void WASameAsRA(string tblName1)
        //{
        //    string tableName = tblName1;
        //    con = new SqlConnection(cs.DBConn);
        //    con.Open();
        //    string Qry = "insert into " + tableName +
        //                 "(PersonsId,PostOfficeId,WFlatNo,WHouseNo,WRoadNo,WBlock,WArea,WContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
        //                 "SELECT CONVERT(int, SCOPE_IDENTITY())";
        //    cmd = new SqlCommand(Qry);
        //    cmd.Connection = con;
        //    cmd.Parameters.AddWithValue("@d1", currentPersonId);
        //    cmd.Parameters.Add(new SqlParameter("@d2",
        //        string.IsNullOrEmpty(postofficeIdRA) ? (object)DBNull.Value : postofficeIdRA));
        //    cmd.Parameters.Add(new SqlParameter("@d3",
        //        string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text));
        //    cmd.Parameters.Add(new SqlParameter("@d4",
        //        string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text));
        //    cmd.Parameters.Add(new SqlParameter("@d5",
        //        string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text));
        //    cmd.Parameters.Add(new SqlParameter("@d6",
        //        string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text));
        //    cmd.Parameters.Add(new SqlParameter("@d7",
        //        string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text));
        //    cmd.Parameters.Add(new SqlParameter("@d8",
        //        string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text));
        //    affectedRows2 = (int)cmd.ExecuteScalar();
        //    con.Close();
        //}

        private void SaveWorkingAddress(string tblName1)
        {
            string tableName = tblName1;

            if (tableName == "ResidentialAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName +
                                 "(PersonsId,PostOfficeId,RFlatNo,RHouseNo,RRoadNo,RBlock,RArea,RContactNo,BuildingName,RoadName,LandMark,AdressQR) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)" +
                                 "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", currentPersonId);
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
                string debugSQL = cmd.CommandText;

                foreach (SqlParameter param in cmd.Parameters)
                {
                    debugSQL = debugSQL.Replace(param.ParameterName, param.Value.ToString());
                }

                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
                ms.Dispose();
            }
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

        //private void SaveWorkingAddre(string tblName1)
        //{
        //    string tableName = tblName1;
        //    if (tableName == "CorporateAddresses")
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string insertQ = "insert into " + tableName + "(PostOfficeId,CFlatNo,CHouseNo,CRoadNo,CBlock,CArea,CContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
        //        cmd = new SqlCommand(insertQ);
        //        cmd.Connection = con;
        //        cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdRA) ? (object)DBNull.Value : postofficeIdRA));
        //        cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtRAFlatNo.Text) ? (object)DBNull.Value : txtRAFlatNo.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtRAHouseNo.Text) ? (object)DBNull.Value : txtRAHouseNo.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtRARoadNo.Text) ? (object)DBNull.Value : txtRARoadNo.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtRABlock.Text) ? (object)DBNull.Value : txtRABlock.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(txtRAArea.Text) ? (object)DBNull.Value : txtRAArea.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(txtRAContactNo.Text) ? (object)DBNull.Value : txtRAContactNo.Text));

        //        cmd.Parameters.AddWithValue("@d11", companyid);
        //        affectedRows1 = (int)cmd.ExecuteScalar();
        //        con.Close();
        //    }
        //    else if (tableName == "WorkingAddresses")
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string insertQ = "insert into " + tableName +
        //                         "(PersonsId,PostOfficeId,WFlatNo,WHouseNo,WRoadNo,WBlock,WArea,WContactNo) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
        //                         "SELECT CONVERT(int, SCOPE_IDENTITY())";
        //        cmd = new SqlCommand(insertQ);
        //        cmd.Connection = con;
        //        cmd.Parameters.AddWithValue("@d1", currentPersonId);
        //        cmd.Parameters.Add(new SqlParameter("@d2",
        //            string.IsNullOrEmpty(postofficeIdWA) ? (object)DBNull.Value : postofficeIdWA));
        //        cmd.Parameters.Add(new SqlParameter("@d3",
        //            string.IsNullOrEmpty(txtWAFlatName.Text) ? (object)DBNull.Value : txtWAFlatName.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d4",
        //            string.IsNullOrEmpty(txtWAHouseName.Text) ? (object)DBNull.Value : txtWAHouseName.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d5",
        //            string.IsNullOrEmpty(txtWARoadNo.Text) ? (object)DBNull.Value : txtWARoadNo.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d6",
        //            string.IsNullOrEmpty(txtWABlock.Text) ? (object)DBNull.Value : txtWABlock.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d7",
        //            string.IsNullOrEmpty(txtWAArea.Text) ? (object)DBNull.Value : txtWAArea.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d8",
        //            string.IsNullOrEmpty(txtWAContactNo.Text) ? (object)DBNull.Value : txtWAContactNo.Text));
        //        affectedRows1 = (int)cmd.ExecuteScalar();
        //        con.Close();
        //    }

        //    else if (tableName == "ForeignAddress")
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string Qury = "insert into " + tableName +
        //                      "(PersonsId,Street,State,PostalCode) Values(@d1,@d2,@d3,@d4)" +
        //                      "SELECT CONVERT(int, SCOPE_IDENTITY())";
        //        cmd = new SqlCommand(Qury);
        //        cmd.Connection = con;
        //        cmd.Parameters.AddWithValue("@d1", currentPersonId);
        //        cmd.Parameters.Add(new SqlParameter("@d2",
        //            string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d3",
        //            string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text));
        //        cmd.Parameters.Add(new SqlParameter("@d4",
        //            string.IsNullOrEmpty(PostalCodetextBox.Text) ? (object)DBNull.Value : PostalCodetextBox.Text));
        //        affectedRows3 = (int)cmd.ExecuteScalar();
        //        con.Close();
        //    }

        //}

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

        private void Reset1()
        {
            //FillRelationShip();
            //FillJobTitle();
            //FillAgeGroup();
            //FillCompanyName();
            //FillEducationLevel();
            //FillHighestDegree();
            //FillProfession();
            //FillSpecialization();
            //EmailAddress();
            //CountrycomboBox.SelectedIndex = -1;
            relationshipId = bankEmailId = groupid = jobTitleId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();

            //cmbEmailAddress.ResetText();
            //EmailAddress();
            cmbEmailAddress.SelectedIndex = -1;
            companyNametextBox.Clear();
            //cmbCompanyName.Items.Clear();
            //cmbCompanyName.ResetText();
            //FillCompanyName();
            //cmbCompanyName.SelectedIndex = -1;
            GroupNamecomboBox.Items.Clear();
            //cmbCategoryName.ResetText();
            //FillCategory();
            GroupNamecomboBox.SelectedIndex = -1;
            cmbAgeGroup.Items.Clear();
            //cmbAgeGroup.ResetText();
            //FillAgeGroup();
            cmbAgeGroup.SelectedIndex = -1;
            cmbProfession.Items.Clear();
            //cmbProfession.ResetText();
            //FillProfession();
            cmbProfession.SelectedIndex = -1;
            cmbEducationalLevel.Items.Clear();
            //cmbEducationalLevel.ResetText();
            //FillEducationLevel();
            cmbEducationalLevel.SelectedIndex = -1;
            cmbHighestDegree.Items.Clear();
            //cmbHighestDegree.ResetText();
            //FillHighestDegree();
            cmbHighestDegree.SelectedIndex = -1;
            cmbJobTitle.Items.Clear();
            //cmbJobTitle.ResetText();
            //FillJobTitle();
            cmbJobTitle.SelectedIndex = -1;
            cmbSpecialization.Items.Clear();
            //cmbSpecialization.ResetText();
            //FillSpecialization();
            cmbSpecialization.SelectedIndex = -1;
            cmbRelationShip.Items.Clear();
            //cmbRelationShip.ResetText();
            //FillRelationShip();
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
            //EmailAddress();
            //FillCompanyName();
            //FillJobTitle();
            //FillCategory();
            //FillSpecialization();
            //FillProfession();
            //FillEducationLevel();
            //FillHighestDegree();
            //FillAgeGroup();            
            //FillRelationShip();
            //CountrycomboBox.SelectedIndex = -1;
            relationshipId = bankEmailId = groupid = jobTitleId = specializationId = professionId = ageGroupId = educationLevelId = highestDegreeId = religionId = genderId = maritalStatusId
                = null;
            txtPersonName.Clear();
            textNickName.Clear();
            txtFatherName.Clear();
            cmbEmailAddress.Items.Clear();
            //cmbEmailAddress.ResetText();
            //EmailAddress();
            cmbEmailAddress.SelectedIndex = -1;
            companyNametextBox.Clear();
            //cmbCompanyName.Items.Clear();
            //cmbCompanyName.ResetText();
            //FillCompanyName();
            //cmbCompanyName.SelectedIndex = -1;
            GroupNamecomboBox.Items.Clear();
            //cmbCategoryName.ResetText();
            //FillCategory();
            GroupNamecomboBox.SelectedIndex = -1;
            cmbAgeGroup.Items.Clear();
            //cmbAgeGroup.ResetText();
            //FillAgeGroup();
            cmbAgeGroup.SelectedIndex = -1;
            cmbProfession.Items.Clear();
            //cmbProfession.ResetText();
            //FillProfession();
            cmbProfession.SelectedIndex = -1;
            cmbEducationalLevel.Items.Clear();
            //cmbEducationalLevel.ResetText();
            //FillEducationLevel();
            cmbEducationalLevel.SelectedIndex = -1;
            cmbHighestDegree.Items.Clear();
            //cmbHighestDegree.ResetText();
            //FillHighestDegree();
            cmbHighestDegree.SelectedIndex = -1;
            cmbJobTitle.Items.Clear();
            //cmbJobTitle.ResetText();
            //FillJobTitle();
            cmbJobTitle.SelectedIndex = -1;
            cmbSpecialization.Items.Clear();
            //cmbSpecialization.ResetText();
            //FillSpecialization();
            cmbSpecialization.SelectedIndex = -1;
            cmbRelationShip.Items.Clear();
            //cmbRelationShip.ResetText();
            //FillRelationShip();
            cmbRelationShip.SelectedIndex = -1;
            txtWebsite.Clear();
            txtSkypeId.Clear();
            txtWhatsApp.Clear();
            txtImmo.Clear();
            userPictureBox.Image = null;
            ResetForeignAddress();
            ResetAdditionalInformation();
        }

        private void SavePersonDetails()
        {
            SqlParameter p;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            String query =
                "insert into Persons(PersonName,NickName,FatherName,EmailBankId,CompanyId,JobTitleId,SpecializationsId,ProfessionId,EducationLevelId,HighestDegreeId,AgeGroupId,RelationShipsId,Website,SkypeId,WhatsAppId,ImoNumber,CountryId,ReligionId,GenderId,MaritalStatusId,DateOfBirth,MarriageAnniversaryDate,UserId,Picture) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24)" +
                "SELECT CONVERT(int, SCOPE_IDENTITY())";
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
            cmd.Parameters.AddWithValue("@d7", (object)specializationId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d8", (object)professionId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d9", (object)educationLevelId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d10", (object)highestDegreeId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d11", (object)ageGroupId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d12", (object)relationshipId ?? DBNull.Value);
            cmd.Parameters.Add(new SqlParameter("@d13",
                string.IsNullOrEmpty(txtWebsite.Text) ? (object)DBNull.Value : txtWebsite.Text));
            cmd.Parameters.Add(new SqlParameter("@d14",
                string.IsNullOrEmpty(txtSkypeId.Text) ? (object)DBNull.Value : txtSkypeId.Text));
            cmd.Parameters.Add(new SqlParameter("@d15",
                string.IsNullOrEmpty(txtWhatsApp.Text) ? (object)DBNull.Value : txtWhatsApp.Text));
            cmd.Parameters.Add(new SqlParameter("@d16",
                string.IsNullOrEmpty(txtImmo.Text) ? (object)DBNull.Value : txtImmo.Text));

            cmd.Parameters.AddWithValue("@d17", (object)countryid ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d18", (object)religionId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d19", (object)genderId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d20", (object)maritalStatusId ?? DBNull.Value);
            cmd.Parameters.Add(new SqlParameter("@d21",
                !BirthdateTimePicker.Checked ? (object)DBNull.Value : BirthdateTimePicker.Value));
            cmd.Parameters.Add(new SqlParameter("@d22",
                !AnniversarydateTimePicker.Checked ? (object)DBNull.Value : AnniversarydateTimePicker.Value));
            cmd.Parameters.AddWithValue("@d23", nUserId);
            if (userPictureBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(userPictureBox.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                p = new SqlParameter("@d24", SqlDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
            }
            else
            {
                cmd.Parameters.Add("@d24", SqlDbType.VarBinary, -1);
                cmd.Parameters["@d24"].Value = DBNull.Value;
            }
            currentPersonId = (int)(cmd.ExecuteScalar());
            con.Close();

        }

        private void SaveInfo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into GroupMember(GroupId,PersonsId,UserId) values(@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", (object)groupid ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@d2", currentPersonId);
                cmd.Parameters.AddWithValue("@d3", nUserId);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    "select Persons.PersonName, EmailBank.Email, Company.CompanyName, Persons.WhatsAppId, isnull(nullif(ResidentialAddresses.RFlatNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RHouseNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RRoadNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RBlock,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RArea,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RContactNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.LandMark,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Persons Left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Company ON Persons.CompanyId = Company.CompanyId left JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId left JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId left JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID left JOIN Districts ON Thanas.D_ID = Districts.D_ID where Persons.PersonName='" +
                    txtPersonName.Text + "'";

            }
            else
            {
                ct3 =
                    "select Persons.PersonName, EmailBank.Email, Company.CompanyName, Persons.WhatsAppId, isnull(nullif(ForeignAddress.Street,\'\') + \', \',\'\') + isnull(nullif(ForeignAddress.State,\'\') + \', \',\'\') + isnull(nullif(ForeignAddress.PostalCode,\'\') + \', \',\'\') as Addresss FROM Persons Left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Company ON Persons.CompanyId = Company.CompanyId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId where Persons.PersonName='" + txtPersonName.Text + "'";

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
                    value = true;
                    break;
                }

                if (p.Person == txtPersonName.Text && p.Email == cmbEmailAddress.Text)
                {
                    MessageBox.Show(@"This Person name and Email Address already Exist,Please Input another one" + "\n",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPersonName.Clear();
                    cmbEmailAddress.SelectedIndex = -1;
                    bankEmailId = null;
                    txtPersonName.Focus();
                    con.Close();
                    value = false;
                    break;
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
                    value = true;
                    break;
                }
                if (p.Person == txtPersonName.Text && p.Phone == txtWhatsApp.Text)
                {
                    MessageBox.Show(@"This Person name and Phone Number already Exist,Please Input another one" + "\n",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPersonName.Clear();
                    txtWhatsApp.Clear();
                    txtPersonName.Focus();
                    con.Close();
                    value = false;
                    break;
                }

            }
            return value;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonName.Text) && string.IsNullOrEmpty(cmbEmailAddress.Text) && string.IsNullOrEmpty(companyNametextBox.Text) && string.IsNullOrEmpty(txtWhatsApp.Text) && (unKnownRA.Checked))
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
                        try
                        {
                            SavePersonDetails();
                            SaveWorkingAddress("ResidentialAddresses");
                            if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                            {
                                SaveInfo();
                            }

                            MessageBox.Show("Saved successfully", "Record", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Reset1();
                            CountrycomboBox.SelectedItem = "Bangladesh";
                            CountrycomboBox.Enabled = true;
                            EmailAddress();
                            cmbEmailAddress.ResetText();
                            //FillCompanyName();
                            //cmbCompanyName.ResetText();
                            companyNametextBox.Clear();
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
                            additionalInfobutton.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        try
                        {
                            SavePersonDetails();
                            if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                            {
                                SaveInfo();
                            }
                            MessageBox.Show("Saved successfully", "Record", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Reset1();
                            CountrycomboBox.SelectedItem = "Bangladesh";
                            CountrycomboBox.Enabled = true;
                            EmailAddress();
                            cmbEmailAddress.ResetText();
                            //FillCompanyName();
                            //cmbCompanyName.ResetText();
                            companyNametextBox.Clear();
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
                            additionalInfobutton.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                else
                {
                    try
                    {
                        SavePersonDetails();
                        ForeignAddresses("ForeignAddress");
                        if (!string.IsNullOrWhiteSpace(GroupNamecomboBox.Text))
                        {
                            SaveInfo();
                        }
                        MessageBox.Show("Saved successfully", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset2();
                        CountrycomboBox.SelectedItem = "Bangladesh";
                        CountrycomboBox.Enabled = true;
                        ResetWorkingAddress();
                        EmailAddress();
                        //FillCompanyName();
                        //cmbCompanyName.ResetText();
                        companyNametextBox.Clear();
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
                        groupBox3.Location = new Point(466, 285);
                        btnInsert.Hide();
                        additionalInfobutton.Show();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

                }
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
                    GroupNamecomboBox.Items.Add(rdr[0]);
                }
                GroupNamecomboBox.Items.Add("Not In The List");
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
            //    con.Close();
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


        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }

        private void frm1_Load(object sender, EventArgs e)
        {
            FillCountry();
            CountrycomboBox.SelectedItem = "Bangladesh";
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
            cmbRADistrict.Enabled = false;
            cmbRAThana.Enabled = false;
            cmbRAPost.Enabled = false;
            groupBox6.Hide();
            groupBox7.Hide();
            btnInsert.Hide();

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

        private void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmNewEntry frm = new frmNewEntry();
            frm.Show();
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


                    //else
                    //{

                    //    //if (!string.IsNullOrWhiteSpace(input))
                    //    //{
                    //    //    string emailId = input.Trim();
                    //    //    Regex mRegxExpression;

                    //    //    mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                    //    //    if (!mRegxExpression.IsMatch(emailId))
                    //    //    {

                    //    //        MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    //        return;

                    //    //    }
                    //    //}


                    //    }
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

        private void FillWorkingAddress()
        {
            try
            {
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

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSpecialization.Text == "Not In The List")
            {
                // string inputs = Microsoft.VisualBasic.Interaction.InputBox("Please Input Specialization  Here", "Input Here", "", -1, -1);
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

        //private void unKnownCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (unKnownCheckBox.Checked)
        //    {

        //        if (sameAsRACheckBox.Checked)
        //        {
        //            sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
        //            sameAsRACheckBox.Checked = false;
        //            sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;
        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }
        //        else
        //        {

        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }

        //    }
        //    else
        //    {
        //        if (sameAsRACheckBox.Checked)
        //        {
        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }
        //        else
        //        {

        //            groupBox4.Enabled = true;
        //            ResetWorkingAddress();
        //            FilStar();
        //        }
        //    }
        //}

        //private void sameAsRACheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (sameAsRACheckBox.Checked)
        //    {

        //        if (unKnownCheckBox.Checked)
        //        {
        //            unKnownCheckBox.CheckedChanged -= unKnownCheckBox_CheckedChanged;
        //            unKnownCheckBox.Checked = false;
        //            unKnownCheckBox.CheckedChanged += unKnownCheckBox_CheckedChanged;
        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }
        //        else
        //        {

        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }

        //    }
        //    else
        //    {
        //        if (unKnownCheckBox.Checked)
        //        {
        //            groupBox4.Enabled = false;
        //            ResetWorkingAddress();
        //            ResetStar();
        //        }
        //        else
        //        {

        //            groupBox4.Enabled = true;
        //            ResetWorkingAddress();
        //            FilStar();
        //        }
        //    }
        //}

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
            //if (unKnownRA.Checked == true)
            //{
            //    Reset2Star();
            //    groupBox5.Enabled = false;
            //    ResetResidentialAddress();
            //    sameAsRACheckBox.Visible = false;

            //}
            //else
            //{
            //    sameAsRACheckBox.Visible = true;
            //    groupBox5.Enabled = true;
            //    groupBox5.Enabled = true;
            //    FillStar2();
            //}
        }

        private void cmbRADivision_SelectedIndexChanged_1(object sender, EventArgs e)
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



        private void cmbRADistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
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
                    //divisionIdRA = (rdr.GetString(1));
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

        private void cmbRAThana_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find AND Thanas.D_ID='" + districtIdRA + "'";
                string ctk = "SELECT RTRIM(Thanas.T_ID) FROM Thanas INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Thanas.Thana=@find1 and Districts.District=@find2 and Divisions.Division=@find3";
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
                    //districtIdRA = (rdr.GetString(1));
                    //divisionIdRA = (rdr.GetString(2));
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

        private void cmbRAPost_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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
                    //thanaIdRA = (rdr.GetString(2));
                    //districtIdRA = (rdr.GetString(3));
                    //divisionIdRA = (rdr.GetString(4));
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

       
        private void CountrycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CountrycomboBox.Text == "Bangladesh")
            {
                enableAll();
                groupBox6.Hide();
                groupBox2.Show();
                groupBox3.Show();
                groupBox3.Location = new Point(466, 285);
                btnInsert.Hide();
                additionalInfobutton.Show();
                additionalInfobutton.Location = new Point(891, 548);
            }
            else
            {
                enableAll();
                groupBox2.Hide();
                groupBox3.Show();
                groupBox3.Location = new Point(466, 150);
                groupBox6.Show();
                groupBox6.Location = new Point(466, 12);
                btnInsert.Hide();
                additionalInfobutton.Show();
                additionalInfobutton.Location = new Point(650, 420);
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

        private void enableAll()
        {
            txtPersonName.Enabled = true;
            textNickName.Enabled = true;
            txtFatherName.Enabled = true;
            cmbEmailAddress.Enabled = true;
            //cmbCompanyName.Enabled = true;
            GroupNamecomboBox.Enabled = true;
            cmbAgeGroup.Enabled = true;
            cmbProfession.Enabled = true;
            cmbEducationalLevel.Enabled = true;
            cmbHighestDegree.Enabled = true;
            cmbJobTitle.Enabled = true;
            cmbSpecialization.Enabled = true;
            cmbRelationShip.Enabled = true;
            txtWebsite.Enabled = true;
            txtSkypeId.Enabled = true;
            txtImmo.Enabled = true;
        }

        private void txtRAContactNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //string Cell_Phone = txtRAContactNo.Text;

            //if (char.IsNumber(e.KeyChar))
            //{ }
            //else
            //{
            //    e.Handled = e.KeyChar != (char)Keys.Back;
            //}

            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

        }

        private void txtWAContactNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtWhatsApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtImmo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void CountrycomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPersonName.Focus();
                e.Handled = true;
            }
        }

        private void txtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNickName.Focus();
                e.Handled = true;
            }
        }

        private void textNickName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherName.Focus();
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmailAddress.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //cmbCompanyName.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    cmbJobTitle.Focus();
            //    e.Handled = true;
            //}
        }

        private void cmbJobTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GroupNamecomboBox.Focus();
                e.Handled = true;
            }
        }

        private void cmbCategoryName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSpecialization.Focus();
                e.Handled = true;
            }
        }

        private void cmbSpecialization_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProfession.Focus();
                e.Handled = true;
            }
        }

        private void cmbProfession_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEducationalLevel.Focus();
                e.Handled = true;
            }
        }

        private void cmbEducationalLevel_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHighestDegree.Focus();
                e.Handled = true;
            }
        }

        private void cmbHighestDegree_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgeGroup.Focus();
                e.Handled = true;
            }
        }

        private void cmbAgeGroup_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRelationShip.Focus();
                e.Handled = true;
            }
        }

        private void cmbRelationShip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWebsite.Focus();
                e.Handled = true;
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSkypeId.Focus();
                e.Handled = true;
            }
        }

        private void txtSkypeId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWhatsApp.Focus();
                e.Handled = true;
            }
        }

        private void txtWhatsApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImmo.Focus();
                e.Handled = true;
            }
        }

        private void txtImmo_KeyDown(object sender, KeyEventArgs e)
        {
            if (CountrycomboBox.Text == "Bangladesh")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRAFlatNo.Focus();
                    e.Handled = true;
                }
            }
            //else
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        StreettextBox.Focus();
            //        e.Handled = true;
            //    }
            //}

        }


        private void txtRAFlatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAHouseNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRARoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRARoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRABlock.Focus();
                e.Handled = true;
            }
        }

        private void txtRABlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAArea.Focus();
                e.Handled = true;
            }
        }

        private void txtRAArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtRAPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAFlatName.Focus();
                e.Handled = true;
            }
        }

        private void StreettextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StatetextBox.Focus();
                e.Handled = true;
            }
        }

        private void StatetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PostalCodetextBox.Focus();
                e.Handled = true;
            }
        }

        private void PostalCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInsert_Click_1(this, new EventArgs());

            }
        }

        private void cmbEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {


                string emailId = cmbEmailAddress.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbEmailAddress.SelectedIndex = -1;
                    cmbEmailAddress.ResetText();
                    cmbEmailAddress.Focus();

                }
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

        private void additionalInfobutton_Click(object sender, EventArgs e)
        {
            additionalInfobutton.Hide();
            CountrycomboBox.Enabled = false;

            if (CountrycomboBox.Text == "Bangladesh")
            {
                enableAll();
                groupBox6.Hide();
                groupBox2.Show();
                groupBox3.Show();
                groupBox7.Show();
                groupBox7.Location = new Point(466, 532);
                btnInsert.Show();
                btnInsert.Location = new Point(1045, 549);

            }
            else
            {
                enableAll();
                groupBox2.Hide();
                groupBox3.Show();
                groupBox3.Location = new Point(466, 157);
                groupBox6.Show();
                groupBox6.Location = new Point(466, 18);
                groupBox7.Show();
                groupBox7.Location = new Point(466, 410);
                btnInsert.Show();
                btnInsert.Location = new Point(890, 545);
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

        private void unKnownRA_CheckedChanged_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        private void cmbCompanyName_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cmbCompanyName.Text))
            //{
            //    ResetWorkingAddress();
            //    companyId = null;
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

        private void CompanySelectionbutton_Click(object sender, EventArgs e)
        {
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
                        "SELECT Company.CompanyName, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Company.CompanyId='" +
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }      
    }
}


