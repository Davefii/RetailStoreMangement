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
    public partial class UserInfomration : Form
    {
        private int _ID = -1;
        public UserInfomration(int iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void UserInfomration_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadData(_ID);
        }
    }
}
