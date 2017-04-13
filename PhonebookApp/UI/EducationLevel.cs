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
    public partial class EducationLevel : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id;
        public EducationLevel()
        {
            InitializeComponent();
        }

        private void btnSaveEducationLevel_Click(object sender, EventArgs e)
        {
            if (txtEducationLevel.Text == "")
            {
                MessageBox.Show("Please Enter  Education Level Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEducationLevel.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select EducationLevelName from EducationLevel where EducationLevelName='" + txtEducationLevel.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Education Level Name Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEducationLevel.Text = "";
                    txtEducationLevel.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into EducationLevel(EducationLevelName, UserId, DateAndTime) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtEducationLevel.Text);
                cmd.Parameters.AddWithValue("@d2", user_id);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               txtEducationLevel.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EducationLevel_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }

        private void EducationLevel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }
    }
}
