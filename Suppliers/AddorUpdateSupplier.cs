using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BussinessLayer.clsSupplier;

namespace RetailStoreManagment.Suppliers
{
    public partial class AddorUpdateSupplier : Form
    {
        public delegate void DataBackEventHandler (object sender, int SupplierID);
        public event DataBackEventHandler DataBack;
        private int _ID = -1;
        clsSupplier supplier;
        public AddorUpdateSupplier()
        {
            LoadDataAddMode();
            InitializeComponent();
        }
        public AddorUpdateSupplier(int ID)
        {

            InitializeComponent();
            _ID = ID;
            LoadDataUpdateMode(_ID);
        }
        private void LoadDataAddMode()
        {
            this.Text = "Add Supplier";
            supplier = new clsSupplier();
        }
        private void LoadDataUpdateMode(int ID)
        {
            this.Text = "Edit Supplier";
            supplier = clsSupplier.GetSupplierByID(ID);
            lblID.Text = supplier.ID.ToString();
            txbSupplierName.Text = supplier.Supplier_Name;
            txdcontactname.Text = supplier.Contact_Person;
            txtbphonenumber.Text = supplier.Phone_Number;
            txtbemail.Text = supplier.Email;
            txtbaddress.Text = supplier.Address;
            if (supplier.Status)
                chkactiveUnactive.Checked = true;
            else
                chkactiveUnactive.Checked = false;
        }
        private void AddorUpdateSupplier_Load(object sender, EventArgs e)
        {
            if (supplier.Mode == clsSupplier.enMode.AddNew)
            {
                LoadDataAddMode();
            }
            else
            {
                LoadDataUpdateMode(_ID);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            supplier.Supplier_Name = txbSupplierName.Text;
            supplier.Contact_Person = txdcontactname.Text.Trim();
            supplier.Phone_Number = txtbphonenumber.Text.Trim();
            supplier.Email = txtbemail.Text.Trim();
            supplier.Address = txtbaddress.Text.Trim();
            if (chkactiveUnactive.Checked)
                supplier.Status = true;
            else
                supplier.Status = false;
            if (supplier.Save())
            {
                MessageBox.Show(
                    "Added Supplier Successfulley",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                _ID = supplier.ID;
                supplier.Mode = clsSupplier.enMode.Update;
                AddorUpdateSupplier_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Failed to Add Supplier",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            DataBack?.Invoke( this, supplier.ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbSupplierName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbSupplierName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbSupplierName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txbSupplierName, null);
            }
        }

        private void txdcontactname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txdcontactname.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txdcontactname, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txdcontactname, null);
            }
        }

        private void txtbphonenumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbphonenumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbphonenumber, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbphonenumber, null);
            }
        }

        private void txtbemail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbemail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbemail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbemail, null);
            }
        }

        private void txtbaddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbaddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbaddress, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbaddress, null);
            }
        }

    }
}
