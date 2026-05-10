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

namespace RetailStoreManagment
{
    public partial class ListSuppliers : Form
    {
        public ListSuppliers()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = Supplier.GetAllSupplier();
            dataGridView1.Columns[4].Width = 150;
        }
        private void ListSuppliers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnaddsupplier_Click(object sender, EventArgs e)
        {
            AddorUpdateSupplier addorUpdateSupplier = new AddorUpdateSupplier();
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
            {
                addorUpdateSupplier.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListSuppliers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SupplierID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Supplier supplier = Supplier.GetSupplierByID(SupplierID);
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
            {
                if (MessageBox.Show("Are You Sure Delete This Supplier ? ", "Ensure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (supplier.DeleteSuppliuer())
                    {
                        MessageBox.Show("Deleted Supplier Successfuly", "Succcsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to Deleted Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You Can't Delete Supplier You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListSuppliers_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SupplierID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddorUpdateSupplier addorUpdateSupplier = new AddorUpdateSupplier(SupplierID);
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
            {
                addorUpdateSupplier.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListSuppliers_Load(null, null);
        }

        private void supplierInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SupplierID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            FrmSupplierinfo frmSupplierinfo = new FrmSupplierinfo(SupplierID);
            frmSupplierinfo.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtertext = textBox1.Text.Trim().Replace("'","'");
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $"Supplier_Name LIKE '%{filtertext}%'";
        }
    }
}
