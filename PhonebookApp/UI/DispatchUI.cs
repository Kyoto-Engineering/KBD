using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhonebookApp.Reports;

namespace PhonebookApp.UI
{
    public partial class DispatchUI : Form
    {
        public DispatchUI()
        {
            InitializeComponent();
        }

        private void BatchCreation_Click(object sender, EventArgs e)
        {
            Batch frmb = new Batch();
            this.Visible = false;
            frmb.ShowDialog();
            this.Visible = true;
        }

        private void InsertPOD_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Pod pod = new Pod();
            pod.ShowDialog();
            this.Visible = true;
        }

        private void batchreportbutton_Click(object sender, EventArgs e)
        {
            ReportByBatch f2 = new ReportByBatch();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
