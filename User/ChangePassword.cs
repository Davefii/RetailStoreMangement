using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailStoreManagment.User
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            lblusername.Text = clsGlobal.CurrentUser.UserName;
        }

        private void txbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                e.Cancel = true;
                txbPassword.Focus();
                errorProvider1.SetError(txbPassword, "You Must Write Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbPassword, "");
            }
        }

        private void txbConferminPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbConferminPassword.Text))
            {
                e.Cancel = true;
                txbConferminPassword.Focus();
                errorProvider1.SetError(txbConferminPassword, "You Must Write Password");
            }
            if (txbPassword.Text != txbConferminPassword.Text)
            {
                e.Cancel = true;
                txbConferminPassword.Focus();
                errorProvider1.SetError(txbConferminPassword, "You Must Write same Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbConferminPassword, "");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Changepassword(txbConferminPassword.Text))
            {
                MessageBox.Show("Change Password Succeccfuley",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed Change Password Succeccfuley",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txbPassword.UseSystemPasswordChar = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
