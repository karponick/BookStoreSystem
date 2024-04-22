using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem.Controller
{
    public static class SystemController
    {
        private static User currentUser;

        public static User CurrentUser { get { return currentUser; } set { currentUser = value; } }
        
        public static void Login()
        {
            if (IsAdmin())
            {
                frmMenu menuForm = new frmMenu();
                menuForm.ShowDialog();
            }
            else if (currentUser.AccountType1 == User.AccountType.Customer)
            {
                frmBookList bookListForm = new frmBookList();
                bookListForm.ShowDialog();
            }
        }

        public static bool IsAdmin()
        {
            if (currentUser.AccountType1 == User.AccountType.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
