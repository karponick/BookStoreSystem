using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public  class Transaction
    {
        private int transactionID;
        private int userID;
        private int bookID;
        private DateTime purchaseDate;
        private double bookCost;

        public Transaction(int transactionID, int userID, int bookID, DateTime purchaseDate, double bookCost)
        {
            this.transactionID = transactionID;
            this.userID = userID;
            this.bookID = bookID;
            this.purchaseDate = purchaseDate;
            this.bookCost = bookCost;
        }

        public int TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int BookID
        {
            get { return bookID; }
            set { bookID = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        public double BookCost
        {
            get { return bookCost; }
            set { bookCost = value; }
        }
    }
}
