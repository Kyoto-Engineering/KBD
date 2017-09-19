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
        SqlConnection con;
        SqlCommand cmd;
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
            batchldgrd();

        }

        private void batchldgrd()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qgl = "select BatchId, BatchTime from Batch ";
                cmd = new SqlCommand(qgl, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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
            string q3 = "select DetailsOfBatch.PersonsId, Persons.PersonName, vwFullAddress.CompanyName, vwFullAddress.CDistrict, DetailsOfBatch.POD, Batch.BatchId, Batch.BatchTime FROM  DetailsOfBatch INNER JOIN Persons ON DetailsOfBatch.PersonsId = Persons.PersonsId RIGHT OUTER JOIN Batch ON DetailsOfBatch.BatchId = Batch.BatchId INNER JOIN vwFullAddress ON DetailsOfBatch.PersonsId = vwFullAddress.PersonsId   where DetailsOfBatch.BatchId = '" + batchid + "' order by DetailsOfBatch.PersonsId asc  ";
            cmd = new SqlCommand(q3, con);
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataGridView1.Rows.Clear();
            
            while (rdr.Read() == true)
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3] ,rdr[4], rdr[5], rdr[6]);
            
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

                    recpidtxt.Text = dr.Cells[0].Value.ToString();
                    rcpnamtxt.Text = dr.Cells[1].Value.ToString();
                    comtext.Text = dr.Cells[2].Value.ToString();
                    dtext.Text = dr.Cells[3].Value.ToString();
                    batnotxt.Text = dr.Cells[5].Value.ToString();
                    podtxt.Text = dr.Cells[4].Value.ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
        }


       
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(podtxt.Text))
                {
                    MessageBox.Show("Select POD");
                }
            else if (string.IsNullOrEmpty(rcpnamtxt.Text))
            {
                MessageBox.Show("Select POD");
            }
            else if (string.IsNullOrEmpty(recpidtxt.Text))
            {
                MessageBox.Show("Select POD");
            }

            else 
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string querydone = "update DetailsOfBatch set POD = '" + podtxt.Text + "' where BatchId = '" + batchid + "' AND PersonsId = '" + personiddd + "' ";
                cmd = new SqlCommand(querydone, con);
                cmd.ExecuteScalar();
                con.Close();

                MessageBox.Show("POD Taken");
                  dataGridView1.Rows.Clear();
                  dataGridView1.Refresh();
                gridld();
                recpidtxt.Clear();
                rcpnamtxt.Clear();
                podtxt.Clear();
                batnotxt.Clear();
            
            }
        }

       


    }
}
