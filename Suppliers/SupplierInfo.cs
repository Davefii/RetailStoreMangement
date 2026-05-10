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

namespace RetailStoreManagment.Suppliers
{
    public partial class SupplierInfo : UserControl
    {
        private int _ID = -1;
        private string _SupplierName = string.Empty;
        private Supplier _supplier;
        public int Supplier_ID { get { return _ID; } }
        public Supplier SelectedSupplierInfo { get { return _supplier; }  }
        public SupplierInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int SupplierID)
        {
            _ID = SupplierID;
            _supplier = Supplier.GetSupplierByID(_ID);
            if (_supplier == null)
            {
                MessageBox.Show("Supplier Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = _ID.ToString();
            lblsuppliername.Text = _supplier.Supplier_Name;
            lblcontactperson.Text = _supplier.Contact_Person;
            lblphonenumber.Text = _supplier.Phone_Number;
            lblemail.Text = _supplier.Email;
            lbladdress.Text = _supplier.Address;
            lblstatus.Text = _supplier.Status ? "Active" : "Not Active";
        }
        public void LoadData(string SupplierName)
        {
            _SupplierName = SupplierName;
            _supplier = Supplier.GetSupplierByName(_SupplierName);
            if (_supplier == null)
            {
                MessageBox.Show("Supplier Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ID = _supplier.ID;
            lblID.Text = _supplier.ID.ToString();
            lblsuppliername.Text = _supplier.Supplier_Name;
            lblcontactperson.Text = _supplier.Contact_Person;
            lblphonenumber.Text = _supplier.Phone_Number;
            lblemail.Text = _supplier.Email;
            lbladdress.Text = _supplier.Address;
            lblstatus.Text = _supplier.Status ? "Active" : "Not Active";
        }
    }
}
