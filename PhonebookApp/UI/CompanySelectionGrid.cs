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
    public partial class CompanySelectionGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public CompanySelectionGrid()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Dispose();
                frm1 frm = new frm1();
                frm.Show();
                frm.companyNametextBox.Text = dr.Cells[0].Value.ToString();
             string companyId= frm.CompanyIdtextBox.Text = dr.Cells[2].Value.ToString();
                //frm.txtClientName.Text = dr.Cells[1].Value.ToString();

                SqlConnection con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 =
                    "SELECT CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where Company.CompanyId='" +
                    companyId + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    frm.txtWAFlatName.Text = rdr["CFlatNo"].ToString();
                    frm.txtWAHouseName.Text = rdr["CHouseNo"].ToString();
                    frm.txtWARoadNo.Text = rdr["CRoadNo"].ToString();
                    frm.txtWABlock.Text = rdr["CBlock"].ToString();
                    frm.txtWAArea.Text = rdr["CArea"].ToString();
                    frm.LandmarktextBox.Text = rdr["CLandmark"].ToString();
                    frm.txtWAContactNo.Text = rdr["CContactNo"].ToString();
                    frm.WABuildingNametextBox.Text = rdr["BuildingName"].ToString();
                    frm.WARoadNametextBox.Text = rdr["RoadName"].ToString();
                    frm.WAdivisiontextBox.Text = rdr["Division"].ToString();
                    frm.WADistricttextBox.Text = rdr["District"].ToString();
                    frm.WAThanatextBox.Text = rdr["Thana"].ToString();
                    frm.WAPostOfficetextBox.Text = rdr["PostOfficeName"].ToString();
                    frm.txtWAPostCode.Text = rdr["PostCode"].ToString();
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
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompanySelectionGrid_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Company.CompanyName,isnull(nullif(CorporateAddresses.CFlatNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CHouseNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CRoadNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CBlock,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CArea,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CLandmark,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CContactNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as Addresss, Company.CompanyId FROM Company INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  order by Company.CompanyId asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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
