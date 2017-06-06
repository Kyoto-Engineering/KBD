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
using PhonebookApp.Models;

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
        public Nullable<Int64> dispatchid;
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
                _con = new SqlConnection(_cs.DBConn);
                _con.Open();
                string ct = "select PersonName from Persons  where  Persons.PersonsId='" + PersonIdtextBox.Text + "' ";
                _cmd = new SqlCommand(ct);
                _cmd.Connection = _con;
                rdr = _cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.SubItems.Add(PersonIdtextBox.Text);
                        lst.SubItems.Add(rdr.GetString(0));

                        listView1.Items.Add(lst);
                        PersonIdtextBox.Text = "";
                        PodwaterMarkTextBox.Enabled = false;
                        return;
                    }
                    String Val = PersonIdtextBox.Text;

                    if (listView1.FindItemWithText(Val) == null)
                    {
                        ListViewItem lst1 = new ListViewItem();
                        lst1.SubItems.Add(PersonIdtextBox.Text);
                        lst1.SubItems.Add(rdr.GetString(0));
                        listView1.Items.Add(lst1);
                        PersonIdtextBox.Text = "";

                        return;
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Add Same Person Id More than one times", "error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("This is not a vilid Person Id", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _cmd.Parameters.Add(new SqlParameter("@d1",
            string.IsNullOrEmpty(PodwaterMarkTextBox.Text) ? (object)DBNull.Value : PodwaterMarkTextBox.Text));
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
                    _cmd.Parameters.AddWithValue("@d1", Batchid);
                    _cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[1].Text);
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }              
                MessageBox.Show("Successfully Submitted.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
                PodwaterMarkTextBox.Enabled = true;
                PodwaterMarkTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FillDispatch()
        {
            try
            {
                _con = new SqlConnection(_cs.DBConn);
                _con.Open();
                string ctt = "select DispatchBy from Dispatch";
                _cmd = new SqlCommand(ctt);
                _cmd.Connection = _con;
                rdr = _cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbDispatchBy.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbDispatchBy.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Batch_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            FillDispatch();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please Select a row from the list which you  want to remove", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }
        }

        private void cmbDispatchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDispatchBy.Text == "Not In The List")
            {
                
                string inputj = null;
                InputBox.Show("Please Input Dispatch By Here", "Inpute Here", ref inputj);
                if (string.IsNullOrWhiteSpace(inputj))
                {
                    cmbDispatchBy.SelectedIndex = -1;
                }

                else
                {
                    _con = new SqlConnection(_cs.DBConn);
                    _con.Open();
                    string ct2 = "select DispatchBy from Dispatch where DispatchBy='" + inputj + "'";
                    _cmd = new SqlCommand(ct2, _con);
                    rdr = _cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Dispatch By  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _con.Close();
                        cmbDispatchBy.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            _con = new SqlConnection(_cs.DBConn);
                            _con.Open();
                            string query1 = "insert into Dispatch(DispatchBy,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            _cmd = new SqlCommand(query1, _con);
                            _cmd.Parameters.AddWithValue("@d1", inputj);
                            _cmd.Parameters.AddWithValue("@d2", user_id);
                            _cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            _cmd.ExecuteNonQuery();
                            _con.Close();
                            cmbDispatchBy.Items.Clear();
                            FillDispatch();
                            cmbDispatchBy.SelectedText = inputj;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {

                    _con = new SqlConnection(_cs.DBConn);
                    _con.Open();
                    string ct = "select DispatchId from Dispatch  where  Dispatch.DispatchBy='" + cmbDispatchBy.Text + "' ";
                    _cmd = new SqlCommand(ct);
                    _cmd.Connection = _con;
                    rdr = _cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        dispatchid = Convert.ToInt64(rdr["DispatchId"]);
                    }
                    _con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
