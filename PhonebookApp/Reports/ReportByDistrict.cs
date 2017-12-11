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
using PhonebookApp.DbGateway;

namespace PhonebookApp.Reports
{
    public partial class ReportByDistrict : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int districtId; 
        public ReportByDistrict()
        {
            InitializeComponent();
        }

        private void ReportByDistrict_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division asc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                divisionComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void divisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            districtComboBox.Items.Clear();
            districtComboBox.ResetText();


            if (!string.IsNullOrWhiteSpace(divisionComboBox.Text)) {try
            {

              con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts inner join Divisions on Districts.Division_ID= Divisions.Division_ID Where Divisions.Division = '" + divisionComboBox.Text + "' order by Districts.District asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    districtComboBox.Items.Add(rdr[0]);
                }
                con.Close();
                districtComboBox.Focus();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }}
           
        }

        private void districtComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(districtComboBox.Text)) {try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT Districts.D_ID FROM Districts INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID WHERE Districts.District = @a AND Divisions.Division = @b";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@a", districtComboBox.Text);
                cmd.Parameters.AddWithValue("@b", divisionComboBox.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtId = Convert.ToInt32(rdr["D_ID"]);

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
            }}
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            getButton.Enabled = false;
            if (!string.IsNullOrWhiteSpace(divisionComboBox.Text))
            {


                if (!string.IsNullOrWhiteSpace(districtComboBox.Text))
                {
                    if (resedentialRadioButton.Checked)
                    {
                        GetResidential();
                        Clear();
                    }
                    else if (workingRadioButton.Checked)
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
                    MessageBox.Show(@"Please Select a District");
                }
            }
            else
            {
                MessageBox.Show(@"Please Select a Division");
            }
            getButton.Enabled = true;
        }

        private void Clear()
        {
            districtComboBox.SelectedIndex = -1;
            divisionComboBox.SelectedIndex = -1;
            resedentialRadioButton.Checked = false;
            workingRadioButton.Checked = false;
        }

        private void GetResidential()
        {
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = districtId;

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
            with1.DatabaseName = "PhoneBookDBKD22_try_Spe";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            EidGreetingsForResidentialAddDist cr = new EidGreetingsForResidentialAddDist();
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
            paramDiscreteValue1.Value = districtId;

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
            with1.DatabaseName = "PhoneBookDBKD22_try_Spe";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            EidGreetingsForWorkingAddDist cr = new EidGreetingsForWorkingAddDist();
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
    }
    }

