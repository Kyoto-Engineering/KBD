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

namespace PhonebookApp.Reports
{
    public partial class ReportByDistrict : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int districtId; 
        public ReportByDistrict()
        {
            InitializeComponent();
        }

        private void ReportByDistrict_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                divisionComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void divisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            districtComboBox.Items.Clear();
            districtComboBox.ResetText();


            if (!string.IsNullOrWhiteSpace(divisionComboBox.Text)) {try
            {

              con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts inner join Divisions on Districts.Division_ID= Divisions.Division_ID Where Divisions.Division = '" + divisionComboBox.Text + "' order by Districts.District asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    districtComboBox.Items.Add(rdr[0]);
                }
                con.Close();
                districtComboBox.Focus();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }}
           
        }

        private void districtComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(districtComboBox.Text)) {try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT Districts.D_ID FROM Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID WHERE Districts.District = @a AND Divisions.Division = @b";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@a", districtComboBox.Text);
                cmd.Parameters.AddWithValue("@b", divisionComboBox.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtId = Convert.ToInt32(rdr["D_ID"]);

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
