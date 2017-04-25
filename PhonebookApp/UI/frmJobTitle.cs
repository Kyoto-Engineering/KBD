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
    public partial class frmJobTitle : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id;
        public frmJobTitle()
        {
            InitializeComponent();
        }

        private void btnSaveJobTitle_Click(object sender, EventArgs e)
        {
            if (txtJobTitle.Text == "")
            {
                MessageBox.Show("Please Enter  Designation or Job Title", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJobTitle.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select JobTitleName from JobTitle where JobTitleName='" + txtJobTitle.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This JobTitle/Designation Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtJobTitle.Text = "";
                    txtJobTitle.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into JobTitle(JobTitleName, UserId, DateAndTime) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@d2", user_id);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobTitle.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmJobTitle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
            frm.Show();
        }

        private void frmJobTitle_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }

        private void txtJobTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveJobTitle_Click(this, new EventArgs());
              
            }
        }
    }
}
