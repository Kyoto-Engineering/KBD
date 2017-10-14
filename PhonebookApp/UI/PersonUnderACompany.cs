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
        }
    }
}
