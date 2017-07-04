using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.DbGateway;
using PhonebookApp.LogInUI;

namespace PhonebookApp.UI
{
    public partial class EmailSelectionGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }

        public EmailSelectionGrid()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Dispose();
                this.ReturnValue1 = Convert.ToInt32(dr.Cells[0].Value.ToString());
                this.ReturnValue2 = dr.Cells[1].Value.ToString(); //example
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmailSelectionGrid_Load(object sender, EventArgs e)
        {
            LoadEmails();
        }

        private void LoadEmails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT EmailBankId, Email FROM EmailBank order by Email asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void companyNameSearchtextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(companyNameSearchtextBox.Text))
            {
                SearchEmail(companyNameSearchtextBox.Text);
            }
            else
            {
                dataGridView1.Rows.Clear();
                LoadEmails();
            }
        }

        private void SearchEmail( string text)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT EmailBankId, Email FROM EmailBank where Email like '" +
                                  text + "%' order by Email asc";
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string emailId = textBox1.Text.Trim();
                Regex mRegxExpression;

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type your  valid email Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

           

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Email from EmailBank where Email='" + textBox1.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Email  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    con.Close();
                    dataGridView1.Focus();
                }
                else
                {
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query1 = "insert into EmailBank (Email,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(query1, con);
                        cmd.Parameters.AddWithValue("@d1", textBox1.Text);
                        cmd.Parameters.AddWithValue("@d2", frmLogin.uId.ToString());
                        cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                       this.ReturnValue1 = (int)cmd.ExecuteScalar();
                        con.Close();
                        //this.Dispose();
                        this.ReturnValue2 = textBox1.Text; //example
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                       

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SearchEmail(textBox1.Text);
            }
            else
            {
                dataGridView1.Rows.Clear();
                LoadEmails();
            }
        }
    
        }
    }

