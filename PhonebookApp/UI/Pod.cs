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


namespace PhonebookApp.UI
{
    public partial class Pod : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public int batchid;
        public int personid;
        public bool batchidselected;
        public int personiddd;
        public Pod()
        {
            InitializeComponent();
        }

        private void pod_Load(object sender, EventArgs e)
        {
            getbatch();

        }

        private void getbatch()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string q1 = "select BatchId from Batch";
                cmd = new SqlCommand(q1, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   batchcombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridld()
        {
            try {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string q3 = "select DetailsOfBatch.PersonsId, Persons.PersonName, DetailsOfBatch.POD, Batch.BatchId, Batch.BatchTime FROM  DetailsOfBatch INNER JOIN Persons ON DetailsOfBatch.PersonsId = Persons.PersonsId RIGHT OUTER JOIN Batch ON DetailsOfBatch.BatchId = Batch.BatchId where DetailsOfBatch.BatchId = '" + batchid + "' order by DetailsOfBatch.PersonsId asc  ";
            cmd = new SqlCommand(q3, con);
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataGridView1.Rows.Clear();
            
            while (rdr.Read() == true)
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
            
            }
                 }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (batchcombo.SelectedIndex != -1)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string q2 = "select BatchId from Batch where BatchId = '" + batchcombo.Text + "' ";
                cmd = new SqlCommand(q2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    batchid = (rdr.GetInt32(0)) ;
                    batchidselected = true;
                    gridld();
                }
                con.Close();

                //gridld();
            
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                try 
                {
                    DataGridViewRow dr = dataGridView1.CurrentRow;
                    personiddd = Convert.ToInt32(dr.Cells[0].Value.ToString().Trim());

                    textBox1.Text = dr.Cells[0].Value.ToString();
                    textBox2.Text = dr.Cells[1].Value.ToString();
                    textBox4.Text = dr.Cells[3].Value.ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
        }


       
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Select POD");
                }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Select POD");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Select POD");
            }

            else 
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string querydone = "update DetailsOfBatch set POD = '" + textBox3.Text + "' where BatchId = '" + batchid + "' AND PersonsId = '" + personiddd + "' ";
                cmd = new SqlCommand(querydone, con);
                cmd.ExecuteScalar();
                con.Close();

                MessageBox.Show("POD Taken");
                  dataGridView1.Rows.Clear();
                  dataGridView1.Refresh();
                gridld();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            
            }
        }

       


    }
}
