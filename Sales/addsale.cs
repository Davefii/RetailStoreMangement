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

namespace RetailStoreManagment.Sales
{
    public partial class addsale : Form
    {
        private int _SaleID = -1;
        BussinessLayer.Sales _sale;
        public addsale()
        {
            InitializeComponent();
        }
        public addsale(int SaleID)
        {
            _SaleID = SaleID;
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabPage2.Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
        }
        private void LoadDataAddMode()
        {
            _sale = new BussinessLayer.Sales();
            tabPage2.Enabled = false;
            this.Text = "Create Sale";
        }
        private void LoadDataUpdateMode()
        {
            this.Text = "Show Sale";
            btnSave.Enabled = false;
            btnNext.Enabled = false;
            ctrlProductwithfilter1.FilterEnabled = false;
            _sale = BussinessLayer.Sales.GetSaleByID(_SaleID);
            ctrlProductwithfilter1.LoadProduct(_sale.Product_ID);
            tabPage2.Enabled = true;
            txbquantity.Text = _sale.Quantity.ToString();
            lblusername.Text = _sale.user.UserName;
            lblsaledate.Text = _sale.SaleDate.ToShortDateString();
            lbltotalprice.Text = _sale.TotalPrice.ToString();
        }
        private void addsale_Load(object sender, EventArgs e)
        {
            if (_SaleID != -1)
            {
                LoadDataUpdateMode();
            }
            else
            {
                LoadDataAddMode();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _sale.Product_ID = ctrlProductwithfilter1.Product_ID;
            if (ctrlProductwithfilter1.Product_ID <= 0)
            {
                MessageBox.Show("Please Ensure add or Select Product ",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _sale.User_ID = clsGlobal.CurrentUser.ID;
            _sale.Quantity = Convert.ToInt32(txbquantity.Text);
            _sale.SaleDate = DateTime.Now;
            if (_sale.Save())
            {
                MessageBox.Show(
                   "Added Product Successfulley",
                   "Success",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
                _SaleID = _sale.ID;
                lblID.Text = _sale.ID.ToString();
                this.Text = "Show Sale";
                _sale.Mode = BussinessLayer.Sales.enMode.Update;
                addsale_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Failed to Create Sale",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
    }
}
