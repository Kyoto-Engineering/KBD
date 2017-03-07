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
using PhonebookApp.UI;

namespace PhonebookApp.LogInUI
{
    public partial class frmLogin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public static int uId;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1UserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1UserName.Focus();
                return;
            }
            if (txt1Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1Password.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs.DBConn);

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT Username,password FROM Registration WHERE Username = @username AND Password = @UserPassword", myConnection);
                SqlParameter uName = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                uName.Value = txt1UserName.Text;
                uPassword.Value = txt1Password.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select usertype,UserId from Registration where Username='" + txt1UserName.Text + "'and Password='" + txt1Password.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtUserType.Text = (rdr.GetString(0));
                        uId = (rdr.GetInt32(1));

                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }

                    if (txtUserType.Text.Trim() == "Admin")
                    {

                        this.Hide();
                        MainUI frm = new MainUI();
                        frm.Show();

                        
                       

                    }
                    //if (txtUserType.Text.Trim() == "User")
                    //{
                    //    MasterPageOnlyforClient frm = new MasterPageOnlyforClient();
                    //    this.Visible = false;
                    //    frm.ShowDialog();
                    //    this.Visible = true;

                    //}

                }


                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt1UserName.Clear();
                    txt1Password.Clear();
                    txt1UserName.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
