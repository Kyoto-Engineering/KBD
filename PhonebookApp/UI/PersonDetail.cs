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
            sda = new SqlDataAdapter("SELECT Country.CountryName, Persons.PersonName, Persons.NickName, Persons.FatherName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName, HighestDegrees.HighestDegree, AgeGroup.AgeGroupLevel, RelationShips.RelationShip, Persons.Website, Persons.SkypeId, Persons.WhatsAppId, Persons.ImoNumber,ResidentialAddresses.PostOfficeId, ResidentialAddresses.RFlatNo, ResidentialAddresses.RHouseNo, ResidentialAddresses.RRoadNo, ResidentialAddresses.RBlock, ResidentialAddresses.RArea, ResidentialAddresses.RContactNo, WorkingAddresses.PostOfficeId AS WAPostOfficeId, WorkingAddresses.WFlatNo, WorkingAddresses.WHouseNo, WorkingAddresses.WRoadNo, WorkingAddresses.WBlock, WorkingAddresses.WArea, WorkingAddresses.WContactNo, ForeignAddress.Street, ForeignAddress.State, ForeignAddress.PostalCode FROM Persons left JOIN Country ON Persons.CountryId = Country.CountryId left JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId left JOIN Company ON Persons.CompanyId = Company.CompanyId  left JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId left JOIN Category ON Persons.CategoryId = Category.CategoryId left JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId left JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId left JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId left JOIN HighestDegrees ON Persons.HighestDegreeId = HighestDegrees.HighestDegreeId left JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId left JOIN RelationShips ON Persons.RelationShipsId=RelationShips.RelationShipsId left join ResidentialAddresses ON Persons.PersonsId = ResidentialAddresses.PersonsId left JOIN WorkingAddresses ON Persons.PersonsId = WorkingAddresses.PersonsId left JOIN ForeignAddress ON Persons.PersonsId = ForeignAddress.PersonsId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void PersonDetailsShow()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select RTRIM(Person.PersonName) PersonName,RTRIM(Person.Email) EmailAddress,RTRIM(Person.ContactNo) ContactNo,RTRIM(Person.Specialization) Specialization,RTRIM(Person.Profession) Profession,RTRIM(Person.EducationalLevel) EducationalLevel,RTRIM(Person.HighestDegree) HighestDegree,RTRIM(Person.AgeGroup) AgeGroup,RTRIM(Person.Company) Company,RTRIM(Category.CategoryName) CategoryName  from Person,Category  where Person.CategoryId=Category.CategoryId order by Person.PersonId  desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void PersonDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string x, y;
                //DataGridViewRow dr = dataGridView1.SelectedRows[0];
                DataGridViewRow dr = dataGridView1.CurrentRow;
                this.Hide();
                frmPersonUpdate frm = new frmPersonUpdate();
                frm.Show();

                frm.CountrycomboBox.Text = dr.Cells[0].Value.ToString();
                frm.txtPersonName.Text = dr.Cells[1].Value.ToString();

                frm.textNickName.Text = dr.Cells[2].Value.ToString();
                frm.txtFatherName.Text = dr.Cells[3].Value.ToString();
                frm.cmbEmailAddress.Text = dr.Cells[4].Value.ToString();

                frm.cmbCompanyName.Text = dr.Cells[5].Value.ToString();
                frm.cmbJobTitle.Text = dr.Cells[6].Value.ToString();
                frm.cmbCategoryName.Text = dr.Cells[7].Value.ToString();


                frm.cmbSpecialization.Text = dr.Cells[8].Value.ToString();

                frm.cmbProfession.Text = dr.Cells[9].Value.ToString();
                frm.cmbEducationalLevel.Text = dr.Cells[10].Value.ToString();
                frm.cmbHighestDegree.Text = dr.Cells[11].Value.ToString();
                frm.cmbAgeGroup.Text = dr.Cells[12].Value.ToString();
                frm.cmbRelationShip.Text = dr.Cells[13].Value.ToString();
                frm.txtWebsite.Text = dr.Cells[14].Value.ToString();
                frm.txtSkypeId.Text = dr.Cells[15].Value.ToString();
                frm.txtWhatsApp.Text = dr.Cells[16].Value.ToString();
                frm.txtImmo.Text = dr.Cells[17].Value.ToString();

                if (dr.Cells[0].Value.Equals("Bangladesh"))
                {
                    frm.txtRAFlatNo.Text = dr.Cells[18].Value.ToString();
                    frm.txtRAHouseNo.Text = dr.Cells[19].Value.ToString();
                    frm.txtRARoadNo.Text = dr.Cells[20].Value.ToString();

                    frm.txtRABlock.Text = dr.Cells[21].Value.ToString();
                    frm.txtRAArea.Text = dr.Cells[22].Value.ToString();
                    frm.txtRAContactNo.Text = dr.Cells[23].Value.ToString();

                    frm.cmbRADivision.Text = dr.Cells[24].Value.ToString();
                    frm.cmbRADistrict.Text = dr.Cells[25].Value.ToString();
                    frm.cmbRAThana.Text = dr.Cells[26].Value.ToString();
                    frm.cmbRAPost.Text = dr.Cells[27].Value.ToString();
                    //frm.txtRAPostCode.Text = dr.Cells[28].Value.ToString();
                    x = frm.txtRAPostCode.Text = dr.Cells[28].Value.ToString();

                    frm.txtWAFlatName.Text = dr.Cells[29].Value.ToString();
                    frm.txtWAHouseName.Text = dr.Cells[30].Value.ToString();
                    frm.txtWARoadNo.Text = dr.Cells[31].Value.ToString();
                    frm.txtWABlock.Text = dr.Cells[32].Value.ToString();
                    frm.txtWAArea.Text = dr.Cells[33].Value.ToString();
                    frm.txtWAContactNo.Text = dr.Cells[34].Value.ToString();

                    frm.cmbWADivision.Text = dr.Cells[35].Value.ToString();
                    frm.cmbWADistrict.Text = dr.Cells[36].Value.ToString();
                    frm.cmbWAThana.Text = dr.Cells[37].Value.ToString();
                    frm.cmbWAPost.Text = dr.Cells[38].Value.ToString();
                    //frm.txtWAPostCode.Text = dr.Cells[39].Value.ToString();
                    y = frm.txtWAPostCode.Text = dr.Cells[39].Value.ToString();

                    if (x == y)
                    {
                        frm.sameAsRACheckBox.Checked = true;
                    }
                    else if (string.IsNullOrEmpty(y))
                    {
                        frm.unKnownCheckBox.Checked = true;
                    }
                    else
                    {

                        frm.unKnownRA.Checked = true;
                    }
                }
                else
                {
                    frm.StreettextBox.Text = dr.Cells[40].Value.ToString();
                    frm.StatetextBox.Text = dr.Cells[41].Value.ToString();
                    frm.PostalCodetextBox.Text = dr.Cells[42].Value.ToString();
                }
            
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
