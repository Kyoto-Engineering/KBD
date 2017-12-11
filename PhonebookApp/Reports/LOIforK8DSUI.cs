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
    public partial class LOIforK8DSUI : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int GroupId;

        private RadioButton resedentialRadioButton;
        private RadioButton workingRadioButton;
        private Button getButton;
        private Label label1;
        private ComboBox groupComboBox;
    
        public LOIforK8DSUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.resedentialRadioButton = new System.Windows.Forms.RadioButton();
            this.workingRadioButton = new System.Windows.Forms.RadioButton();
            this.getButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // resedentialRadioButton
            // 
            this.resedentialRadioButton.AutoSize = true;
            this.resedentialRadioButton.Location = new System.Drawing.Point(202, 144);
            this.resedentialRadioButton.Name = "resedentialRadioButton";
            this.resedentialRadioButton.Size = new System.Drawing.Size(118, 17);
            this.resedentialRadioButton.TabIndex = 16;
            this.resedentialRadioButton.TabStop = true;
            this.resedentialRadioButton.Text = "Residential Address";
            this.resedentialRadioButton.UseVisualStyleBackColor = true;
            // 
            // workingRadioButton
            // 
            this.workingRadioButton.AutoSize = true;
            this.workingRadioButton.Location = new System.Drawing.Point(202, 118);
            this.workingRadioButton.Name = "workingRadioButton";
            this.workingRadioButton.Size = new System.Drawing.Size(106, 17);
            this.workingRadioButton.TabIndex = 15;
            this.workingRadioButton.TabStop = true;
            this.workingRadioButton.Text = "Working Address";
            this.workingRadioButton.UseVisualStyleBackColor = true;
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(203, 215);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 14;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Group Name";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(143, 77);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(292, 21);
            this.groupComboBox.TabIndex = 12;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged_1);
            // 
            // LOIforK8DSUI
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(504, 314);
            this.Controls.Add(this.resedentialRadioButton);
            this.Controls.Add(this.workingRadioButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupComboBox);
            this.Name = "LOIforK8DSUI";
            this.Load += new System.EventHandler(this.LOIforK8DSUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LOIforK8DSUI_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT GroupName FROM [Group] ORDER BY GroupName";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    groupComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            getButton.Enabled = false;
            if (!string.IsNullOrWhiteSpace(groupComboBox.Text))
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
                MessageBox.Show(@"Please Select a Group");
            }
            getButton.Enabled = true;
        }

        private void Clear()
        {
            groupComboBox.SelectedIndex = -1;
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
            paramDiscreteValue1.Value = GroupId;

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
            LOIforKBDS cr = new LOIforKBDS();
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
            paramDiscreteValue1.Value = GroupId;

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
            LOIforKBDS cr = new LOIforKBDS();
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

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "SELECT GroupId FROM [Group] where GroupName = '" + groupComboBox.Text + "' ";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    if (rdr.Read() == true)
            //    {
            //        GroupId = rdr.GetInt32(0);
            //    }
            //    con.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void groupComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT GroupId FROM [Group] where GroupName = '" + groupComboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    GroupId = rdr.GetInt32(0);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
