using BussinessLayer;
using RetailStoreManagment.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailStoreManagment.Products
{
    public partial class ctrlProductwithfilter : UserControl
    {
        private int _ProductID = -1;
        private string _ProductName = string.Empty;
        private clsSupplier _supplier;
        private clsProducts _product;
        private bool _ShowAddProduct;
        public int Product_ID { get { return _ProductID; } }
        public clsProducts Selectedproductinfo { get { return _product; } }
        public bool ShowAddSupplier
        {
            get { return _ShowAddProduct; }
            set { _ShowAddProduct = value; btnaddproduct.Enabled = _ShowAddProduct; }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; groupBox1.Enabled = _FilterEnabled; }
        }
        public ctrlProductwithfilter()
        {
            InitializeComponent();
        }
        private void FinalizeSupplierSelection()
        {
            if (ctrlProductInfo1.Product_ID <= 0)
            {
                _ProductID = -1;
                return;
            }
            _ProductID = ctrlProductInfo1.Product_ID;
            _ProductName = ctrlProductInfo1.ProductName;
        }
        private void FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Name":
                    {
                        if (string.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("Please Write Name To Load Information",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _ProductName = textBox1.Text;
                        ctrlProductInfo1.LoadInfo(_ProductName);
                        FinalizeSupplierSelection();
                        break;
                    }
                case "ID":
                    {
                        if (string.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("Please Write ID To Load Information",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (int.TryParse(textBox1.Text, out _ProductID))
                        {
                            ctrlProductInfo1.LoadInfo(_ProductID);
                            _ProductID = ctrlProductInfo1.Product_ID;
                            FinalizeSupplierSelection();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Product ID");
                            return;
                        }

                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please Name or ID To Load Information",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddorUpdateProduct addorUpdateProduct = new AddorUpdateProduct();
            addorUpdateProduct.DataBack += DataBack;
            addorUpdateProduct.ShowDialog();
        }
        private void DataBack(object sender, int ProductID)
        {
            _ProductID = ProductID;
            textBox1.Text = _ProductID.ToString();
            ctrlProductInfo1.LoadInfo(ProductID);
        }
        public void LoadProduct(int ProductID)
        {
            _ProductID = ProductID;
            textBox1.Text = _ProductID.ToString();
            ctrlProductInfo1.LoadInfo(_ProductID);
        }
        public void LoadProduct(string ProductName)
        {
            _ProductName = ProductName;
            textBox1.Text = _ProductName;
            ctrlProductInfo1.LoadInfo(_ProductName);
            _ProductID = ctrlProductInfo1.Product_ID;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (cbFilterBy.Text == "ID")
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
    }
}
