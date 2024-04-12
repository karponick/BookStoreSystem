using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Must enter a Username.");
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Must enter a password.");
                return;
            }
            else
            {
                User.AccountType accountType;
                if (rbAdmin.Checked)
                {
                    accountType = User.AccountType.Admin;
                }
                else if (rbCustomer.Checked)
                {
                    accountType = User.AccountType.Customer;
                }
                else
                {
                    MessageBox.Show("PLease select account type");
                    return;
                }

                //create new account
                var user = new User(0, txtUsername.Text.Trim(), txtPassword.Text.Trim(), accountType);

                if (DatabaseController.GetUser(txtUsername.Text.Trim(), txtPassword.Text.Trim(), user.AccountType1) != null)
                {
                    MessageBox.Show("This account already exists.");
                }
                else if (DatabaseController.AddUser(user) == true)
                {
                    MessageBox.Show("Account successfully created.");
                    this.Close();
                }
            }

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Must enter a Username.");
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Must enter a password.");
                return;
            }
            else if (rbAdmin.Checked == false && rbCustomer.Checked == false)
            {
                MessageBox.Show("Please select an account type.");
                return;
            }
        }






        // Temporary Menu button click to bypass login
        private void btnTemp_Click(object sender, EventArgs e)
        {
            frmMenu menuForm = new frmMenu();
            Visible = false;
            menuForm.ShowDialog();
            Visible = true;
        }
    }
}