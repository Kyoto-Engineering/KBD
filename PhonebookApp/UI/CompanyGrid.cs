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

namespace PhonebookApp.UI
{
    public partial class CompanyGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;
        public CompanyGrid()
        {
            InitializeComponent();
        }

        private void CompanyGrid_Load(object sender, EventArgs e)
        {
            FillCompanyDetailsGrid();
        }

        private void FillCompanyDetailsGrid()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            sda = new SqlDataAdapter("SELECT  FirstSet.CompanyName, FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division CDivition,FirstSet.District CDistrict, FirstSet.Thana CThana,FirstSet.PostOfficeName CPostOfficeName,FirstSet.PostCode CPostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName TBuildingName, QUERYTWO.RoadName TRoadName,QUERYTWO.Division TDivision,QUERYTWO.District TDistrict, QUERYTWO.Thana TThana,QUERYTWO.PostOfficeName TPostOfficeName,QUERYTWO.PostCode TPostCode from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company INNER JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId INNER JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId INNER JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company INNER JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId INNER JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
