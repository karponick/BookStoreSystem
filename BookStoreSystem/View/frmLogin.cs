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
                    MessageBox.Show("Pease select account type");
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
                MessageBox.Show("Please select account type");
                return;
            }

            User user = DatabaseController.GetUser(txtUsername.Text.Trim(), txtPassword.Text.Trim(), accountType);

            if (user == null)
            {
                MessageBox.Show("Invalid Login attempt. Please try again.");
                return;
            }


            // Temporary IF statements. Might need update once User is validated against database

            if (rbAdmin.Checked)
            {
                Visible = false;
                frmMenu menuForm = new frmMenu();
                menuForm.ShowDialog();
                Visible = true;
            }
            if (rbCustomer.Checked)
            {
                Visible = false;
                frmBookList bookListForm = new frmBookList(false, user.UserID);
                bookListForm.ShowDialog();
                Visible = true;
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