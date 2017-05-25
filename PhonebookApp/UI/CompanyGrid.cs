﻿using System;
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                sda = new SqlDataAdapter(
                    "SELECT FirstSet.CompanyId, FirstSet.CompanyName, FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division CDivision,FirstSet.District CDistrict, FirstSet.Thana CThana,FirstSet.PostOfficeName CPostOfficeName,FirstSet.PostCode CPostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName TBuildingName, QUERYTWO.RoadName TRoadName,QUERYTWO.Division TDivision,QUERYTWO.District TDistrict, QUERYTWO.Thana TThana,QUERYTWO.PostOfficeName TPostOfficeName,QUERYTWO.PostCode TPostCode from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company INNER JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId INNER JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId INNER JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company INNER JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId INNER JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc",
                    con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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
                this.Hide();
                frmUpdateCompany frm=new frmUpdateCompany();
                frm.Show();
                frm.CompanyIdtextBox.Text = dr.Cells[0].Value.ToString();
                frm.CompanyNameTextBox.Text = dr.Cells[1].Value.ToString();
                frm.cmbCompanytype.Text = dr.Cells[2].Value.ToString();
                frm.IndustryCategorycomboBox.Text = dr.Cells[3].Value.ToString();
                frm.cmbNatureOfClient.Text = dr.Cells[4].Value.ToString();               
                frm.EmailtextBox.Text = string.IsNullOrEmpty(dr.Cells[5].Value.ToString()) ? null : dr.Cells[5].Value.ToString();              
                frm.ContactNotextBox.Text = string.IsNullOrEmpty(dr.Cells[6].Value.ToString()) ? null : dr.Cells[6].Value.ToString();
                frm.IdentificationNotextBox.Text = string.IsNullOrEmpty(dr.Cells[7].Value.ToString()) ? null : dr.Cells[7].Value.ToString();
                frm.WebSiteUrltextBox.Text = string.IsNullOrEmpty(dr.Cells[8].Value.ToString()) ? null : dr.Cells[8].Value.ToString();
                frm.cFlatNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[9].Value.ToString()) ? null : dr.Cells[9].Value.ToString();
                frm.cHouseNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[10].Value.ToString()) ? null : dr.Cells[10].Value.ToString();
                frm.cRoadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[11].Value.ToString()) ? null : dr.Cells[11].Value.ToString();
                frm.blocktextBox.Text = string.IsNullOrEmpty(dr.Cells[12].Value.ToString()) ? null : dr.Cells[12].Value.ToString();
                frm.cAreaTextBox.Text = string.IsNullOrEmpty(dr.Cells[13].Value.ToString()) ? null : dr.Cells[13].Value.ToString();
                frm.cLandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[14].Value.ToString()) ? null : dr.Cells[14].Value.ToString();
                frm.cContactNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[15].Value.ToString()) ? null : dr.Cells[15].Value.ToString();
                frm.cBuldingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[16].Value.ToString()) ? null : dr.Cells[16].Value.ToString();
                frm.cRoadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[17].Value.ToString()) ? null : dr.Cells[17].Value.ToString();               
                frm.cDivisionCombo.Text = dr.Cells[18].Value.ToString();
                frm.cDistCombo.Text = dr.Cells[19].Value.ToString();
                frm.cThanaCombo.Text = dr.Cells[20].Value.ToString();
                frm.cPostOfficeCombo.Text = dr.Cells[21].Value.ToString();
                frm.cPostCodeTextBox.Text = dr.Cells[22].Value.ToString();
                frm.tFlatNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[23].Value.ToString()) ? null : dr.Cells[23].Value.ToString();
                frm.tHouseNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[24].Value.ToString()) ? null : dr.Cells[24].Value.ToString();
                frm.tRoadNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[25].Value.ToString()) ? null : dr.Cells[25].Value.ToString();
                frm.FblocktextBox.Text = string.IsNullOrEmpty(dr.Cells[26].Value.ToString()) ? null : dr.Cells[26].Value.ToString();
                frm.tAreaTextBox.Text = string.IsNullOrEmpty(dr.Cells[27].Value.ToString()) ? null : dr.Cells[27].Value.ToString();
                frm.tLandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[28].Value.ToString()) ? null : dr.Cells[28].Value.ToString();
                frm.tContactNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[29].Value.ToString()) ? null : dr.Cells[29].Value.ToString();
                frm.tBuldingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[30].Value.ToString()) ? null : dr.Cells[30].Value.ToString();
                frm.tRoadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[31].Value.ToString()) ? null : dr.Cells[31].Value.ToString();                
                frm.tDivisionCombo.Text = dr.Cells[32].Value.ToString();
                frm.tDistrictCombo.Text = dr.Cells[33].Value.ToString();
                frm.tThenaCombo.Text = dr.Cells[34].Value.ToString();
                frm.tPostCombo.Text = dr.Cells[35].Value.ToString();
                frm.tPostCodeTextBox.Text = dr.Cells[36].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
