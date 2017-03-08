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
    public partial class frmRelationShip : Form
    {
        private  SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public frmRelationShip()
        {
            InitializeComponent();
        }
  
        private void frmRelationShip_Load(object sender, EventArgs e)
        {
                  
        }

        private void btnSaveRelationship_Click(object sender, EventArgs e)
        {
            if (txtRelationship.Text == "")
            {
                MessageBox.Show("Please Enter  Relationship ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRelationship.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RelationShip from RelationShips where RelationShip='" + txtRelationship.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This RelationShips  Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRelationship.Clear();
                    txtRelationship.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into RelationShips(RelationShip) values(@d1)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtRelationship.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRelationship.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
