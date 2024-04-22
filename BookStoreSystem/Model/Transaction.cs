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
        private List<Book> books;
        private DateTime purchaseDate;
        private double totalCost;
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

        public Transaction(int transactionID, int userID, List<Book> books, DateTime purchaseDate, double totalCost, string cardNumber, CardType cardType, DateTime expirationDate,
            int securityCode, string billingAddress, string zip, string state)
        {
            this.transactionID = transactionID;
            this.userID = userID;
            this.books = books;
            this.purchaseDate = purchaseDate;
            this.totalCost = totalCost;
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

        public List<Book> Books {
            get { return books; }
            set { books = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
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
            get { return zip; }
            set { zip = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
