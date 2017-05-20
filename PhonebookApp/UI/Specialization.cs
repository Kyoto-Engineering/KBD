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
    public partial class Specialization : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id;
        public Specialization()
        {
            InitializeComponent();
        }

        private void btnSaveSpecialization_Click(object sender, EventArgs e)
        {
            if (txtSpecialization.Text == "")
            {
                MessageBox.Show("Please Enter  Specialization Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSpecialization.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Specialization from Specializations where Specialization='" + txtSpecialization.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Specializations Name Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSpecialization.Clear();
                    txtSpecialization.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into Specializations(Specialization, UserId, DateAndTime) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtSpecialization.Text);
                cmd.Parameters.AddWithValue("@d2", user_id);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               txtSpecialization.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Specialization_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmManageGroups frm = new frmManageGroups();
            frm.Show();
        }

        private void Specialization_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }

        private void txtSpecialization_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnSaveSpecialization_Click(this, new EventArgs());
        }
    }
}
