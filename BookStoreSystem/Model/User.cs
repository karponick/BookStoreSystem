using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public class User
    {
        private int userID;
        private string userName;
        private string password;
        private AccountType accountType;

        public enum AccountType
        {
            Admin, Customer
        }

        public User(int userID, string userName, string password, AccountType accountType)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.accountType = accountType;
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public AccountType AccountType1
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }
}