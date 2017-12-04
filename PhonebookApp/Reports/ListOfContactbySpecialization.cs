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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PhonebookApp.Reports
{
    public partial class ListOfContactbySpecialization : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int specid;
        public ListOfContactbySpecialization()
        {
            InitializeComponent();
        }

        private void ListOfContactbySpecialization_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT Specialization FROM Specializations ORDER BY SpecializationsId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    speccombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void speccombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(speccombo.Text))
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ctk = "SELECT SpecializationsId FROM Specializations WHERE Specialization = @d1";

                    cmd = new SqlCommand(ctk);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", speccombo.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        specid = (rdr.GetInt32(0));

                    }

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            getButton.Enabled = false;



            if (!string.IsNullOrWhiteSpace(speccombo.Text))
            {
                if (workingRadioButton.Checked)
                {
                    GetWorking();
                    Clear();
                }
                else
                {
                    MessageBox.Show(@"Please Choose an Option");
                }
            }
            else
            {
                MessageBox.Show(@"Please Select a Religion");
            }

            getButton.Enabled = true;
        }

        private void Clear()
        {
            speccombo.SelectedIndex = -1;

            workingRadioButton.Checked = false;
        }

        private void GetWorking()
        {
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = specid;

            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);

            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            ListofAllContactsBySpecialization cr = new ListofAllContactsBySpecialization();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        //public object Database { get; set; }
    }
}
