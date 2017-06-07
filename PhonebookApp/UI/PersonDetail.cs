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

namespace PhonebookApp.UI
{
    public partial class PersonDetail : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        //public string companyId;
      
        public PersonDetail()
        {
            InitializeComponent();
        }
        private void PersonDetail_Load(object sender, EventArgs e)
        {
            FillPersonDetailsGrid();

        }
        private void FillPersonDetailsGrid()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate,FirstSet.CompanyId  from (SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId,Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName,  EducationLevel.EducationLevelName,Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName,  Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName,  HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo,  ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea,  ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark,  PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division  FROM PostOffice  INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN Persons  INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId  LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId  LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId  LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId  LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId  LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId  LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId  LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId  LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId  LEFT OUTER JOIN GroupMember ON Persons.PersonsId = GroupMember.PersonsId  LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet  left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode  FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo,  CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId  INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId  order by FirstSet.PersonName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41], rdr[42], rdr[43], rdr[44], rdr[45], rdr[46], rdr[47], rdr[48], rdr[49], rdr[50], rdr[51], rdr[52], rdr[53], rdr[54], rdr[55]);
                }





                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId", con);
                //Inner Join
                //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,ResidentialAddresses.PostOfficeId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, WorkingAddresses.PostOfficeId AS WAPostOfficeId, WorkingAddresses.WFlatNo, WorkingAddresses.WHouseNo, WorkingAddresses.WRoadNo, WorkingAddresses.WBlock, WorkingAddresses.WArea, WorkingAddresses.WContactNo, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId left join ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId left JOIN WorkingAddresses ON Persons.PersonsId = WorkingAddresses.PersonsId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId", con);
                //Left Join
                //sda = new SqlDataAdapter("Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.GroupName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate  from ( SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName, EducationLevel.EducationLevelName, [Group].GroupName, Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName, Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName, HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM PostOffice INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN Persons INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId LEFT OUTER JOIN [Group] ON Persons.GroupId = [Group].GroupId LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana,  Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId order by FirstSet.PersonName asc", con);           
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                //dataGridView1.DataSource = dt;
                dataGridView1.Columns[19].Width = 120;
                dataGridView1.Columns[19].DefaultCellStyle.NullValue = null;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                    }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             
            try
            {
            
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                
                UpdatePersonInfo frm = new UpdatePersonInfo();
                frm.LoadControls();
                frm.PersonIdtextBox.Text = dr.Cells[0].Value.ToString();
                frm.CountrycomboBox.Text = dr.Cells[1].Value.ToString();
                frm.txtPersonName.Text = dr.Cells[2].Value.ToString();
                frm.textNickName.Text = string.IsNullOrEmpty(dr.Cells[3].Value.ToString()) ? null : dr.Cells[3].Value.ToString();
                frm.txtFatherName.Text = string.IsNullOrEmpty(dr.Cells[4].Value.ToString()) ? null : dr.Cells[4].Value.ToString();
                frm.cmbEmailAddress.Text = string.IsNullOrEmpty(dr.Cells[5].Value.ToString()) ? null : dr.Cells[5].Value.ToString();
                frm.companyNametextBox.Text = string.IsNullOrEmpty(dr.Cells[6].Value.ToString()) ? null : dr.Cells[6].Value.ToString();
                frm.cmbJobTitle.Text = string.IsNullOrEmpty(dr.Cells[7].Value.ToString()) ? null : dr.Cells[7].Value.ToString();
                //frm.GroupNamecomboBox.Text = string.IsNullOrEmpty(dr.Cells[8].Value.ToString()) ? null : dr.Cells[8].Value.ToString();
                frm.cmbSpecialization.Text = string.IsNullOrEmpty(dr.Cells[8].Value.ToString()) ? null : dr.Cells[8].Value.ToString();
                frm.cmbProfession.Text = string.IsNullOrEmpty(dr.Cells[9].Value.ToString()) ? null : dr.Cells[9].Value.ToString();
                frm.cmbEducationalLevel.Text = string.IsNullOrEmpty(dr.Cells[10].Value.ToString()) ? null : dr.Cells[10].Value.ToString();
                frm.cmbHighestDegree.Text = string.IsNullOrEmpty(dr.Cells[11].Value.ToString()) ? null : dr.Cells[11].Value.ToString();
                frm.cmbAgeGroup.Text = string.IsNullOrEmpty(dr.Cells[12].Value.ToString()) ? null : dr.Cells[12].Value.ToString();
                frm.cmbRelationShip.Text = string.IsNullOrEmpty(dr.Cells[13].Value.ToString()) ? null : dr.Cells[13].Value.ToString();
                frm.txtWebsite.Text = string.IsNullOrEmpty(dr.Cells[14].Value.ToString()) ? null : dr.Cells[14].Value.ToString();
                frm.txtSkypeId.Text = string.IsNullOrEmpty(dr.Cells[15].Value.ToString()) ? null : dr.Cells[15].Value.ToString();
                frm.txtWhatsApp.Text = string.IsNullOrEmpty(dr.Cells[16].Value.ToString()) ? null : dr.Cells[16].Value.ToString();
                frm.txtImmo.Text = string.IsNullOrEmpty(dr.Cells[17].Value.ToString()) ? null : dr.Cells[17].Value.ToString();
                if (Convert.ToString(dr.Cells[18].Value) != string.Empty)
                {
                    byte[] data = (byte[])dr.Cells[18].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.userPictureBox.Image = Image.FromStream(ms);
                }
                else
                {

                    frm.userPictureBox.Image = null;
                }
                if (dr.Cells[1].Value.Equals("Bangladesh"))
                {
                    frm.groupBox2.Visible = true;
                    if (string.IsNullOrEmpty(dr.Cells[6].Value.ToString()))
                    {
                        frm.groupBox3.Visible = false;
                        frm.groupBox7.Visible = true;
                        frm.groupBox7.Location = new Point(466, 295);
                    }
                    else
                    {
                        frm.groupBox3.Visible = true;
                        frm.groupBox3.Location = new Point(466, 290);
                        frm.groupBox7.Visible = true;
                        frm.groupBox7.Location = new Point(466, 533);

                        frm.txtWAFlatName.Text = string.IsNullOrEmpty(dr.Cells[33].Value.ToString()) ? null : dr.Cells[33].Value.ToString();
                        frm.txtWAHouseName.Text = string.IsNullOrEmpty(dr.Cells[34].Value.ToString()) ? null : dr.Cells[34].Value.ToString();
                        frm.txtWARoadNo.Text = string.IsNullOrEmpty(dr.Cells[35].Value.ToString()) ? null : dr.Cells[35].Value.ToString();
                        frm.txtWABlock.Text = string.IsNullOrEmpty(dr.Cells[36].Value.ToString()) ? null : dr.Cells[36].Value.ToString();
                        frm.txtWAArea.Text = string.IsNullOrEmpty(dr.Cells[37].Value.ToString()) ? null : dr.Cells[37].Value.ToString();
                        frm.txtWAContactNo.Text = string.IsNullOrEmpty(dr.Cells[38].Value.ToString()) ? null : dr.Cells[38].Value.ToString();
                        frm.LandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[39].Value.ToString()) ? null : dr.Cells[39].Value.ToString();
                        frm.WABuildingNametextBox.Text = string.IsNullOrEmpty(dr.Cells[40].Value.ToString()) ? null : dr.Cells[40].Value.ToString();
                        frm.WARoadNametextBox.Text = string.IsNullOrEmpty(dr.Cells[41].Value.ToString()) ? null : dr.Cells[41].Value.ToString();
                        frm.WAdivisiontextBox.Text = dr.Cells[42].Value.ToString();
                        frm.WADistricttextBox.Text = dr.Cells[43].Value.ToString();
                        frm.WAThanatextBox.Text = dr.Cells[44].Value.ToString();
                        frm.WAPostOfficetextBox.Text = dr.Cells[45].Value.ToString();
                        frm.txtWAPostCode.Text = dr.Cells[46].Value.ToString();
                    }
                    frm.txtRAFlatNo.Text = string.IsNullOrEmpty(dr.Cells[19].Value.ToString()) ? null : dr.Cells[19].Value.ToString();
                    frm.txtRAHouseNo.Text = string.IsNullOrEmpty(dr.Cells[20].Value.ToString()) ? null : dr.Cells[20].Value.ToString();
                    frm.txtRARoadNo.Text = string.IsNullOrEmpty(dr.Cells[21].Value.ToString()) ? null : dr.Cells[21].Value.ToString();
                    frm.txtRABlock.Text = string.IsNullOrEmpty(dr.Cells[22].Value.ToString()) ? null : dr.Cells[22].Value.ToString();
                    frm.txtRAArea.Text = string.IsNullOrEmpty(dr.Cells[23].Value.ToString()) ? null : dr.Cells[23].Value.ToString();
                    frm.txtRAContactNo.Text = string.IsNullOrEmpty(dr.Cells[24].Value.ToString()) ? null : dr.Cells[24].Value.ToString();
                    frm.buildingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[25].Value.ToString()) ? null : dr.Cells[25].Value.ToString();
                    frm.roadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[26].Value.ToString()) ? null : dr.Cells[26].Value.ToString();
                    frm.nearestLandMarkTextBox.Text = string.IsNullOrEmpty(dr.Cells[27].Value.ToString()) ? null : dr.Cells[27].Value.ToString();
                    frm.cmbRADivision.Text = dr.Cells[28].Value.ToString();
                    frm.cmbRADistrict.Text = dr.Cells[29].Value.ToString();
                    frm.cmbRAThana.Text = dr.Cells[30].Value.ToString();
                    frm.cmbRAPost.Text = dr.Cells[31].Value.ToString();
                    frm.txtRAPostCode.Text = dr.Cells[32].Value.ToString();

                }
                else
                {
                    if (string.IsNullOrEmpty(dr.Cells[6].Value.ToString()))
                    {
                        frm.groupBox2.Visible = false;
                        frm.groupBox3.Visible = false;
                        frm.groupBox6.Visible = true;
                        frm.groupBox7.Visible = true;
                        frm.groupBox6.Location = new Point(466, 12);
                        frm.groupBox7.Location = new Point(466, 155);
                    }
                    else
                    {
                        frm.groupBox2.Visible = false;
                        frm.groupBox3.Visible = true;
                        frm.groupBox6.Visible = true;
                        frm.groupBox7.Visible = true;
                        frm.groupBox6.Location = new Point(466, 12);
                        frm.groupBox3.Location = new Point(466, 155);
                        frm.groupBox7.Location = new Point(466, 410);

                        frm.txtWAFlatName.Text = string.IsNullOrEmpty(dr.Cells[33].Value.ToString()) ? null : dr.Cells[33].Value.ToString();
                        frm.txtWAHouseName.Text = string.IsNullOrEmpty(dr.Cells[34].Value.ToString()) ? null : dr.Cells[34].Value.ToString();
                        frm.txtWARoadNo.Text = string.IsNullOrEmpty(dr.Cells[35].Value.ToString()) ? null : dr.Cells[35].Value.ToString();
                        frm.txtWABlock.Text = string.IsNullOrEmpty(dr.Cells[36].Value.ToString()) ? null : dr.Cells[36].Value.ToString();
                        frm.txtWAArea.Text = string.IsNullOrEmpty(dr.Cells[37].Value.ToString()) ? null : dr.Cells[37].Value.ToString();
                        frm.txtWAContactNo.Text = string.IsNullOrEmpty(dr.Cells[38].Value.ToString()) ? null : dr.Cells[38].Value.ToString();
                        frm.LandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[39].Value.ToString()) ? null : dr.Cells[39].Value.ToString();
                        frm.WABuildingNametextBox.Text = string.IsNullOrEmpty(dr.Cells[40].Value.ToString()) ? null : dr.Cells[40].Value.ToString();
                        frm.WARoadNametextBox.Text = string.IsNullOrEmpty(dr.Cells[41].Value.ToString()) ? null : dr.Cells[41].Value.ToString();
                        frm.WAdivisiontextBox.Text = dr.Cells[42].Value.ToString();
                        frm.WADistricttextBox.Text = dr.Cells[43].Value.ToString();
                        frm.WAThanatextBox.Text = dr.Cells[44].Value.ToString();
                        frm.WAPostOfficetextBox.Text = dr.Cells[45].Value.ToString();
                        frm.txtWAPostCode.Text = dr.Cells[46].Value.ToString();
                    }
                    frm.StreettextBox.Text = string.IsNullOrEmpty(dr.Cells[47].Value.ToString()) ? null : dr.Cells[47].Value.ToString();
                    frm.StatetextBox.Text = string.IsNullOrEmpty(dr.Cells[48].Value.ToString()) ? null : dr.Cells[48].Value.ToString();
                    frm.PostalCodetextBox.Text = string.IsNullOrEmpty(dr.Cells[49].Value.ToString()) ? null : dr.Cells[49].Value.ToString();
                }

                frm.BirthdateTimePicker.Text = string.IsNullOrEmpty(dr.Cells[50].Value.ToString()) ? null : dr.Cells[50].Value.ToString();
                frm.ReligioncomboBox.Text = string.IsNullOrEmpty(dr.Cells[51].Value.ToString()) ? null : dr.Cells[51].Value.ToString();
                frm.GendercomboBox.Text = string.IsNullOrEmpty(dr.Cells[52].Value.ToString()) ? null : dr.Cells[52].Value.ToString();
                frm.maritalStatuscomboBox.Text = string.IsNullOrEmpty(dr.Cells[53].Value.ToString()) ? null : dr.Cells[53].Value.ToString();
                frm.AnniversarydateTimePicker.Text = string.IsNullOrEmpty(dr.Cells[54].Value.ToString()) ? null : dr.Cells[54].Value.ToString();
                frm.companyId = string.IsNullOrEmpty(dr.Cells[55].Value.ToString()) ? null : dr.Cells[55].Value.ToString();
                frm.btnInsert.Visible = true;
                frm.btnInsert.Location = new Point(1045, 540);
                this.Visible = false;
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                FillPersonDetailsGrid();
                this.Visible = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            frm.Show();
        }


        private void SearchPersonNametextBox_TextChanged(object sender, EventArgs e)
        {
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //sda = new SqlDataAdapter("Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.GroupName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate,FirstSet.CompanyId  from ( SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName, EducationLevel.EducationLevelName, [Group].GroupName, Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName, Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName, HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM PostOffice INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN Persons INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId LEFT OUTER JOIN [Group] ON Persons.GroupId = [Group].GroupId LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana,  Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId where FirstSet.PersonName like '" + SearchPersonNametextBox.Text + "%' order by FirstSet.PersonName asc", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate,FirstSet.CompanyId  from (SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId,Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName,  EducationLevel.EducationLevelName,Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName,  Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName,  HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo,  ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea,  ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark,  PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division  FROM PostOffice  INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN Persons  INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId  LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId  LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId  LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId  LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId  LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId  LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId  LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId  LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId  LEFT OUTER JOIN GroupMember ON Persons.PersonsId = GroupMember.PersonsId  LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet  left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode  FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo,  CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId  INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId where FirstSet.PersonName like '" + SearchPersonNametextBox.Text + "%' order by FirstSet.PersonName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41], rdr[42], rdr[43], rdr[44], rdr[45], rdr[46], rdr[47], rdr[48], rdr[49], rdr[50], rdr[51], rdr[52], rdr[53], rdr[54], rdr[55]);
                }
                dataGridView1.Columns[19].Width = 120;
                dataGridView1.Columns[19].DefaultCellStyle.NullValue = null;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                    }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
