namespace RetailStoreManagment.Suppliers
{
    partial class FrmSupplierinfo
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
            this.supplierInfo1 = new RetailStoreManagment.Suppliers.SupplierInfo();
            this.SuspendLayout();
            // 
            // supplierInfo1
            // 
            this.supplierInfo1.Location = new System.Drawing.Point(10, 12);
            this.supplierInfo1.Name = "supplierInfo1";
            this.supplierInfo1.Size = new System.Drawing.Size(594, 196);
            this.supplierInfo1.TabIndex = 0;
            // 
            // FrmSupplierinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 210);
            this.Controls.Add(this.supplierInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSupplierinfo";
            this.Text = "Supplier info";
            this.Load += new System.EventHandler(this.FrmSupplierinfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SupplierInfo supplierInfo1;
    }
}