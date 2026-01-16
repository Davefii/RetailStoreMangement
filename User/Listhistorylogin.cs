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

namespace RetailStoreManagment.User
{
    public partial class Listhistorylogin : Form
    {
        public Listhistorylogin()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = clsUsers.GetHistoryUserlogin();
        }
        private void Listhistorylogin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
