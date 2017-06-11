using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhonebookApp.Reports
{
    public partial class ReportByBatch : Form
    {
        public ReportByBatch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getButton.Enabled = false;



            if (!string.IsNullOrWhiteSpace(batchIdCombobox.Text))
            {
                if (PortraitRadioButton.Checked)
                {
                    GetPortrait();
                    Clear();
                }
                else if (LandscapeRadioButton.Checked)
                {
                    GetLandscape();
                    Clear();
                }
                else
                {
                    MessageBox.Show(@"Please Choose an Option");
                }
            }
            else
            {
                MessageBox.Show(@"Please Select a Batch Id");
            }

            getButton.Enabled = true;
        }
    }
}
