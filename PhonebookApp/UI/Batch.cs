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
    public partial class Batch : Form
    {
        SqlConnection _con;
        SqlCommand _cmd;
        ConnectionString _cs = new ConnectionString();
        SqlDataReader rdr;
        public string user_id;
        public int Batchid;
        public Batch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     

            if (PersonIdtextBox.Text == "")
            {
                MessageBox.Show("You must Enter Person Id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PersonIdtextBox.Focus();
                return;
            }

            try
            {
                if (listView1.Items.Count == 0)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(PersonIdtextBox.Text);
                   
                    listView1.Items.Add(lst);
                    PersonIdtextBox.Text = "";                  
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add to Chart first", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PersonIdtextBox.Focus();
                return;
            }

            _con = new SqlConnection(_cs.DBConn);
            string cd1 = "INSERT INTO Batch (POD,UserId,BatchTime) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            _cmd = new SqlCommand(cd1, _con);
            //_cmd.Parameters.Add(new SqlParameter("@d1",
            //string.IsNullOrEmpty(PodtextBox.Text) ? (object)DBNull.Value : PodtextBox.Text));
            _cmd.Parameters.AddWithValue("@d2", user_id);
            _cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
            _con.Open();
            Batchid = (int)_cmd.ExecuteScalar();
            _con.Close();
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    _con = new SqlConnection(_cs.DBConn);
                    string cd = "INSERT INTO DetailsOfBatch (BatchID,PersonsId) VALUES (@d1,@d2)";
                    _cmd = new SqlCommand(cd, _con);
                    _cmd.Parameters.AddWithValue("@d1", PersonIdtextBox);
                    _cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[1].Text);
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }              
                MessageBox.Show("Successfully Submitted.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Batch_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
        }
    }
}
