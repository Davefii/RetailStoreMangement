namespace RetailStoreManagment.Suppliers
{
    partial class AddorUpdateSupplier
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSupplierName = new System.Windows.Forms.TextBox();
            this.txdcontactname = new System.Windows.Forms.TextBox();
            this.txtbphonenumber = new System.Windows.Forms.TextBox();
            this.txtbemail = new System.Windows.Forms.TextBox();
            this.txtbaddress = new System.Windows.Forms.TextBox();
            this.chkactiveUnactive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID : ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(71, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 30);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Person Name for contact :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone Number : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(194, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "Address : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "Is Active : ";
            // 
            // txbSupplierName
            // 
            this.txbSupplierName.Location = new System.Drawing.Point(278, 74);
            this.txbSupplierName.Name = "txbSupplierName";
            this.txbSupplierName.Size = new System.Drawing.Size(208, 20);
            this.txbSupplierName.TabIndex = 8;
            this.txbSupplierName.Validating += new System.ComponentModel.CancelEventHandler(this.txbSupplierName_Validating);
            // 
            // txdcontactname
            // 
            this.txdcontactname.Location = new System.Drawing.Point(278, 124);
            this.txdcontactname.Name = "txdcontactname";
            this.txdcontactname.Size = new System.Drawing.Size(208, 20);
            this.txdcontactname.TabIndex = 9;
            this.txdcontactname.Validating += new System.ComponentModel.CancelEventHandler(this.txdcontactname_Validating);
            // 
            // txtbphonenumber
            // 
            this.txtbphonenumber.Location = new System.Drawing.Point(278, 173);
            this.txtbphonenumber.Name = "txtbphonenumber";
            this.txtbphonenumber.Size = new System.Drawing.Size(208, 20);
            this.txtbphonenumber.TabIndex = 10;
            this.txtbphonenumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtbphonenumber_Validating);
            // 
            // txtbemail
            // 
            this.txtbemail.Location = new System.Drawing.Point(278, 219);
            this.txtbemail.Name = "txtbemail";
            this.txtbemail.Size = new System.Drawing.Size(208, 20);
            this.txtbemail.TabIndex = 11;
            this.txtbemail.Validating += new System.ComponentModel.CancelEventHandler(this.txtbemail_Validating);
            // 
            // txtbaddress
            // 
            this.txtbaddress.Location = new System.Drawing.Point(278, 272);
            this.txtbaddress.Name = "txtbaddress";
            this.txtbaddress.Size = new System.Drawing.Size(208, 20);
            this.txtbaddress.TabIndex = 12;
            this.txtbaddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtbaddress_Validating);
            // 
            // chkactiveUnactive
            // 
            this.chkactiveUnactive.AutoSize = true;
            this.chkactiveUnactive.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkactiveUnactive.Location = new System.Drawing.Point(278, 311);
            this.chkactiveUnactive.Name = "chkactiveUnactive";
            this.chkactiveUnactive.Size = new System.Drawing.Size(187, 34);
            this.chkactiveUnactive.TabIndex = 13;
            this.chkactiveUnactive.Text = "Active/Unactive";
            this.chkactiveUnactive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(414, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(321, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 32);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddorUpdateSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 405);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkactiveUnactive);
            this.Controls.Add(this.txtbaddress);
            this.Controls.Add(this.txtbemail);
            this.Controls.Add(this.txtbphonenumber);
            this.Controls.Add(this.txdcontactname);
            this.Controls.Add(this.txbSupplierName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 444);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(529, 444);
            this.Name = "AddorUpdateSupplier";
            this.Text = "AddorUpdateSupplier";
            this.Load += new System.EventHandler(this.AddorUpdateSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSupplierName;
        private System.Windows.Forms.TextBox txdcontactname;
        private System.Windows.Forms.TextBox txtbphonenumber;
        private System.Windows.Forms.TextBox txtbemail;
        private System.Windows.Forms.TextBox txtbaddress;
        private System.Windows.Forms.CheckBox chkactiveUnactive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}