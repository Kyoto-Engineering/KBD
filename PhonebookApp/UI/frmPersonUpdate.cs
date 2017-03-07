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
            txtPersonName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompany.Text = string.Empty;
            cmbCategoryName.Text = string.Empty;
            cmbSpecialization.Text = string.Empty;
            cmbProfession.Text = string.Empty;
            cmbEducationalLevel.Text = string.Empty;
            cmbHighestDegree.Text = string.Empty;
            cmbAgeGroup.Text = string.Empty;
            cmbCategoryName.SelectedIndex = -1;
            categoryId = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCategoryId();
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Person set PersonName=@d1,Email=@d2,Specialization= @d3,Profession=@d4,EducationalLevel=@d5,HighestDegree=@d6,AgeGroup=@d7,Company=@d8,CategoryId=@d9  Where PersonId='" + txtPersonId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtPersonName.Text);
                cmd.Parameters.AddWithValue("@d2", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSpecialization.Text);
                cmd.Parameters.AddWithValue("@d4", cmbProfession.Text);
                cmd.Parameters.AddWithValue("@d5", cmbEducationalLevel.Text);
                cmd.Parameters.AddWithValue("@d6", cmbHighestDegree.Text);
                cmd.Parameters.AddWithValue("@d7", cmbAgeGroup.Text);
                cmd.Parameters.AddWithValue("@d8", txtCompany.Text);
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
    }
}
