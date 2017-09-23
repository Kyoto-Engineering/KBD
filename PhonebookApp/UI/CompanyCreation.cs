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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using PhonebookApp.Reports;
using QRCoder;

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
            SqlParameter p;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "insert into Company(CompanyName,Email,ContactNo,IdentificationNo,WebSiteUrl, UserId, DateAndTime,CompanyTypeId,IndustryCategoryId,NatureOfCompanyId,CPicture) values(@d1,@nemail,@nphone,@nidenti,@nweburl,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d1", CompanyNameTextBox.Text);
            cmd.Parameters.Add(new SqlParameter("@nemail",
                string.IsNullOrEmpty(EmailtextBox.Text) ? (object)DBNull.Value : EmailtextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@nphone",
                string.IsNullOrEmpty(ContactNotextBox.Text) ? (object)DBNull.Value : ContactNotextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@nidenti",
                string.IsNullOrEmpty(IdentificationNotextBox.Text) ? (object)DBNull.Value : IdentificationNotextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@nweburl",
                string.IsNullOrEmpty(WebSiteUrltextBox.Text) ? (object)DBNull.Value : WebSiteUrltextBox.Text));
            cmd.Parameters.AddWithValue("@d2", user_id);
            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d4", companytypeid);
            cmd.Parameters.AddWithValue("@d5", industryCategoryId);
            cmd.Parameters.AddWithValue("@d6", natureOfClientId);
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                p = new SqlParameter("@d7", SqlDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
            }
            else
            {
                cmd.Parameters.Add("@d7", SqlDbType.VarBinary, -1);
                cmd.Parameters["@d7"].Value = DBNull.Value;
            }

            companyid = (int)cmd.ExecuteScalar();
            con.Close();
        }

        private void SaveTraddingAddress()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into TraddingAddresses (PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TLandmark,TContactNo,CompanyId,BuildingName,RoadName) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
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
            cmd.Parameters.AddWithValue("@d12", companyid);
            cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(tBuldingNameTextBox.Text) ? (object)DBNull.Value : tBuldingNameTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d14", string.IsNullOrEmpty(tRoadNameTextBox.Text) ? (object)DBNull.Value : tRoadNameTextBox.Text));

            //var Qrdata = GetQrdata(tDivisionCombo.Text, tDistrictCombo.Text, tThenaCombo.Text, tPostCombo.Text, tPostCodeTextBox.Text, tAreaTextBox.Text, FblocktextBox.Text, tLandmarktextBox.Text, tRoadNameTextBox.Text, tRoadNoTextBox.Text, tBuldingNameTextBox.Text, tHouseNoTextBox.Text, tFlatNoTextBox.Text, tContactNoTextBox.Text);
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
            ////qrCode.GetGraphic()
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //byte[] data = ms.GetBuffer();
            //SqlParameter p = new SqlParameter("@d15", SqlDbType.VarBinary);
            //p.Value = data;
            //cmd.Parameters.Add(p);
            //string debugSQL = cmd.CommandText;

            //foreach (SqlParameter param in cmd.Parameters)
            //{
            //    debugSQL = debugSQL.Replace(param.ParameterName, param.Value.ToString());
            //}

            affectedRows2 = (int)cmd.ExecuteScalar();
            con.Close();
            //ms.Dispose();
        }
        private void SaveCorporateORTraddingAddress(string tblName1)
        {
            string insertQ;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            if (tblName1 == "CorporateAddresses")
            {

                insertQ =
                    "insert into CorporateAddresses (PostOfficeId,CFlatNo,CHouseNo,CRoadNo,CBlock,CArea,CLandmark,CContactNo,CompanyId,BuildingName,RoadName,Branch) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
            }
            else
            {
                insertQ =
                    "insert into TraddingAddresses (PostOfficeId,TFlatNo,THouseNo,TRoadNo,TBlock,TArea,TLandmark,TContactNo,CompanyId,BuildingName,RoadName) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
            }
            cmd = new SqlCommand(insertQ);
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeIdC) ? (object)DBNull.Value : postofficeIdC));
            cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(cFlatNoTextBox.Text) ? (object)DBNull.Value : cFlatNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(cHouseNoTextBox.Text) ? (object)DBNull.Value : cHouseNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(cRoadNoTextBox.Text) ? (object)DBNull.Value : cRoadNoTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blocktextBox.Text) ? (object)DBNull.Value : blocktextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(cAreaTextBox.Text) ? (object)DBNull.Value : cAreaTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(cLandmarktextBox.Text) ? (object)DBNull.Value : cLandmarktextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(cContactNoTextBox.Text) ? (object)DBNull.Value : cContactNoTextBox.Text));
            cmd.Parameters.AddWithValue("@d12", companyid);
            cmd.Parameters.Add(new SqlParameter("@d13", string.IsNullOrEmpty(cBuldingNameTextBox.Text) ? (object)DBNull.Value : cBuldingNameTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d14", string.IsNullOrEmpty(cRoadNameTextBox.Text) ? (object)DBNull.Value : cRoadNameTextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d15",
                string.IsNullOrEmpty(textBox1.Text) ? (object) DBNull.Value : textBox1.Text));
            //var Qrdata = GetQrdata(cDivisionCombo.Text, cDistCombo.Text, cThanaCombo.Text, cPostOfficeCombo.Text, cPostCodeTextBox.Text, cAreaTextBox.Text, blocktextBox.Text, cLandmarktextBox.Text, cRoadNameTextBox.Text, cRoadNoTextBox.Text, cBuldingNameTextBox.Text, cHouseNoTextBox.Text, cFlatNoTextBox.Text, cContactNoTextBox.Text);
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qrdata, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, true);
            ////qrCode.GetGraphic()
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //byte[] data = ms.GetBuffer();
            //SqlParameter p = new SqlParameter("@d15", SqlDbType.VarBinary);
            //p.Value = data;
            //cmd.Parameters.Add(p);
            //string debugSQL = cmd.CommandText;

            //foreach (SqlParameter param in cmd.Parameters)
            //{
            //    debugSQL = debugSQL.Replace(param.ParameterName, param.Value.ToString());
            //}

            int aff = (int)cmd.ExecuteScalar();
            if (tblName1 == "CorporateAddresses")
            {
                affectedRows1 = aff;
            }
            else
            {
                affectedRows2 = aff;
            }

            con.Close();
        }




        //private string GetQrdata(string Division, string District, string Thana, string Post, string PostCode, string Area, string Block, string LandMark, string roadName, string RoadNo, string buildingName, string HouseNo, string FlatNo, string ContactNo)
        //{
        //    string Qrdata = "Country:Bangladesh\r\n";
        //    Qrdata += "Division:" + Division + "\r\n";
        //    Qrdata += "District:" + District + "\r\n";
        //    Qrdata += "Thana:" + Thana + "\r\n";
        //    Qrdata += "Post:" + Post + "\r\n";
        //    Qrdata += "Post Code:" + PostCode + "\r\n";
        //    Qrdata += "Area / Village :" + (string.IsNullOrEmpty(Area) ? "" : Area) +
        //    "\r\n";
        //    Qrdata += "Block/Sector/Zone:" + (string.IsNullOrEmpty(Block) ? "" : Block) +
        //    "\r\n";
        //    Qrdata += "Nearest Landmark:" + (string.IsNullOrEmpty(LandMark)
        //        ? ""
        //    : LandMark) + "\r\n";
        //    Qrdata += "Road Name:" +
        //    (string.IsNullOrEmpty(roadName) ? "" : roadName) + "\r\n";
        //    Qrdata += "Road#:" + (string.IsNullOrEmpty(RoadNo) ? "" : RoadNo) + "\r\n";
        //    Qrdata += "Building Name:" + (string.IsNullOrEmpty(buildingName)
        //        ? ""
        //    : buildingName) + "\r\n";
        //    Qrdata += "Holding#:" + (string.IsNullOrEmpty(HouseNo) ? "" : HouseNo) +
        //    "\r\n";
        //    Qrdata += "Flat or Level#:" + (string.IsNullOrEmpty(FlatNo) ? "" : FlatNo) +
        //    "\r\n";
        //    Qrdata += "Contact#:" + (string.IsNullOrEmpty(ContactNo) ? "" : ContactNo);
        //    return Qrdata;
        //}


        private bool ValidateControlls()
        {
            bool validate = true;

            if (string.IsNullOrEmpty(CompanyNameTextBox.Text))
            {
                MessageBox.Show(@"Please Enter Company Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                CompanyNameTextBox.Focus();
            }

            else if (string.IsNullOrEmpty(cmbCompanytype.Text))
            {
                MessageBox.Show(@"Please Select Company Type", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                cmbCompanytype.Focus();
            }

            else if (string.IsNullOrEmpty(IndustryCategorycomboBox.Text))
            {
                MessageBox.Show(@"Please Select Industry Category", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                IndustryCategorycomboBox.Focus();
            }

            else if (string.IsNullOrEmpty(cmbNatureOfClient.Text))
            {
                MessageBox.Show(@"Please Select Nature Of Business", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                cmbNatureOfClient.Focus();
            }

            else if (string.IsNullOrEmpty(cDivisionCombo.Text))
            {
                MessageBox.Show(@"Please select division", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                cDivisionCombo.Focus();
            }
            else if (string.IsNullOrWhiteSpace(cDistCombo.Text))
            {
                MessageBox.Show(@"Please Select district", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                cDistCombo.Focus();
            }
            else if (string.IsNullOrWhiteSpace(cThanaCombo.Text))
            {
                MessageBox.Show(@"Please select Thana", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                cThanaCombo.Focus();
            }

            else if (string.IsNullOrWhiteSpace(cPostOfficeCombo.Text))
            {
                MessageBox.Show(@"Please Select Post Office", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                cPostOfficeCombo.Focus();
            }

            else if ((notApplicableCheckBox.Checked == false) && (sameAsCorporatAddCheckBox.Checked == false))
            {
                if (string.IsNullOrWhiteSpace(tDivisionCombo.Text))
                {
                    MessageBox.Show(@"Please select factory division", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    tDivisionCombo.Focus();
                }
                else if (string.IsNullOrWhiteSpace(tDistrictCombo.Text))
                {
                    MessageBox.Show(@"Please Select factory district", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    tDistrictCombo.Focus();
                }
                else if (string.IsNullOrWhiteSpace(tThenaCombo.Text))
                {
                    MessageBox.Show(@"Please select factory Thana", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validate = false;
                    tThenaCombo.Focus();
                }
                else if (string.IsNullOrWhiteSpace(tPostCombo.Text))
                {
                    MessageBox.Show(@"Please Select factory Post Name", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    tPostCombo.Focus();
                }
                else if (checkBox1.Checked && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show(@"Please Write Branch Name", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    textBox1.Focus();
                }
            }
            else if (!ValidateCompany())
            {
                validate = false;
            }

            return validate;
        }

        private bool ValidateCompany()
        {
            List<CompanyAddress> companies = new List<CompanyAddress>();
            bool value = true;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct3 =
                "select Company.CompanyName,isnull(nullif(CorporateAddresses.Branch,\'\') + \', \',\'\')+isnull(nullif(CorporateAddresses.CFlatNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CHouseNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CRoadNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CBlock,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CArea,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CLandmark,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CContactNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID where Company.CompanyName='" + CompanyNameTextBox.Text + "'";
            cmd = new SqlCommand(ct3, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    CompanyAddress x = new CompanyAddress();
                    x.Company = rdr.GetString(0);
                    x.Address = rdr.GetString(1);

                    companies.Add(x);
                }
            }
            string address = string.IsNullOrWhiteSpace(textBox1.Text) ? "" : (textBox1.Text + ", ");
            address += string.IsNullOrWhiteSpace(cFlatNoTextBox.Text) ? "" : (cFlatNoTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cHouseNoTextBox.Text) ? "" : (cHouseNoTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cRoadNoTextBox.Text) ? "" : (cRoadNoTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(blocktextBox.Text) ? "" : (blocktextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cAreaTextBox.Text) ? "" : (cAreaTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cLandmarktextBox.Text) ? "" : (cLandmarktextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cContactNoTextBox.Text) ? "" : (cContactNoTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cBuldingNameTextBox.Text) ? "" : (cBuldingNameTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cRoadNameTextBox.Text) ? "" : (cRoadNameTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cPostOfficeCombo.Text) ? "" : (cPostOfficeCombo.Text + ", ");
            address += string.IsNullOrWhiteSpace(cPostCodeTextBox.Text) ? "" : (cPostCodeTextBox.Text + ", ");
            address += string.IsNullOrWhiteSpace(cThanaCombo.Text) ? "" : (cThanaCombo.Text + ", ");
            address += string.IsNullOrWhiteSpace(cDistCombo.Text) ? "" : (cDistCombo.Text);
            foreach (CompanyAddress p in companies)
            {
                if (p.Company == CompanyNameTextBox.Text && p.Address == address)
                {
                    MessageBox.Show(@"This Company Exists,Please Input another one" + "\n",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CompanyNameTextBox.Clear();

                    con.Close();
                    value = false;
                    break;
                }


            }
            return value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateControlls())
            {
                try
                {
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
                        SaveCorporateORTraddingAddress("TraddingAddresses");


                    }
                    //3.Corporate Address Applicable  & Tradding Address  Applicable
                    if (sameAsCorporatAddCheckBox.Checked == false && notApplicableCheckBox.Checked == false)
                    {
                        SaveCompany();
                        SaveCorporateORTraddingAddress("CorporateAddresses");
                        SaveTraddingAddress();
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

        private void Reset()
        {
            checkBox1.Checked = false;
            cmbCompanytype.SelectedIndex = -1;
            cmbNatureOfClient.SelectedIndex = -1;
            IndustryCategorycomboBox.SelectedIndex = -1;
            CompanyNameTextBox.Clear();
            EmailtextBox.Clear();
            ContactNotextBox.Clear();
            IdentificationNotextBox.Clear();
            WebSiteUrltextBox.Clear();
            pictureBox1.Image = null;
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
                string ctk = "SELECT RTRIM(Districts.D_ID) FROM Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Districts.District=@find1 and Divisions.Division=@find2";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find1"].Value = cDistCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find2"].Value = cDivisionCombo.Text;

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
                string ctk = "SELECT RTRIM(Districts.D_ID) FROM Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Districts.District=@find1 and Divisions.Division=@find2";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find1"].Value = tDistrictCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find2"].Value = tDivisionCombo.Text;
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

                tDistrictCombo.Text = tDistrictCombo.Text.Trim();
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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdT + "' order by Thanas.Thana asc";
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdC + "'  order by Districts.District asc";
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
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT RTRIM(Thanas.T_ID) FROM Thanas INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Thanas.Thana=@find1 and Districts.District=@find2 and Divisions.Division=@find3 AND Thanas.D_ID='" + districtIdC + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find1"].Value = cThanaCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find2"].Value = cDistCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find3"].Value = cDivisionCombo.Text;
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdC + "' order by PostOffice.PostOfficeName asc";
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
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) FROM PostOffice INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where PostOffice.PostOfficeName=@find1 and  Thanas.Thana=@find2 and Districts.District=@find3 and Divisions.Division=@find4";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find1"].Value = cPostOfficeCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find2"].Value = cThanaCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find3"].Value = cDistCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find4", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find4"].Value = cDivisionCombo.Text;
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdT + "' order by Districts.District asc";
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
                string ctk = "SELECT RTRIM(Thanas.T_ID) FROM Thanas INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Thanas.Thana=@find1 and Districts.District=@find2 and Divisions.Division=@find3 AND Thanas.D_ID='" + districtIdT + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find1"].Value = tThenaCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find2"].Value = tDistrictCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find3"].Value = tDivisionCombo.Text;
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdT + "' order by PostOffice.PostOfficeName asc";
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
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) FROM PostOffice INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where PostOffice.PostOfficeName=@find1 and  Thanas.Thana=@find2 and Districts.District=@find3 and Divisions.Division=@find4";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find1", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find1"].Value = tPostCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find2", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find2"].Value = tThenaCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find3", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find3"].Value = tDistrictCombo.Text;
                cmd.Parameters.Add(new SqlParameter("@find4", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find4"].Value = tDivisionCombo.Text;
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
            frmNewEntry frm = new frmNewEntry();
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

                    MessageBox.Show("Please Type Minimum 3 Characters.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                EmailtextBox.Focus();
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
            if (!string.IsNullOrWhiteSpace(CompanyNameTextBox.Text))
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select Company.CompanyName,isnull(nullif(CorporateAddresses.Branch,\'\') + \', \',\'\')+isnull(nullif(CorporateAddresses.CFlatNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CHouseNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CRoadNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CBlock,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CArea,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CLandmark,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CContactNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID where Company.CompanyName like '" + CompanyNameTextBox.Text + "%' order by Company.CompanyId asc";
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1]);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            //sda.Dispose();

        }

        private void EmailtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {


                string emailId = EmailtextBox.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    EmailtextBox.Clear();
                }
            }
        }

        private void ContactNotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void WebSiteUrltextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(WebSiteUrltextBox.Text))
            {
                string urlAddress = WebSiteUrltextBox.Text.Trim();
                Regex mRegxExpression;
                Regex mRegxExpression1;

                mRegxExpression = new Regex(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");
                mRegxExpression1 = new Regex(@"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");

                if ((!mRegxExpression.IsMatch(urlAddress)) && (!mRegxExpression1.IsMatch(urlAddress)))
                {

                    MessageBox.Show("Please type your valid Url Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    WebSiteUrltextBox.Clear();
                    WebSiteUrltextBox.Focus();

                }
            }
        }

        private void EmailtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ContactNotextBox.Focus();
                e.Handled = true;
            }
        }

        private void ContactNotextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IdentificationNotextBox.Focus();
                e.Handled = true;
            }
        }

        private void IdentificationNotextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WebSiteUrltextBox.Focus();
                e.Handled = true;
            }
        }

        private void WebSiteUrltextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cFlatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label49.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label49.Visible = false;
                textBox1.Visible = false;
                textBox1.Clear();
            }
        }
    }
}