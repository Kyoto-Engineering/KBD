using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.DbGateway;

namespace PhonebookApp.UI
{
    public partial class frmPersonUpdate : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string categoryId;

        public frmPersonUpdate()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            //txtFatherName.Text = string.Empty;
            ////txtMobile.Text = string.Empty;
            //txtEmail.Text = string.Empty;
            //txtCompany.Text = string.Empty;
            //cmbCategoryName.Text = string.Empty;
            //cmbSpecialization.Text = string.Empty;
            //cmbProfession.Text = string.Empty;
            //cmbEducationalLevel.Text = string.Empty;
            //cmbHighestDegree.Text = string.Empty;
            //cmbAgeGroup.Text = string.Empty;
            //cmbCategoryName.SelectedIndex = -1;
            //categoryId = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCategoryId();
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Person set PersonName=@d1,Email=@d2,Specialization= @d3,Profession=@d4,EducationalLevel=@d5,HighestDegree=@d6,AgeGroup=@d7,Company=@d8,CategoryId=@d9  Where PersonId='" + txtPersonName.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtFatherName.Text);
                //cmd.Parameters.AddWithValue("@d2", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSpecialization.Text);
                cmd.Parameters.AddWithValue("@d4", cmbProfession.Text);
                cmd.Parameters.AddWithValue("@d5", cmbEducationalLevel.Text);
                cmd.Parameters.AddWithValue("@d6", cmbHighestDegree.Text);
                cmd.Parameters.AddWithValue("@d7", cmbAgeGroup.Text);
                //cmd.Parameters.AddWithValue("@d8", txtCompany.Text);
                cmd.Parameters.AddWithValue("@d9",categoryId);
               
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillWOrderCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Category.CategoryName) from Category  order by Category.CategoryId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCategoryName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPersonUpdate_Load(object sender, EventArgs e)
        {
            FillWOrderCombo();
        }

        private void GetCategoryId()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(CategoryId) from Category  where  Category.CategoryName='" + cmbCategoryName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    categoryId = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
          PersonDetail  frm=new PersonDetail();
                   frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void frmPersonUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbCategoryName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void CountrycomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPersonName.Focus();
                e.Handled = true;
            }
        }

        private void txtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNickName.Focus();
                e.Handled = true;
            }
        }

        private void textNickName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherName.Focus();
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmailAddress.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCompanyName.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbJobTitle.Focus();
                e.Handled = true;
            }
        }

        private void cmbJobTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCategoryName.Focus();
                e.Handled = true;
            }
        }

        private void cmbCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSpecialization.Focus();
                e.Handled = true;
            }
        }

        private void cmbSpecialization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProfession.Focus();
                e.Handled = true;
            }
        }

        private void cmbProfession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEducationalLevel.Focus();
                e.Handled = true;
            }
        }

        private void cmbEducationalLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHighestDegree.Focus();
                e.Handled = true;
            }
        }

        private void cmbHighestDegree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgeGroup.Focus();
                e.Handled = true;
            }
        }

        private void cmbAgeGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRelationShip.Focus();
                e.Handled = true;
            }
        }

        private void cmbRelationShip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWebsite.Focus();
                e.Handled = true;
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSkypeId.Focus();
                e.Handled = true;
            }
        }

        private void txtSkypeId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWhatsApp.Focus();
                e.Handled = true;
            }
        }

        private void txtWhatsApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImmo.Focus();
                e.Handled = true;
            }
        }

        private void txtImmo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAFlatNo.Focus();
                e.Handled = true;
            }
        }

        private void txtWhatsApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtImmo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtRAFlatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAHouseNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRARoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRARoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRABlock.Focus();
                e.Handled = true;
            }
        }

        private void txtRABlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAArea.Focus();
                e.Handled = true;
            }
        }

        private void txtRAArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtRAPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAFlatName.Focus();
                e.Handled = true;
            }
        }

        private void txtWAFlatName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAHouseName.Focus();
                e.Handled = true;
            }
        }

        private void txtWAHouseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWARoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtWARoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWABlock.Focus();
                e.Handled = true;
            }
        }

        private void txtWABlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAArea.Focus();
                e.Handled = true;
            }
        }

        private void txtWAArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtWAContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWADivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbWADivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWADistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbWADistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWAThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbWAThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWAPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbWAPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtWAPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StreettextBox.Focus();
                e.Handled = true;
            }
        }

        private void StreettextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StatetextBox.Focus();
                e.Handled = true;
            }
        }

        private void StatetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PostalCodetextBox.Focus();
                e.Handled = true;
            }
        }

        private void PostalCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Updatebutton_Click(this, new EventArgs());
            }
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {

        }

        private void txtWAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtRAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void cmbEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {


                string emailId = cmbEmailAddress.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbEmailAddress.SelectedIndex = -1;
                    cmbEmailAddress.ResetText();
                    cmbEmailAddress.Focus();

                }
            }
        }
    }
}
