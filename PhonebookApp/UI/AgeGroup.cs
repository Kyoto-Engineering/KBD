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
    public partial class AgeGroup : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public AgeGroup()
        {
            InitializeComponent();
        }

        private void btnSaveAgeGroup_Click(object sender, EventArgs e)
        {
            if (txtAgeGroup.Text == "")
            {
                MessageBox.Show("Please Enter  Age Group Level ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgeGroup.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AgeGroupLevel from AgeGroup where AgeGroupLevel='" + txtAgeGroup.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Age Group Level  Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAgeGroup.Clear();
                    txtAgeGroup.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into AgeGroup(AgeGroupLevel) values(@d1)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtAgeGroup.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAgeGroup.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgeGroup_Load(object sender, EventArgs e)
        {

        }

        private void AgeGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
            frm.Show();
        }
    }
}
