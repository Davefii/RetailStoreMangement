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

namespace RetailStoreManagment.Products
{
    public partial class AddorUpdateProduct : Form
    {
        public delegate void DataBackEventHandler(object sender, int ProductID);
        public event DataBackEventHandler DataBack;
        private int _ID = -1;
        private clsProducts _product;
        public AddorUpdateProduct()
        {
            InitializeComponent();
        }
        public AddorUpdateProduct(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }
        private void LoadDataAddMode()
        {
            this.Text = "Add Product";
            _product = new clsProducts();
            ctrlSupplierInfowithFilter1.ShowAddSupplier = true;
            tabPage2.Enabled = false;
        }
        private void LoadDataUpdateMode()
        {
            this.Text = "Update Product";
            _product = clsProducts.GetProductByID(_ID);
            lblID.Text = _product.ID.ToString();
            ctrlSupplierInfowithFilter1.ShowAddSupplier = false;
            ctrlSupplierInfowithFilter1.LoadData(_product.Supplier_ID);
            txtproductname.Text = _product.Name;
            txtquantity.Text = _product.Quantity.ToString();
            txtprice.Text = _product.price.ToString();
        }
        private void AddorUpdateProduct_Load(object sender, EventArgs e)
        {
            if (_ID != -1)
                LoadDataUpdateMode();
            else
                LoadDataAddMode();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabPage2.Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
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
            if (ctrlSupplierInfowithFilter1.Supplier_ID == 0 || ctrlSupplierInfowithFilter1.Supplier_ID == -1)
            {
                MessageBox.Show("Please Ensure add or Select Supplier ID",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _product.Supplier_ID = ctrlSupplierInfowithFilter1.Supplier_ID;
            _product.Name = txtproductname.Text.Trim();
            _product.price = Convert.ToInt32(txtprice.Text.Trim());
            _product.Quantity = Convert.ToInt32(txtquantity.Text.Trim());
            if (_product.Save())
            {
                MessageBox.Show(
                   "Added Product Successfulley",
                   "Success",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
                lblID.Text = _product.ID.ToString();
                this.Text = "Update Product";
                _product.Mode = clsProducts.enMode.Update;
                AddorUpdateProduct_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Failed to Add Product",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            DataBack?.Invoke(this, _ID);
        }
        private void txtproductname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                e.Cancel = true;
                txtproductname.Focus();
                errorProvider1.SetError(txtproductname,"You Must Write Product Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtproductname, "");
            }
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtquantity.Text))
            {
                e.Cancel = true;
                txtproductname.Focus();
                errorProvider1.SetError(txtquantity, "You Must Write Quantity Product");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtquantity, "");
            }
        }

        private void txtprice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtprice.Text))
            {
                e.Cancel = true;
                txtproductname.Focus();
                errorProvider1.SetError(txtprice, "You Must Write Price of Product");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtprice, "");
            }
        }
    }
}
