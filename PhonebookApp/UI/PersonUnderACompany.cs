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
    public partial class PersonUnderACompany : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public int companyid;
        public PersonUnderACompany()
        {
            InitializeComponent();
        }

        private void FillCompanyDetailsGrid()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstSet.CompanyId, FirstSet.CompanyName, FirstSet.Branch ,FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode,FirstSet.CPicture from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl,Company.CPicture,CorporateAddresses.Branch, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company LEFT JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId LEFT JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId LEFT JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId LEFT JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId LEFT JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company LEFT JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId LEFT JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38]);
                }

                dataGridView1.Columns[38].Width = 120;
                dataGridView1.Columns[38].DefaultCellStyle.NullValue = null;
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




            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    sda = new SqlDataAdapter(
            //        "SELECT FirstSet.CompanyId, FirstSet.CompanyName, FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company INNER JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId INNER JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId INNER JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company INNER JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId INNER JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc",
            //        con);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //personload();
            try

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //    try
            //    {
            //        DataGridViewRow dr = dataGridView1.CurrentRow;
            //        companyid = Convert.ToInt32(dr.Cells[0].Value.ToString());
            //        //personload();
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        cmd = new SqlCommand();
            //        cmd.Connection = con;
            //        cmd.CommandText = "Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate,FirstSet.CompanyId  from (SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId,Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName,  EducationLevel.EducationLevelName,Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName,  Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName,  HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo,  ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea,  ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark,  PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division  FROM PostOffice  INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN Persons  INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId  LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId  LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId  LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId  LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId  LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId  LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId  LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId  LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId  LEFT OUTER JOIN GroupMember ON Persons.PersonsId = GroupMember.PersonsId  LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet  left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode  FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo,  CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId  INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId where FirstSet.CompanyId = '" + companyid + "' order by FirstSet.PersonName asc";
            //        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //        dataGridView2.Rows.Clear();
            //        while (rdr.Read() == true)
            //        {
            //            dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41], rdr[42], rdr[43], rdr[44], rdr[45], rdr[46], rdr[47], rdr[48], rdr[49], rdr[50], rdr[51], rdr[52], rdr[53], rdr[54], rdr[55]);
            //        }





            //        //con = new SqlConnection(cs.DBConn);
            //        //con.Open();
            //        //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId", con);
            //        //Inner Join
            //        //sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,ResidentialAddresses.PostOfficeId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, WorkingAddresses.PostOfficeId AS WAPostOfficeId, WorkingAddresses.WFlatNo, WorkingAddresses.WHouseNo, WorkingAddresses.WRoadNo, WorkingAddresses.WBlock, WorkingAddresses.WArea, WorkingAddresses.WContactNo, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons INNER JOIN Country ON Persons.CountryId = Country.CountryId INNER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId INNER JOIN Company ON Persons.CompanyId = Company.CompanyId  INNER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId INNER JOIN Category ON Persons.CategoryId = Category.CategoryId INNER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId INNER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId INNER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId INNER JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId INNER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId INNER JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId left join ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId left JOIN WorkingAddresses ON Persons.PersonsId = WorkingAddresses.PersonsId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId", con);
            //        //Left Join
            //        //sda = new SqlDataAdapter("Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.GroupName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate  from ( SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName, EducationLevel.EducationLevelName, [Group].GroupName, Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName, Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName, HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM PostOffice INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN Persons INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId LEFT OUTER JOIN [Group] ON Persons.GroupId = [Group].GroupId LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana,  Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId order by FirstSet.PersonName asc", con);           
            //        //DataTable dt = new DataTable();
            //        //sda.Fill(dt);
            //        //dataGridView1.DataSource = dt;
            //        dataGridView2.Columns[19].Width = 120;
            //        dataGridView2.Columns[19].DefaultCellStyle.NullValue = null;
            //        for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //            if (dataGridView2.Columns[i] is DataGridViewImageColumn)
            //            {
            //                ((DataGridViewImageColumn)dataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;

            //            }
            //        con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        private void personload()
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                companyid = Convert.ToInt32(dr.Cells[0].Value.ToString());
                //personload();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select FirstSet.PersonsId,FirstSet.CountryName, FirstSet.PersonName,FirstSet.NickName,FirstSet.FatherName,FirstSet.Email,FirstSet.CompanyName,FirstSet.JobTitleName,FirstSet.Specialization,FirstSet.ProfessionName,FirstSet.EducationLevelName,FirstSet.HighestDegree,FirstSet.AgeGroupLevel,FirstSet.RelationShip,FirstSet.Website,FirstSet.SkypeId,FirstSet.WhatsAppId,FirstSet.ImoNumber,FirstSet.Picture,FirstSet.RFlatNo,FirstSet.RHouseNo,FirstSet.RRoadNo,FirstSet.RBlock,FirstSet.RArea,FirstSet.RContactNo,FirstSet.BuildingName,FirstSet.RoadName,FirstSet.LandMark,FirstSet.Division,FirstSet.District,FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode,thirdSet.CFlatNo, thirdSet.CHouseNo, thirdSet.CRoadNo, thirdSet.CBlock,thirdSet.CArea,thirdSet.CContactNo,thirdSet.CLandmark,  thirdSet.BuildingName, thirdSet.RoadName, thirdSet.Division,thirdSet.District, thirdSet.Thana, thirdSet.PostOfficeName, thirdSet.PostCode,secondSet.Street, secondSet.State, secondSet.PostalCode,FirstSet.DateOfBirth,FirstSet.ReligionName,FirstSet.GenderName,FirstSet.MaritalStatusName,FirstSet.MarriageAnniversaryDate,FirstSet.CompanyId  from (SELECT Persons.PersonsId,Persons.PersonName, Persons.NickName, Persons.FatherName, Persons.Website, Persons.SkypeId, Persons.WhatsAppId,Persons.ImoNumber, Persons.DateOfBirth, Persons.MarriageAnniversaryDate, Persons.Picture, AgeGroup.AgeGroupLevel, Countries.CountryName,  EducationLevel.EducationLevelName,Gender.GenderName, JobTitle.JobTitleName, Profession.ProfessionName,  Religion.ReligionName, Specializations.Specialization, RelationShips.RelationShip, MaritalStatus.MaritalStatusName,  HighestDegrees.HighestDegree, EmailBank.Email, Company.CompanyName, Company.CompanyId, ResidentialAddresses.RFlatNo,  ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea,  ResidentialAddresses.RContactNo, ResidentialAddresses.BuildingName, ResidentialAddresses.RoadName, ResidentialAddresses.LandMark,  PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division  FROM PostOffice  INNER JOIN ResidentialAddresses ON PostOffice.PostOfficeId = ResidentialAddresses.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN Persons  INNER JOIN Countries ON Persons.CountryId = Countries.CountryId ON ResidentialAddresses.PersonsId = Persons.PersonsId  LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId  LEFT OUTER JOIN  HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId  LEFT OUTER JOIN MaritalStatus ON Persons.MaritalStatusId = MaritalStatus.MaritalStatusId  LEFT OUTER JOIN RelationShips ON Persons.RelationShipsId = RelationShips.RelationShipsId  LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId  LEFT OUTER JOIN  Religion ON Persons.ReligionId = Religion.ReligionId  LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId  LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  LEFT OUTER JOIN Gender ON Persons.GenderId = Gender.GenderId  LEFT OUTER JOIN GroupMember ON Persons.PersonsId = GroupMember.PersonsId  LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId = AgeGroup.AgeGroupId) as FirstSet  left join (SELECT Persons.PersonsId, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode  FROM Persons LEFT OUTER JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId) as secondSet on Firstset.PersonsId= SecondSet.PersonsId left join (SELECT Persons.PersonsId, Company.CompanyId, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo,  CorporateAddresses.CBlock, CorporateAddresses.CArea,  CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, PostOffice.PostOfficeName, PostOffice.PostCode, Thanas.Thana, Districts.District, Divisions.Division FROM  CorporateAddresses INNER JOIN Company ON CorporateAddresses.CompanyId = Company.CompanyId  INNER JOIN  PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN  Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID  RIGHT OUTER JOIN  Persons ON Company.CompanyId = Persons.CompanyId) as thirdSet on FirstSet.PersonsId=thirdSet.PersonsId where FirstSet.CompanyId = '" + companyid + "' order by FirstSet.PersonName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38], rdr[39], rdr[40], rdr[41], rdr[42], rdr[43], rdr[44], rdr[45], rdr[46], rdr[47], rdr[48], rdr[49], rdr[50], rdr[51], rdr[52], rdr[53], rdr[54], rdr[55]);
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
                dataGridView2.Columns[19].Width = 120;
                dataGridView2.Columns[19].DefaultCellStyle.NullValue = null;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    if (dataGridView2.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                    }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void companyNameSearchtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstSet.CompanyId, FirstSet.CompanyName,FirstSet.Branch, FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode,FirstSet.CPicture from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl,Company.CPicture, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark,CorporateAddresses.Branch, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company LEFT JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId LEFT JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId LEFT JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId LEFT JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId LEFT JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet LEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company LEFT JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId LEFT JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId where FirstSet.CompanyName like '" + companyNameSearchtextBox.Text + "%' order by FirstSet.CompanyName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByCompanyIdtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstSet.CompanyId, FirstSet.CompanyName,FirstSet.Branch, FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode,FirstSet.CPicture from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl,Company.CPicture,CorporateAddresses.Branch, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company LEFT JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId LEFT JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId LEFT JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId LEFT JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId LEFT JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet LEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company LEFT JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId LEFT JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId where FirstSet.CompanyId like '" + SearchByCompanyIdtextBox.Text + "%' order by FirstSet.CompanyName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36], rdr[37], rdr[38]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonUnderACompany_Load(object sender, EventArgs e)
        {
            FillCompanyDetailsGrid();
            //personload();
        }
    }
}
