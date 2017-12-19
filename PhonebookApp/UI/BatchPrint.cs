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
using PhonebookApp.Reports;

namespace PhonebookApp.UI
{
    public partial class BatchPrint : Form
    {
        public BatchPrint()
        {
            InitializeComponent();
        }

        private void batchlist_Click(object sender, EventArgs e)
        {
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
            BatchReportnCopy cr = new BatchReportnCopy();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void statusPrint_Click(object sender, EventArgs e)
        {
            ReportByBatch f2 = new ReportByBatch();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void BatchPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
