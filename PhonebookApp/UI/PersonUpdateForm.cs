using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhonebookApp.UI
{
    public partial class PersonUpdateForm : Form
    {
        public PersonUpdateForm()
        {
            InitializeComponent();
        }

        private void txtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNickName.Focus();
                e.Handled = true;
            }
        }

        private void textNickName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherName.Focus();
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmailAddress.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCompanyName.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbJobTitle.Focus();
                e.Handled = true;
            }
        }

        private void cmbJobTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCategoryName.Focus();
                e.Handled = true;
            }
        }

        private void cmbCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSpecialization.Focus();
                e.Handled = true;
            }
        }

        private void cmbSpecialization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProfession.Focus();
                e.Handled = true;
            }
        }

        private void cmbProfession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEducationalLevel.Focus();
                e.Handled = true;
            }
        }

        private void cmbEducationalLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHighestDegree.Focus();
                e.Handled = true;
            }
        }

        private void cmbHighestDegree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgeGroup.Focus();
                e.Handled = true;
            }
        }

        private void cmbAgeGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRelationship.Focus();
                e.Handled = true;
            }
        }

        private void txtRelationship_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWebsite.Focus();
                e.Handled = true;
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInternetCall.Focus();
                e.Handled = true;
            }
        }

        private void txtInternetCall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAFlatNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAFlatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAHouseNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRARoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRARoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRABlock.Focus();
                e.Handled = true;
            }
        }

        private void txtRABlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAArea.Focus();
                e.Handled = true;
            }
        }

        private void txtRAArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRAContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRAContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRADistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbRADistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRAPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbRAPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtRAPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAFlatName.Focus();
                e.Handled = true;
            }
        }

        private void txtWAFlatName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAHouseName.Focus();
                e.Handled = true;
            }
        }

        private void txtWAHouseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWARoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtWARoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWABlock.Focus();
                e.Handled = true;
            }
        }

        private void txtWABlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAArea.Focus();
                e.Handled = true;
            }
        }

        private void txtWAArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtWAContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWADivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbWADivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWADistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbWADistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWAThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbWAThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWAPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbWAPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWAPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtWAPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnPersonUpdate_click(this, new EventArgs());
        }

        private void cmbEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {


                string emailId = cmbEmailAddress.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbEmailAddress.SelectedIndex = -1;
                    cmbEmailAddress.ResetText();
                    cmbEmailAddress.Focus();

                }
            }
        }

        private void txtRAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtWAContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void btnPersonUpdate_click(object sender, EventArgs e)
        {

        }
    }
}
