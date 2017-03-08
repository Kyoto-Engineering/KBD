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
using PhonebookApp.DAL;
using PhonebookApp.DbGateway;
using PhonebookApp.Manager;

namespace PhonebookApp.LogInUI
{
    public partial class frmRegistration : Form
    {
        SqlConnection con;
        SqlDataReader rdr;
        SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
                return;
            }
            if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Please Type Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return;
            }
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Please Type your Full Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }
            if (designationTextBox.Text == "")
            {
                MessageBox.Show("Please Type your designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                designationTextBox.Focus();
                return;
            }
            if (departmentTextBox.Text == "")
            {
                MessageBox.Show("Please Type your Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentTextBox.Focus();
                return;
            }
            int us = 0;
            UserManager aManager = new UserManager();
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Username from Registration where Username='" + userNameTextBox.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This User Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    userNameTextBox.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                User nUser = new User
                {
                    UserName = userNameTextBox.Text,
                    Password = passwordTextBox.Text,
                    UserType = txtUserComboBox.Text,
                    Name = nameTextBox.Text,
                    Email = emailTextBox.Text,
                    Designation = designationTextBox.Text,
                    Department = departmentTextBox.Text,
                    ContactNo = contactNoTextBox.Text

                };
                us = aManager.SaveUser(nUser);
                MessageBox.Show("Successfully  User Created.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                userButton.Enabled = false;
                Reset();

                frmLogin lg = new frmLogin();
                this.Visible = false;
                lg.ShowDialog();
                this.Visible = true;
            }
            catch (FormatException formatException)
            {
                MessageBox.Show("Please Enter Input in Correct Format", formatException.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void Reset()
        {
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
            txtUserComboBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            designationTextBox.Text = "";
            departmentTextBox.Text = "";
            contactNoTextBox.Text = "";
            userButton.Enabled = true;
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
         
        }
    }
}
