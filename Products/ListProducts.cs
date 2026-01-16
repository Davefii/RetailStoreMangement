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
    public partial class ListProducts : Form
    {
        public ListProducts()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = clsProducts.GetAllProduct();
        }
        private void ListProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void supplierInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SupplierID = (int)dataGridView1.CurrentRow.Cells[4].Value;
            FrmSupplierinfo frmSupplierinfo = new FrmSupplierinfo(SupplierID);
            frmSupplierinfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddorUpdateProduct addorUpdateProduct = new AddorUpdateProduct();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                addorUpdateProduct.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListProducts_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ProductID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddorUpdateProduct addorUpdateProduct = new AddorUpdateProduct(ProductID);
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                addorUpdateProduct.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListProducts_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ProductID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsProducts product = clsProducts.GetProductByID(ProductID);
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                if (MessageBox.Show("Are You Sure Delete This Product ? ", "Ensure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (product.DeleteProduct())
                    {
                        MessageBox.Show("Deleted Product Successfuly", "Succcsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to Deleted Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You Can't Deleted Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ListProducts_Load(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtertext = textBox1.Text.Trim().Replace("'", "'");
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $"Name LIKE '%{filtertext}%'";
        }
    }
}
