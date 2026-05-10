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
    public partial class ListUsers : Form
    {
        public ListUsers()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = Users.Getallusers();
        }
        private void ListUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
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
            ListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddorUpdateUser addorUpdateUser = new AddorUpdateUser(UserID);
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
            {
                addorUpdateUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Users user = Users.GetUserByID(UserID);
            if (clsGlobal.CheckPermition(Users.enMainMenuPermitions.Admin))
            {
                if (MessageBox.Show("Are You Sure Delete This User ? ", "Ensure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (user.DeleteUser())
                    {
                        MessageBox.Show("Deleted User Successfuly", "Succcsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Deleted User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ListUsers_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Access Denid You Are Staff (Cashier) or Viewer",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            UserInfomration userInfomration = new UserInfomration(UserID);
            userInfomration.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtertext = textBox1.Text.Trim().Replace("'", "'");
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $"UserName LIKE '%{filtertext}%'";
        }
    }
}
