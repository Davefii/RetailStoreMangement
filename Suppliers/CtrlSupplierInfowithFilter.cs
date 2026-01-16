using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailStoreManagment.Suppliers
{
    public partial class CtrlSupplierInfowithFilter : UserControl
    {
        private int _SupplierID = -1;
        private string _SupplierName = string.Empty;
        private clsSupplier _supplier;
        private clsProducts _product;
        public int Supplier_ID { get { return _SupplierID; } }
        public clsSupplier SelectedSupplierInfo { get { return _supplier; } }
        public clsProducts Selectedproductinfo { get { return _product; } }
        private bool _ShowAddSupplier = true;
        public bool ShowAddSupplier
        {
            get { return _ShowAddSupplier; }
            set { _ShowAddSupplier = value; btnaddnewsupplier.Enabled = _ShowAddSupplier; }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; groupBox1.Enabled = _FilterEnabled; }
        }
        // Define a custom event handler delegate with parameters
        public event Action<int> OnSupplierSelected;
        // Create a protected method to raise the event with a Parameter
        protected virtual void SupplierSelected(int SupplierID)
        {
            Action<int> handler = OnSupplierSelected;
            if (handler != null)
            {
                handler(SupplierID);
            }
        }
        public CtrlSupplierInfowithFilter()
        {
            InitializeComponent();
        }
        private void FinalizeSupplierSelection()
        {
            if (supplierInfo1.Supplier_ID <= 0)
            {
                _SupplierID = -1;
                return;
            }
            _SupplierID = supplierInfo1.Supplier_ID;
            _SupplierName = supplierInfo1.SelectedSupplierInfo.Supplier_Name; // only if exists
            OnSupplierSelected?.Invoke(_SupplierID);
        }
        private void FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Name":
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Please Write Name To Load Information",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _SupplierName = textBox1.Text;
                    supplierInfo1.LoadData(_SupplierName);
                    FinalizeSupplierSelection();
                    break;

                case "ID":
                    if(string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Please Write ID To Load Information",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (int.TryParse(textBox1.Text, out _SupplierID))
                    {
                        supplierInfo1.LoadData(_SupplierID);
                        _SupplierID = supplierInfo1.Supplier_ID;
                        FinalizeSupplierSelection();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Supplier ID");
                        return;
                    }

                    break;

                default:
                    MessageBox.Show("Please Select Name or ID To Load Information","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddorUpdateSupplier addorUpdateSupplier = new AddorUpdateSupplier();
            addorUpdateSupplier.DataBack += DataBackEvent;
            addorUpdateSupplier.ShowDialog();
        }

        private void DataBackEvent(object sender, int SupplierID)
        {
            _SupplierID = SupplierID;
            textBox1.Text = _SupplierID.ToString();
            supplierInfo1.LoadData(_SupplierID);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (e.KeyChar == (char)13)
                {
                    btnsearch.PerformClick();
                }
                // Allow only digits and control keys (like Backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;// Ignore the key press
                }
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    btnsearch.PerformClick();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindNow();
        }
        public void LoadData(int ID)
        {
            _SupplierID = ID;
            supplierInfo1.LoadData(ID);
            textBox1.Text = ID.ToString();
            cbFilterBy.SelectedIndex = 1;
            FinalizeSupplierSelection();
        }
        public void LoadData(string SupplierName)
        {
            _SupplierName = SupplierName;
            supplierInfo1.LoadData(_SupplierName);
            _SupplierID = supplierInfo1.Supplier_ID;
            textBox1.Text = _SupplierName;
            cbFilterBy.SelectedIndex = 0;
            FinalizeSupplierSelection();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
