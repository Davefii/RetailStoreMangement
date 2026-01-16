using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailStoreManagment.Suppliers
{
    public partial class FrmSupplierinfo : Form
    {
        private int _ID = -1;
        public FrmSupplierinfo(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void FrmSupplierinfo_Load(object sender, EventArgs e)
        {
            supplierInfo1.LoadData(_ID);
        }
    }
}
