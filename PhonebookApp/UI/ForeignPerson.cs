using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;
using PhonebookApp.Models;
using PhonebookApp.UI;
using QRCoder;




namespace PhonebookApp.UI
{

    
    public partial class ForeignPerson : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string companyId = null;
        public string rAdistrictid, countryid, nUserId, postofficeIdWA, postofficeIdRA, divisionIdWA, divisionIdRA, districtIdRA, districtIdWA, thanaIdRA, thanaIdWA;
        public Nullable<Int64> groupid, relationshipId, bankEmailId, categoryId, jobTitleId, specializationId, professionId, ageGroupId, educationLevelId, highestDegreeId, religionId, genderId, maritalStatusId;
        public int currentPersonId, affectedRows1, affectedRows2, affectedRows3, wAdistrictid;
        private delegate void ChangeFocusDelegate(Control ctl);
        public ForeignPerson()
        {
            InitializeComponent();
        }

        private void GendercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select GenderId from Gender  where  Gender.GenderName='" + GendercomboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    genderId = Convert.ToInt64(rdr["GenderId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillReligion()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Religion.ReligionName) from Religion  order by Religion.ReligionId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ReligioncomboBox.Items.Add(rdr[0]);
                }
                ReligioncomboBox.Items.Add("Not In The List");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReligioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReligioncomboBox.Text == "Not In The List")
            {
                //string inputReligion = Microsoft.VisualBasic.Interaction.InputBox("Please Input Religion  Here", "Input Here", "", -1, -1);
                string inputReligion = null;
                InputBox.Show("Please Input Religion Here", "Inpute Here", ref inputReligion);
                if (string.IsNullOrWhiteSpace(inputReligion))
                {
                    ReligioncomboBox.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select ReligionName from Religion where ReligionName='" + inputReligion + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Religion Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        ReligioncomboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Religion (ReligionName,UserId) values (@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", inputReligion);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.ExecuteNonQuery();

                            con.Close();
                            ReligioncomboBox.Items.Clear();
                            FillReligion();
                            ReligioncomboBox.SelectedText = inputReligion;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select ReligionId from Religion  where  Religion.ReligionName='" + ReligioncomboBox.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        religionId = Convert.ToInt64(rdr["ReligionId"]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void maritalStatuscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select GenderId from Gender  where  Gender.GenderName='" + GendercomboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    genderId = Convert.ToInt64(rdr["GenderId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForeignSaveClick(object sender, EventArgs e)
        {

        }

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png;*.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;

                openFileDialog1.FileName = "";
                //if (Image.FromFile(openFileDialog1.FileName).Height != 300)
                //{
                //    MessageBox.Show("Height Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Image.FromFile(openFileDialog1.FileName).Height != 300)
                    {
                        MessageBox.Show("Height Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Image.FromFile(openFileDialog1.FileName).Width != 300)
                    {
                        MessageBox.Show("Width Must Be 300 Pixel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //if (ValidFile(openFileDialog1.FileName, 300, 2176))
                        //{

                        userPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                        //pictureBrowseButton.Focus();
                    }
                    //else
                    //{
                    //    MessageBox.Show("Image Size is invalid");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new EmailSelectionGrid())
            {
                this.Visible = false;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bankEmailId = Convert.ToInt32(form.ReturnValue1);            //values preserved after close
                    string val = form.ReturnValue2;

                    //Do something here with these values

                    //for example
                    this.textBoxEmailForeign.Text = val;

                }
                this.Visible = true;
            }
        }

        private void CompanySelectionbutton_Click(object sender, EventArgs e)
        {
            using (var form = new CompanySelectionGrid())
            {
                this.Visible = false;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close
                    companyId = form.ReturnValue2;

                    //Do something here with these values

                    //for example
                    this.companyNametextBox.Text = val;
                    SqlConnection con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 =
                        "SELECT Company.CompanyName, CompanyForeignAddress.FApartmentC, CompanyForeignAddress.FStreetC, CompanyForeignAddress.FCityC, CompanyForeignAddress.FZipcode,CompanyForeignAddress.FNearestlandmark      FROM Company INNER JOIN CompanyForeignAddress ON Company.CompanyId = CompanyForeignAddress.CompanyId where Company.CompanyId='" +
                        companyId + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        this.textBox2.Text = rdr["Branch"].ToString();
                        
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
                this.Visible = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
