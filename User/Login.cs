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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Login_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txbusername.Text = UserName;
                txbpassword.Text = Password;
                chkRemmeberMe.Checked = true;
            }
            else
                chkRemmeberMe.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = Users.GetUserNamewithPassword(txbusername.Text, txbpassword.Text);
            if (clsGlobal.CurrentUser != null)
            {
                clsGlobal.RememberUserNameandPassword(txbusername.Text, txbpassword.Text);
                if (clsGlobal.CurrentUser.isActive)
                {
                    MainMenu mainMenu = new MainMenu();
                    this.Hide();
                    mainMenu.Show();
                }
                else
                {
                    MessageBox.Show("This User is Not Active",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txbusername.Focus();
                MessageBox.Show("Invalid Username/Password.",
                    "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
