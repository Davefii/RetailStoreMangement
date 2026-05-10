namespace RetailStoreManagment
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSupplierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHistoryOfLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLowProducts = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalSupplier = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSuppliersToolStripMenuItem,
            this.manageProductsToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1252, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSupplierToolStripMenuItem,
            this.addNewSupplierToolStripMenuItem1});
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(116, 34);
            this.manageSuppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // addNewSupplierToolStripMenuItem
            // 
            this.addNewSupplierToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.supplier;
            this.addNewSupplierToolStripMenuItem.Name = "addNewSupplierToolStripMenuItem";
            this.addNewSupplierToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.addNewSupplierToolStripMenuItem.Text = "List Supplier";
            this.addNewSupplierToolStripMenuItem.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem_Click);
            // 
            // addNewSupplierToolStripMenuItem1
            // 
            this.addNewSupplierToolStripMenuItem1.Image = global::RetailStoreManagment.Properties.Resources.rectangle_list;
            this.addNewSupplierToolStripMenuItem1.Name = "addNewSupplierToolStripMenuItem1";
            this.addNewSupplierToolStripMenuItem1.Size = new System.Drawing.Size(266, 34);
            this.addNewSupplierToolStripMenuItem1.Text = "Add New Supplier";
            this.addNewSupplierToolStripMenuItem1.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem1_Click);
            // 
            // manageProductsToolStripMenuItem
            // 
            this.manageProductsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listProductsToolStripMenuItem,
            this.addNewProductToolStripMenuItem});
            this.manageProductsToolStripMenuItem.Name = "manageProductsToolStripMenuItem";
            this.manageProductsToolStripMenuItem.Size = new System.Drawing.Size(112, 34);
            this.manageProductsToolStripMenuItem.Text = "Products";
            // 
            // listProductsToolStripMenuItem
            // 
            this.listProductsToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.rectangle_list;
            this.listProductsToolStripMenuItem.Name = "listProductsToolStripMenuItem";
            this.listProductsToolStripMenuItem.Size = new System.Drawing.Size(262, 34);
            this.listProductsToolStripMenuItem.Text = "List Products";
            this.listProductsToolStripMenuItem.Click += new System.EventHandler(this.listProductsToolStripMenuItem_Click);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.add;
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(262, 34);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listUsersToolStripMenuItem,
            this.addNewUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.viewHistoryOfLoginToolStripMenuItem,
            this.userInfoToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(77, 34);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // listUsersToolStripMenuItem
            // 
            this.listUsersToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.rectangle_list;
            this.listUsersToolStripMenuItem.Name = "listUsersToolStripMenuItem";
            this.listUsersToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.listUsersToolStripMenuItem.Text = "List Users";
            this.listUsersToolStripMenuItem.Click += new System.EventHandler(this.listUsersToolStripMenuItem_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.add;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.profilePassword;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::RetailStoreManagment.Properties.Resources.logout;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // viewHistoryOfLoginToolStripMenuItem
            // 
            this.viewHistoryOfLoginToolStripMenuItem.Name = "viewHistoryOfLoginToolStripMenuItem";
            this.viewHistoryOfLoginToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.viewHistoryOfLoginToolStripMenuItem.Text = "View History of Login";
            this.viewHistoryOfLoginToolStripMenuItem.Click += new System.EventHandler(this.viewHistoryOfLoginToolStripMenuItem_Click);
            // 
            // userInfoToolStripMenuItem
            // 
            this.userInfoToolStripMenuItem.Name = "userInfoToolStripMenuItem";
            this.userInfoToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.userInfoToolStripMenuItem.Text = "User Info";
            this.userInfoToolStripMenuItem.Click += new System.EventHandler(this.userInfoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.aboutToolStripMenuItem.Text = "Exit";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTotalSales);
            this.panel1.Location = new System.Drawing.Point(15, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 136);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Sales";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(36, 84);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(25, 40);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = ".";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblLowProducts);
            this.panel3.Location = new System.Drawing.Point(872, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 136);
            this.panel3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(86, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "Low Products";
            // 
            // lblLowProducts
            // 
            this.lblLowProducts.AutoSize = true;
            this.lblLowProducts.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowProducts.ForeColor = System.Drawing.Color.White;
            this.lblLowProducts.Location = new System.Drawing.Point(104, 84);
            this.lblLowProducts.Name = "lblLowProducts";
            this.lblLowProducts.Size = new System.Drawing.Size(25, 40);
            this.lblLowProducts.TabIndex = 0;
            this.lblLowProducts.Text = ".";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkOrange;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblTotalSupplier);
            this.panel4.Location = new System.Drawing.Point(573, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 136);
            this.panel4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(23, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 40);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Supplier";
            // 
            // lblTotalSupplier
            // 
            this.lblTotalSupplier.AutoSize = true;
            this.lblTotalSupplier.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSupplier.ForeColor = System.Drawing.Color.White;
            this.lblTotalSupplier.Location = new System.Drawing.Point(34, 84);
            this.lblTotalSupplier.Name = "lblTotalSupplier";
            this.lblTotalSupplier.Size = new System.Drawing.Size(25, 40);
            this.lblTotalSupplier.TabIndex = 0;
            this.lblTotalSupplier.Text = ".";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(18, 231);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1222, 374);
            this.dataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "All Sales : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblTotalProducts);
            this.panel2.Location = new System.Drawing.Point(255, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 136);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(52, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Products";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(81, 84);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(25, 40);
            this.lblTotalProducts.TabIndex = 0;
            this.lblTotalProducts.Text = ".";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1132, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "New Sale";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retail Store";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLowProducts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalSupplier;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem viewHistoryOfLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInfoToolStripMenuItem;
    }
}

