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
   
    public partial class frmCategory : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string user_id;
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            if (!string.IsNullOrEmpty(categoryName))
            {
                String str = "server=KYOTO-PC12;database=PhonebookDB;user=sa;password=System@kyoto";
                String qry="insert into tblCategory(Categoryname) values('"+ categoryName +"')";
                try
                    {
                        SqlConnection conn = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand(qry, conn);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Added");
                      
                        conn.Close();
                    }


                    catch (Exception)
                    {
                        MessageBox.Show("there was an issue");
                    }

            }
        }

        internal static void show()
        {
            
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Please Enter  Category Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select CategoryName from Category where CategoryName='" + txtCategoryName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Category Name Already Exists in the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Text = "";
                    txtCategoryName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "insert into Category(CategoryName, UserId, DateAndTime) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@d2", user_id);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
             frm.Show();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }

        private void frmCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveCategory_Click(this, new EventArgs());
               
            }
        }
    }
}
