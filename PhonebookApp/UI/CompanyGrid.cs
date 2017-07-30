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
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstSet.CompanyId, FirstSet.CompanyName, FirstSet.CompanyTypeName,FirstSet.Branch, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode,FirstSet.CPicture from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl,Company.CPicture,CorporateAddresses.Branch, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company LEFT JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId LEFT JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId LEFT JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId LEFT JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId LEFT JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company LEFT JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId LEFT JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28], rdr[29], rdr[30], rdr[31], rdr[32], rdr[33], rdr[34], rdr[35], rdr[36],rdr[37]);
                }

                dataGridView1.Columns[37].Width = 120;
                dataGridView1.Columns[37].DefaultCellStyle.NullValue = null;
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
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                
                frmUpdateCompany frm=new frmUpdateCompany();
                frm.LoadControls();
                frm.CompanyIdtextBox.Text = dr.Cells[0].Value.ToString();
                frm.CompanyNameTextBox.Text = dr.Cells[1].Value.ToString();
                frm.cmbCompanytype.Text = dr.Cells[2].Value.ToString();
                if (!string.IsNullOrEmpty(dr.Cells[3].Value.ToString()))
                {
                    frm.checkBox1.Checked=true;
                    frm.textBox1.Text = dr.Cells[3].Value.ToString();
                }
                
                frm.IndustryCategorycomboBox.Text = dr.Cells[4].Value.ToString();
                frm.cmbNatureOfClient.Text = dr.Cells[5].Value.ToString();               
                frm.EmailtextBox.Text = string.IsNullOrEmpty(dr.Cells[6].Value.ToString()) ? null : dr.Cells[6].Value.ToString();              
                frm.ContactNotextBox.Text = string.IsNullOrEmpty(dr.Cells[7].Value.ToString()) ? null : dr.Cells[7].Value.ToString();
                frm.IdentificationNotextBox.Text = string.IsNullOrEmpty(dr.Cells[8].Value.ToString()) ? null : dr.Cells[8].Value.ToString();
                frm.WebSiteUrltextBox.Text = string.IsNullOrEmpty(dr.Cells[9].Value.ToString()) ? null : dr.Cells[9].Value.ToString();
                frm.cFlatNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[10].Value.ToString()) ? null : dr.Cells[10].Value.ToString();
                frm.cHouseNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[11].Value.ToString()) ? null : dr.Cells[11].Value.ToString();
                frm.cRoadNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[12].Value.ToString()) ? null : dr.Cells[12].Value.ToString();
                frm.blocktextBox.Text = string.IsNullOrEmpty(dr.Cells[13].Value.ToString()) ? null : dr.Cells[13].Value.ToString();
                frm.cAreaTextBox.Text = string.IsNullOrEmpty(dr.Cells[14].Value.ToString()) ? null : dr.Cells[14].Value.ToString();
                frm.cLandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[15].Value.ToString()) ? null : dr.Cells[15].Value.ToString();
                frm.cContactNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[16].Value.ToString()) ? null : dr.Cells[16].Value.ToString();
                frm.cBuldingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[17].Value.ToString()) ? null : dr.Cells[17].Value.ToString();
                frm.cRoadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[18].Value.ToString()) ? null : dr.Cells[18].Value.ToString();               
                frm.cDivisionCombo.Text = dr.Cells[19].Value.ToString();
                frm.cDistCombo.Text = dr.Cells[20].Value.ToString();
                frm.cThanaCombo.Text = dr.Cells[21].Value.ToString();
                frm.cPostOfficeCombo.Text = dr.Cells[22].Value.ToString();
                frm.cPostCodeTextBox.Text = dr.Cells[23].Value.ToString();
                frm.tFlatNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[24].Value.ToString()) ? null : dr.Cells[24].Value.ToString();
                frm.tHouseNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[25].Value.ToString()) ? null : dr.Cells[25].Value.ToString();
                frm.tRoadNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[26].Value.ToString()) ? null : dr.Cells[26].Value.ToString();
                frm.FblocktextBox.Text = string.IsNullOrEmpty(dr.Cells[27].Value.ToString()) ? null : dr.Cells[27].Value.ToString();
                frm.tAreaTextBox.Text = string.IsNullOrEmpty(dr.Cells[28].Value.ToString()) ? null : dr.Cells[28].Value.ToString();
                frm.tLandmarktextBox.Text = string.IsNullOrEmpty(dr.Cells[29].Value.ToString()) ? null : dr.Cells[29].Value.ToString();
                frm.tContactNoTextBox.Text = string.IsNullOrEmpty(dr.Cells[30].Value.ToString()) ? null : dr.Cells[30].Value.ToString();
                frm.tBuldingNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[31].Value.ToString()) ? null : dr.Cells[31].Value.ToString();
                frm.tRoadNameTextBox.Text = string.IsNullOrEmpty(dr.Cells[32].Value.ToString()) ? null : dr.Cells[32].Value.ToString();                
                frm.tDivisionCombo.Text = dr.Cells[33].Value.ToString();
                frm.tDistrictCombo.Text = dr.Cells[34].Value.ToString();
                frm.tThenaCombo.Text = dr.Cells[35].Value.ToString();
                frm.tPostCombo.Text = dr.Cells[36].Value.ToString();
                frm.tPostCodeTextBox.Text = dr.Cells[37].Value.ToString();
                if (Convert.ToString(dr.Cells[38].Value) != string.Empty)
                {
                    byte[] data = (byte[])dr.Cells[38].Value;
                    MemoryStream ms = new MemoryStream(data);
                    frm.pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {

                    frm.pictureBox1.Image = null;
                }
                this.Visible = false;
                frm.ShowDialog();
                companyNameSearchtextBox.Clear();
                dataGridView1.Rows.Clear();
                FillCompanyDetailsGrid();
                this.Visible = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompanyGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            frm.Show();
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

        private void companyNameSearchtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchByCompanyIdtextBox.Clear();
        }

        private void SearchByCompanyIdtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            companyNameSearchtextBox.Clear();
        }
    }
}
