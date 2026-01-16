using BussinessLayer;
using RetailStoreManagment.Products;
using RetailStoreManagment.Sales;
using RetailStoreManagment.Suppliers;
using RetailStoreManagment.User;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void LoadDataFrom()
        {
            lblTotalSupplier.Text = clsSupplier.GetTotalSuppliers().ToString() + " Suppliers";
            lblTotalSales.Text = clsSales.GetTotalSales().ToString() + " £";
            lblLowProducts.Text = clsProducts.GetTotalLowProduct().ToString() + " Products";
            lblTotalProducts.Text = clsProducts.GetTotalProduct().ToString() + " Items";
            dataGridView1.DataSource = clsSales.GetAllSeles();
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFrom();
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListSuppliers listSuppliers = new ListSuppliers();
            listSuppliers.ShowDialog();
            Form1_Load(null, null);
        }

        private void addNewSupplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddorUpdateSupplier addorUpdateSupplier = new AddorUpdateSupplier();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                addorUpdateSupplier.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(null, null);
        }

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListProducts listProducts = new ListProducts();
            listProducts.ShowDialog();
            Form1_Load(null, null);
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addsale addsale = new addsale();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.StaffOrCashier) || clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                addsale.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are  Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(null, null);
        }

        private void listUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListUsers listUsers = new ListUsers();
            listUsers.Show();
        }

        private void viewHistoryOfLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listhistorylogin listhistorylogin = new Listhistorylogin();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                listhistorylogin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddorUpdateUser addorUpdateUser = new AddorUpdateUser();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Admin))
            {
                addorUpdateUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfomration userInfomration = new UserInfomration(clsGlobal.CurrentUser.ID);
            userInfomration.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
