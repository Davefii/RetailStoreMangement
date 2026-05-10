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
        private void ApplyModernStyle()
        {
            // === الـ Form ===
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);

            // === MenuStrip ===
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            menuStrip1.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            menuStrip1.Padding = new System.Windows.Forms.Padding(10, 6, 0, 6);
            foreach (System.Windows.Forms.ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
                item.BackColor = System.Drawing.Color.White;
            }

            // === البطاقات الأربع ===
            SetupCard(panel1, label2, lblTotalSales,
                System.Drawing.Color.FromArgb(220, 240, 255),
                System.Drawing.Color.FromArgb(24, 95, 165));

            SetupCard(panel2, label3, lblTotalProducts,
                System.Drawing.Color.FromArgb(229, 240, 240),
                System.Drawing.Color.FromArgb(39, 120, 71));

            SetupCard(panel4, label7, lblTotalSupplier,
                System.Drawing.Color.FromArgb(250, 240, 229),
                System.Drawing.Color.FromArgb(160, 100, 0));

            SetupCard(panel3, label5, lblLowProducts,
                System.Drawing.Color.FromArgb(249, 230, 236),
                System.Drawing.Color.FromArgb(180, 40, 40));

            // Position Carts
            panel1.Location = new System.Drawing.Point(18, 55);
            panel2.Location = new System.Drawing.Point(315, 55);
            panel4.Location = new System.Drawing.Point(612, 55);
            panel3.Location = new System.Drawing.Point(909, 55);

            // === Labels All Sales ===
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label1.Location = new System.Drawing.Point(18, 200);

            // === Button New Sale ===
            button1.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            button1.ForeColor = System.Drawing.Color.White;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            button1.Size = new System.Drawing.Size(110, 34);
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.Location = new System.Drawing.Point(1130, 197);

            // === DataGridView ===
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.GridColor = System.Drawing.Color.FromArgb(230, 232, 235);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridView1.ColumnHeadersHeight = 38;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 228, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.Location = new System.Drawing.Point(18, 242);
        }

        private void SetupCard(
            System.Windows.Forms.Panel panel,
            System.Windows.Forms.Label titleLabel,
            System.Windows.Forms.Label valueLabel,
            System.Drawing.Color bgColor,
            System.Drawing.Color fgColor)
        {
            panel.BackColor = bgColor;
            panel.Size = new System.Drawing.Size(280, 115);

            titleLabel.ForeColor = fgColor;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(16, 16);

            valueLabel.ForeColor = fgColor;
            valueLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            valueLabel.Location = new System.Drawing.Point(16, 55);
            MakeRoundedPanel(panel);
        }
        private void MakeRoundedPanel(System.Windows.Forms.Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var rect = new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int r = 16;
                    path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                    path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                    path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                    path.CloseFigure();
                    using (var brush = new System.Drawing.SolidBrush(panel.BackColor))
                        g.FillPath(brush, path);
                }
            };
            panel.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 16, 16));
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
        private void LoadDataFrom()
        {
            lblTotalSupplier.Text = Supplier.GetTotalSuppliers().ToString() + " Suppliers";
            lblTotalSales.Text = BussinessLayer.Sales.GetTotalSales().ToString() + " £";
            lblLowProducts.Text = BussinessLayer.Products.GetTotalLowProduct().ToString() + " Products";
            lblTotalProducts.Text = BussinessLayer.Products.GetTotalProduct().ToString() + " Items";
            dataGridView1.DataSource = BussinessLayer.Sales.GetAllSeles();
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFrom();
            ApplyModernStyle();
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
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
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
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
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
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.StaffOrCashier) || clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
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
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
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
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
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
