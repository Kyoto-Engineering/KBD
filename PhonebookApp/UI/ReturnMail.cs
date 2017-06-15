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
using PhonebookApp.LogInUI;

namespace PhonebookApp.UI
{
    public partial class ReturnMail : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public string user_id;
        public ReturnMail()
        {
            InitializeComponent();
        }

        private void ReturnMail_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            FillGrid();
        }

        private void FillGrid()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Firstset.PersonsId,Firstset.PersonName,Firstset.RAddresss,Secondset.CompanyName,Secondset.CAddresss,Secondset.CompanyId from (select Persons.PersonsId,Persons.PersonName,isnull(nullif(ResidentialAddresses.RFlatNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RHouseNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RRoadNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RBlock,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RArea,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.LandMark,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RContactNo,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(ResidentialAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as RAddresss FROM Persons INNER JOIN ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId INNER JOIN PostOffice ON ResidentialAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID) as Firstset LEFT JOIN (select Persons.PersonsId, Company.CompanyId,Company.CompanyName,isnull(nullif(CorporateAddresses.CFlatNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CHouseNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CRoadNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CBlock,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CArea,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CLandmark,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.CContactNo,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.BuildingName,\'\') + \', \',\'\') + isnull(nullif(CorporateAddresses.RoadName,\'\') + \', \',\'\') + isnull(nullif(PostOffice.PostOfficeName,\'\') + \', \',\'\') + CONVERT(varchar(10), PostOffice.PostCode) + \', \'+isnull(nullif(Thanas.Thana,\'\')+ \', \',\'\') +isnull(nullif(Districts.District,\'\'),\'\') as CAddresss FROM Company INNER JOIN Persons ON Company.CompanyId=Persons.CompanyId INNER JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID) as Secondset on Firstset.PersonsId=Secondset.PersonsId order by Firstset.PersonsId asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
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
