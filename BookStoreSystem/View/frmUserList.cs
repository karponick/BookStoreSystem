using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStoreSystem.User;

namespace BookStoreSystem.View
{
    public partial class frmUserList : Form
    {
        private List<User> users;
        private User selectedUser;
        public frmUserList()
        {
            InitializeComponent();  
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            GetAndDisplayAllUsers();
        }

        private void GetAndDisplayAllUsers()
        {
            users = DatabaseController.GetAllUsers();
            listViewUsers.View = System.Windows.Forms.View.Details;
            listViewUsers.GridLines = true;
            listViewUsers.FullRowSelect = true;
            listViewUsers.Scrollable = true;
            listViewUsers.MultiSelect = true;

            listViewUsers.Columns.Clear();
            listViewUsers.Columns.Add("User ID", 100);
            listViewUsers.Columns.Add("Username", 100);
            listViewUsers.Columns.Add("Password", 100);
            listViewUsers.Columns.Add("Account Type", 100);

            listViewUsers.Items.Clear();

            foreach (var user in users)
            {
                string[] arr = new string[4];
                arr[0] = user.UserID.ToString();
                arr[1] = user.UserName.ToString();
                arr[2] = user.Password.ToString();
                arr[3] = user.AccountType1.ToString();
                ListViewItem userItem = new ListViewItem(arr);
                listViewUsers.Items.Add(userItem);
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count > 0)
            {
                selectedUser = users[listViewUsers.SelectedIndices[0]];
                txtUserID.Text = selectedUser.UserID.ToString();
                txtUsername.Text = selectedUser.UserName.ToString();
                txtPassword.Text = selectedUser.Password.ToString();
                cbAccountType.SelectedItem = selectedUser.AccountType1.ToString();
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            selectedUser.UserName = txtUsername.Text.Trim();
            selectedUser.Password = txtPassword.Text.Trim();
            selectedUser.AccountType1 = (AccountType)Enum.Parse(typeof(AccountType), cbAccountType.Text);


            if (DatabaseController.UpdateUser(selectedUser))
            {
                MessageBox.Show("User information has been updated.",  "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAndDisplayAllUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to permanently delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               if ( DatabaseController.DeleteUser(selectedUser.UserID))
                {
                    MessageBox.Show("User has been deleted.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAndDisplayAllUsers();
                }
            }
        }
    }
}
