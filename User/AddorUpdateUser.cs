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
using static BussinessLayer.clsUsers;

namespace RetailStoreManagment.User
{
    public partial class AddorUpdateUser : Form
    {
        private int _UserID = -1;
        private clsUsers _User;
        public AddorUpdateUser()
        {
            InitializeComponent();
        }
        public AddorUpdateUser(int UserID)
        {
            _UserID = UserID;
            InitializeComponent();
        }
        private void LoadDataAddMode()
        {
            _User = new clsUsers();
            this.Text = "Add User";
        }
        private void LoadDataUpdateMode()
        {
            _User = clsUsers.GetUserByID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Cannot Find this User","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            this.Text = "Update User";
            lblID.Text = _User.ID.ToString();
            txbusername.Text = _User.UserName;
            txbPassword.Enabled = false;
            txbconfiminpassword.Enabled = false;
            txbPassword.Text = _User.Password;
            txbconfiminpassword.Text = _User.Password;
            checkBox1.Checked = _User.isActive;
            chkAdmin.Checked = _User.Permitions.HasFlag(clsUsers.enMainMenuPermitions.Admin);
            chkstafforcashier.Checked = _User.Permitions.HasFlag(clsUsers.enMainMenuPermitions.StaffOrCashier);
            chkViewer.Checked = _User.Permitions.HasFlag(clsUsers.enMainMenuPermitions.Admin);
        }

        private void AddorUpdateUser_Load(object sender, EventArgs e)
        {
            if (_UserID != -1)
            {
                LoadDataUpdateMode();
            }
            else
            {
                LoadDataAddMode();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkstafforcashier.Checked = false;
                chkViewer.Checked = false;
                _User.Permitions |= enMainMenuPermitions.Admin; // Add permission
            }
            else
            {
                _User.Permitions &= ~enMainMenuPermitions.Admin; // Remove permission
            }
        }

        private void chkstafforcashier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkstafforcashier.Checked)
            {
                chkAdmin.Checked = false;
                chkViewer.Checked = false;
                _User.Permitions |= enMainMenuPermitions.StaffOrCashier; // Add permission
            }
            else
            {
                _User.Permitions &= ~enMainMenuPermitions.StaffOrCashier; // Remove permission
            }
        }

        private void chkViewer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewer.Checked)
            {
                chkAdmin.Checked = false;
                chkstafforcashier.Checked = false;
                _User.Permitions |= enMainMenuPermitions.Viewer; // Add permission
            }
            else
            {
                _User.Permitions &= ~enMainMenuPermitions.Viewer; // Remove permission
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.UserName = txbusername.Text;
            _User.Password = txbPassword.Text;
            _User.isActive = checkBox1.Checked;
            if (_User.Save())
            {
                MessageBox.Show(
                    "Added User Successfulley",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                _UserID = _User.ID;
                this.Text = "Update User";
                AddorUpdateUser_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Failed to Add User",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txbusername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbusername.Text))
            {
                e.Cancel = true;
                txbPassword.Focus();
                errorProvider1.SetError(txbPassword, "You Must Write Username");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbPassword, "");
            }
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

        private void txbconfiminpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbconfiminpassword.Text))
            {
                e.Cancel = true;
                txbconfiminpassword.Focus();
                errorProvider1.SetError(txbconfiminpassword, "You Must Confermin Password");
            }
            if (txbPassword.Text != txbconfiminpassword.Text)
            {
                e.Cancel = true;
                txbconfiminpassword.Focus();
                errorProvider1.SetError(txbconfiminpassword, "You Must Write same Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbconfiminpassword, "");
            }
        }
    }
}
