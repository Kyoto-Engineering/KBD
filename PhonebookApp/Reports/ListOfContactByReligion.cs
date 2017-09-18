using PhonebookApp.DbGateway;
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

namespace PhonebookApp.Reports
{
    public partial class ListOfContactByReligion : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int relid;
        public ListOfContactByReligion()
        {
            InitializeComponent();
        }

        private void ListOfContactByReligion_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT ReligionName FROM Religion ORDER BY ReligionId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    religionComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void religionComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(religionComboBox.Text))
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ctk = "SELECT ReligionId FROM Religion WHERE ReligionName = @d1";

                    cmd = new SqlCommand(ctk);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", religionComboBox.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        relid = Convert.ToInt32(rdr["ReligionId"]);

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
                }
            }
        }

        
    }
}
