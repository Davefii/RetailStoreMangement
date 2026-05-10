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
    public partial class ctrlUserInfo : UserControl
    {
        private int _ID = -1;
        private Users _User;
        public int User_ID { get { return _ID; } }
        public Users SelectedUserInfo { get { return _User; } }
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int ID)
        {
            _ID = ID;
            _User = Users.GetUserByID(_ID);
            lblID.Text = _User.ID.ToString();
            lblusername.Text = _User.UserName;
            lblisActive.Text = _User.isActive ? "Yes" : "No";
            lblPermitions.Text = clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin) ? "Admin" : "Staff (Cashier) or Viewer";
        }
    }
}
