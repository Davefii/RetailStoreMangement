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
    public partial class ctrlProductInfo : UserControl
    {
        private int _ID = -1; 
        private string _ProductName = string.Empty;
        private BussinessLayer.Products _product;
        public int Product_ID { get { return _ID; } }
        public BussinessLayer.Products SelectedProductinfo { get { return _product; } }
        public ctrlProductInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int ID)
        {
            _ID = ID;
            lblID.Text = _ID.ToString();
            _product = BussinessLayer.Products.GetProductByID(_ID);
            if (_product == null)
            {
                MessageBox.Show("Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblproductname.Text = _product.Name;
            lblsuppliername.Text = _product.supplierInfo.Supplier_Name;
            lblprice.Text = _product.price.ToString();
            lblquantity.Text = _product.Quantity.ToString();
        }
        public void LoadInfo(string ProductName)
        {
            _ProductName = ProductName;
            _product = BussinessLayer.Products.GetProductByName(_ProductName);
            if (_product == null)
            {
                MessageBox.Show("Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ID = _product.ID;
            lblID.Text = _product.ID.ToString();
            lblproductname.Text = _product.Name;
            lblsuppliername.Text = _product.supplierInfo.Supplier_Name;
            lblprice.Text = _product.price.ToString();
            lblquantity.Text = _product.Quantity.ToString();
        }
    }
}
