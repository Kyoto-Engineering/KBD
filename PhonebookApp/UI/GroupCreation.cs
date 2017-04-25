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
    public partial class GroupCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string user_id;

        public GroupCreation()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(groupNametextBox.Text))
            {
                MessageBox.Show("Please enter Group Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupNametextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(definitionrichTextBox.Text))
            {
                MessageBox.Show("Please enter Definition", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                definitionrichTextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(purposetextBox.Text))
            {
                MessageBox.Show("Please enter Purpose", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                purposetextBox.Focus();
            }

            else
            {


                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select GroupName from [dbo].[Group] where GroupName='" + groupNametextBox.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("This Group Name Already Exists in the List", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        groupNametextBox.Clear();

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query =
                            "insert into [dbo].[Group] (GroupName,Definition,Purpose, UserId, DateAndTime) values(@d1,@d2,@d3,@d4,@d5)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@d1", groupNametextBox.Text);
                        cmd.Parameters.AddWithValue("@d2", definitionrichTextBox.Text);
                        cmd.Parameters.AddWithValue("@d3", purposetextBox.Text);
                        cmd.Parameters.AddWithValue("@d4", user_id);
                        cmd.Parameters.AddWithValue("@d5", DateTime.UtcNow.ToLocalTime());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Clear();
                    }

              
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Clear()
        {
            groupNametextBox.Clear();
            definitionrichTextBox.Clear();
            purposetextBox.Clear();

        }

        private void GroupCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frmm = new MainUI();
            frmm.Show();
        }

        private void GroupCreation_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }

        private void groupNametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                definitionrichTextBox.Focus();
                e.Handled = true;
            }
        }

        private void definitionrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                purposetextBox.Focus();
                e.Handled = true;
            }
        }

        private void purposetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                savebutton_Click(this, new EventArgs());
        }
    }
}
