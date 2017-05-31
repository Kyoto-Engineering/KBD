﻿using System;
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
            con = new SqlConnection(cs.DBConn);
            con.Open();
            //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId", con);
            //Inner Join
            //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,ResidentialAddresses.PostOfficeId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, WorkingAddresses.PostOfficeId AS WAPostOfficeId, WorkingAddresses.WFlatNo, WorkingAddresses.WHouseNo, WorkingAddresses.WRoadNo, WorkingAddresses.WBlock, WorkingAddresses.WArea, WorkingAddresses.WContactNo, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId left join ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId left JOIN WorkingAddresses ON Persons.PersonsId = WorkingAddresses.PersonsId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId", con);
            //Left Join
            sda = new SqlDataAdapter("SELECT  A.PersonsId, A.CountryName, A.PersonName, A.NickName, A.FatherName, A.Email, S.CompanyName, A.JobTitleName, A.GroupName, A.Specialization, A.ProfessionName, A.EducationLevelName, A.HighestDegree, A.AgeGroupLevel, A.RelationShip, A.Website, A.SkypeId, A.WhatsAppId, A.ImoNumber,A.Picture, S.RFlatNo, S.RHouseNo, S.RRoadNo, S.RBlock, S.RArea, S.RContactNo, S.BuildingName,S.RoadName,S.LandMark, S.Division, S.District, S.Thana, S.PostOfficeName, S.PostCode, F.CFlatNo, F.CHouseNo, F.CRoadNo, F.CBlock, F.CArea, F.CContactNo, F.CLandmark,F.BuildingName,F.RoadName, F.PostOfficeName, F.PostCode, A.Street, A.State, A.PostalCode, A.DateOfBirth, A.ReligionName, A.GenderName, A.MaritalStatusName, A.MarriageAnniversaryDate FROM(SELECT Persons.PersonsId,Persons.PersonName,CountryName,Persons.NickName,Persons.FatherName,EmailBank.Email,JobTitle.JobTitleName,[Group].GroupName,Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,Persons.Picture, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode, Persons.DateOfBirth, Religion.ReligionName, Gender.GenderName, MaritalStatus.MaritalStatusName, Persons.MarriageAnniversaryDate from Persons  LEFT JOIN  Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN   RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId LEFT JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId LEFT JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN [Group] ON Persons.GroupId = [Group].GroupId LEFT JOIN Countries ON Persons.CountryId = Countries.CountryId LEFT JOIN Gender ON Persons.GenderId = Gender.GenderId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId )as A LEFT JOIN(SELECT Persons.PersonsId, Persons.PersonName,Company.CompanyName, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName,ResidentialAddresses.RoadName,ResidentialAddresses.LandMark, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM Persons INNER JOIN Company ON Persons.CompanyId = Company.CompanyId INNER JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId INNER JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS S ON A.PersonsId=S.PersonsId LEFT JOIN(SELECT   Persons.PersonsId,Persons.PersonName, Company.CompanyName, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CContactNo,CorporateAddresses.CLandmark,CorporateAddresses.BuildingName,CorporateAddresses.RoadName, Divisions.Division,Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN Persons INNER JOIN Company ON Persons.CompanyId = Company.CompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID) as F ON A.PersonsId = F.PersonsId order by A.PersonName asc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[19].Width = 120;
            dataGridView1.Columns[19].DefaultCellStyle.NullValue = null;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    
                }
            con.Close();
        }
       
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string x, y;
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                UpdatePersonInfo frm = new UpdatePersonInfo();
                frm.Show();
                frm.PersonIdtextBox.Text = dr.Cells[0].Value.ToString();
                frm.CountrycomboBox.Text = dr.Cells[1].Value.ToString();
                frm.txtPersonName.Text = dr.Cells[2].Value.ToString();
                frm.textNickName.Text = string.IsNullOrEmpty(dr.Cells[3].Value.ToString()) ? null : dr.Cells[3].Value.ToString();
                frm.txtFatherName.Text = string.IsNullOrEmpty(dr.Cells[4].Value.ToString()) ? null : dr.Cells[4].Value.ToString();
                frm.cmbEmailAddress.Text = string.IsNullOrEmpty(dr.Cells[5].Value.ToString()) ? null : dr.Cells[5].Value.ToString();
                frm.cmbCompanyName.Text = string.IsNullOrEmpty(dr.Cells[6].Value.ToString()) ? null : dr.Cells[6].Value.ToString();
                frm.cmbJobTitle.Text = string.IsNullOrEmpty(dr.Cells[7].Value.ToString()) ? null : dr.Cells[7].Value.ToString();
                frm.GroupNamecomboBox.Text = string.IsNullOrEmpty(dr.Cells[8].Value.ToString()) ? null : dr.Cells[8].Value.ToString();
                frm.cmbSpecialization.Text = string.IsNullOrEmpty(dr.Cells[9].Value.ToString()) ? null : dr.Cells[9].Value.ToString();
                frm.cmbProfession.Text = string.IsNullOrEmpty(dr.Cells[10].Value.ToString()) ? null : dr.Cells[10].Value.ToString();
                frm.cmbEducationalLevel.Text = string.IsNullOrEmpty(dr.Cells[11].Value.ToString()) ? null : dr.Cells[11].Value.ToString();
                frm.cmbHighestDegree.Text = string.IsNullOrEmpty(dr.Cells[12].Value.ToString()) ? null : dr.Cells[12].Value.ToString();
                frm.cmbAgeGroup.Text = string.IsNullOrEmpty(dr.Cells[13].Value.ToString()) ? null : dr.Cells[13].Value.ToString();
                frm.cmbRelationShip.Text = string.IsNullOrEmpty(dr.Cells[14].Value.ToString()) ? null : dr.Cells[14].Value.ToString();
                frm.txtWebsite.Text = string.IsNullOrEmpty(dr.Cells[15].Value.ToString()) ? null : dr.Cells[15].Value.ToString();
                frm.txtSkypeId.Text = string.IsNullOrEmpty(dr.Cells[16].Value.ToString()) ? null : dr.Cells[16].Value.ToString();
                frm.txtWhatsApp.Text = string.IsNullOrEmpty(dr.Cells[17].Value.ToString()) ? null : dr.Cells[17].Value.ToString();
                frm.txtImmo.Text = string.IsNullOrEmpty(dr.Cells[18].Value.ToString()) ? null : dr.Cells[18].Value.ToString();
                if (Convert.ToString(dr.Cells[19].Value) != string.Empty)
                    
                {
                    byte[] data = (byte[])dr.Cells[19].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.userPictureBox.Image = Image.FromStream(ms);
                }               
                else
                {

                    frm.userPictureBox.Image = null;
                }
                if (dr.Cells[1].Value.Equals("Bangladesh"))
                {
                    frm.groupBox2.Show();
                    if (string.IsNullOrEmpty(dr.Cells[6].Value.ToString()))
                    {
                        frm.groupBox3.Hide();
                        frm.groupBox7.Show();
                        frm.groupBox7.Location = new Point(466, 295);
                    }
                    else
                    {
                        frm.groupBox3.Show();
                        frm.groupBox3.Location = new Point(466, 290);
                        frm.groupBox7.Show();
                        frm.groupBox7.Location = new Point(466, 533);
                    }
                    frm.txtRAFlatNo.Text = string.IsNullOrEmpty(dr.Cells[20].Value.ToString()) ? null : dr.Cells[20].Value.ToString();
                    frm.txtRAHouseNo.Text = string.IsNullOrEmpty(dr.Cells[21].Value.ToString()) ? null : dr.Cells[21].Value.ToString();
                    frm.txtRARoadNo.Text = string.IsNullOrEmpty(dr.Cells[22].Value.ToString()) ? null : dr.Cells[22].Value.ToString();
                    frm.txtRABlock.Text = string.IsNullOrEmpty(dr.Cells[23].Value.ToString()) ? null : dr.Cells[23].Value.ToString();
                    frm.txtRAArea.Text = string.IsNullOrEmpty(dr.Cells[24].Value.ToString()) ? null : dr.Cells[24].Value.ToString();
                    frm.txtRAContactNo.Text = string.IsNullOrEmpty(dr.Cells[25].Value.ToString()) ? null : dr.Cells[25].Value.ToString();
                    frm.buildingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[26].Value.ToString()) ? null : dr.Cells[26].Value.ToString();
                    frm.roadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[27].Value.ToString()) ? null : dr.Cells[27].Value.ToString();
                    frm.nearestLandMarkTextBox.Text = string.IsNullOrEmpty(dr.Cells[28].Value.ToString()) ? null : dr.Cells[28].Value.ToString();
                    frm.cmbRADivision.Text = dr.Cells[29].Value.ToString();
                    frm.cmbRADistrict.Text = dr.Cells[30].Value.ToString();
                    frm.cmbRAThana.Text = dr.Cells[31].Value.ToString();
                    frm.cmbRAPost.Text = dr.Cells[32].Value.ToString();
                    frm.txtRAPostCode.Text = dr.Cells[33].Value.ToString();

                }
                else
                {
                    frm.groupBox2.Hide();
                    frm.groupBox3.Hide();
                    frm.groupBox6.Show();
                    frm.groupBox7.Show();
                    frm.groupBox6.Location = new Point(466, 12);
                    frm.groupBox7.Location = new Point(466, 155);
                    frm.StreettextBox.Text = string.IsNullOrEmpty(dr.Cells[45].Value.ToString()) ? null : dr.Cells[45].Value.ToString();
                    frm.StatetextBox.Text = string.IsNullOrEmpty(dr.Cells[46].Value.ToString()) ? null : dr.Cells[46].Value.ToString();
                    frm.PostalCodetextBox.Text = string.IsNullOrEmpty(dr.Cells[47].Value.ToString()) ? null : dr.Cells[47].Value.ToString();
                }

                frm.BirthdateTimePicker.Text = string.IsNullOrEmpty(dr.Cells[48].Value.ToString()) ? null : dr.Cells[48].Value.ToString();
                frm.ReligioncomboBox.Text = string.IsNullOrEmpty(dr.Cells[49].Value.ToString()) ? null : dr.Cells[49].Value.ToString();
                frm.GendercomboBox.Text = string.IsNullOrEmpty(dr.Cells[50].Value.ToString()) ? null : dr.Cells[50].Value.ToString();
                frm.maritalStatuscomboBox.Text = string.IsNullOrEmpty(dr.Cells[51].Value.ToString()) ? null : dr.Cells[51].Value.ToString();
                frm.AnniversarydateTimePicker.Text = string.IsNullOrEmpty(dr.Cells[52].Value.ToString()) ? null : dr.Cells[52].Value.ToString();
                   
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
            con = new SqlConnection(cs.DBConn);
            con.Open();
            sda = new SqlDataAdapter("SELECT  A.PersonsId, A.CountryName, A.PersonName, A.NickName, A.FatherName, A.Email, S.CompanyName, A.JobTitleName, A.GroupName, A.Specialization, A.ProfessionName, A.EducationLevelName, A.HighestDegree, A.AgeGroupLevel, A.RelationShip, A.Website, A.SkypeId, A.WhatsAppId, A.ImoNumber,A.Picture, S.RFlatNo, S.RHouseNo, S.RRoadNo, S.RBlock, S.RArea, S.RContactNo, S.BuildingName,S.RoadName,S.LandMark, S.Division, S.District, S.Thana, S.PostOfficeName, S.PostCode, F.CFlatNo, F.CHouseNo, F.CRoadNo, F.CBlock, F.CArea, F.CContactNo, F.CLandmark,F.BuildingName,F.RoadName, F.PostOfficeName, F.PostCode, A.Street, A.State, A.PostalCode, A.DateOfBirth, A.ReligionName, A.GenderName, A.MaritalStatusName, A.MarriageAnniversaryDate FROM(SELECT Persons.PersonsId,Persons.PersonName,CountryName,Persons.NickName,Persons.FatherName,EmailBank.Email,JobTitle.JobTitleName,[Group].GroupName,Specializations.Specialization, Profession.ProfessionName, EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,Persons.Picture, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode, Persons.DateOfBirth, Religion.ReligionName, Gender.GenderName, MaritalStatus.MaritalStatusName, Persons.MarriageAnniversaryDate from Persons  LEFT JOIN  Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT JOIN   RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId LEFT JOIN Religion ON Persons.ReligionId = Religion.ReligionId LEFT JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId LEFT JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId LEFT JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId LEFT JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId LEFT JOIN [Group] ON Persons.GroupId = [Group].GroupId LEFT JOIN Countries ON Persons.CountryId = Countries.CountryId LEFT JOIN Gender ON Persons.GenderId = Gender.GenderId LEFT JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId )as A LEFT JOIN(SELECT Persons.PersonsId, Persons.PersonName,Company.CompanyName, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName,ResidentialAddresses.RoadName,ResidentialAddresses.LandMark, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM Persons INNER JOIN Company ON Persons.CompanyId = Company.CompanyId INNER JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId INNER JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS S ON A.PersonsId=S.PersonsId LEFT JOIN(SELECT   Persons.PersonsId,Persons.PersonName, Company.CompanyName, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CContactNo,CorporateAddresses.CLandmark,CorporateAddresses.BuildingName,CorporateAddresses.RoadName, Divisions.Division,Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM PostOffice INNER JOIN Persons INNER JOIN Company ON Persons.CompanyId = Company.CompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId ON PostOffice.PostOfficeId = CorporateAddresses.PostOfficeId INNER JOIN Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID INNER JOIN Thanas ON Districts.D_ID = Thanas.D_ID ON PostOffice.T_ID = Thanas.T_ID) as F ON A.PersonsId = F.PersonsId where A.PersonName like '" + SearchPersonNametextBox.Text + "%' order by A.PersonName asc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
    }
}
