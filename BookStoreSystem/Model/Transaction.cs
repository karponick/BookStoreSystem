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
        private string cardNumber;
        private CardType cardType;
        private DateTime expirationDate;
        private int securityCode;
        private string billingAddress;
        private string zip;
        private string state;

        public enum CardType
        {
            VISA, Master, AmericanExpress
        }

        public Transaction(int transactionID, int userID, int bookID, DateTime purchaseDate, double bookCost, string cardNumber, CardType cardType, DateTime expirationDate,
            int securityCode, string billingAddress, string zip, string state)
        {
            this.transactionID = transactionID;
            this.userID = userID;
            this.bookID = bookID;
            this.purchaseDate = purchaseDate;
            this.bookCost = bookCost;
            this.cardNumber = cardNumber;
            this.cardType = cardType;
            this.expirationDate = expirationDate;
            this.securityCode = securityCode;
            this.billingAddress = billingAddress;
            this.zip = zip;
            this.state = state;
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

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public CardType CardType1
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public DateTime ExpDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public int SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value; }
        }

        public string BillingAddress
        {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        public string ZIP
        {
            get { return ZIP; }
            set { ZIP = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
