using BookStoreSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStoreSystem.Transaction;

namespace BookStoreSystem.View
{
    public partial class frmOrderBook : Form
    {
        private readonly List<Book> selectedBooks;
        private readonly int userId;
    

        public frmOrderBook(List<Book> selectedBooks, int userId)
        {
            InitializeComponent();
            this.selectedBooks = selectedBooks;
            this.userId = userId;
        }

        private void frmOrderBook_Load(object sender, EventArgs e)
        {
            int i = 1;
            foreach (Book b in selectedBooks)
            {
                Label l = new Label();
                l.Text = i + ". " + b.Title + "-" + b.Author;
                l.Width = flpListOfBooks.ClientSize.Width;
                flpListOfBooks.Controls.Add(l);
                i++;
            }

            var calculator = new CostCalculator(selectedBooks);
            double totalCost = calculator.GetTotalCost();
            txtTotalCost.Text = totalCost.ToString("c");
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (IsTransactionValid()) 
            {
                CardType cardType = GetCardType();

                DateTime expiration = GetCreditCardExpiration();

                Transaction transaction = new Transaction(0, userId, selectedBooks, DateTime.Now, double.Parse(txtTotalCost.Text.TrimStart('$')), txtCardNo.Text,
                    cardType, expiration, int.Parse(txtSecurityCode.Text), txtBillingAddress.Text,
                    txtZIP.Text, cbState.SelectedItem.ToString()
                    );
                //add database method to get add transaction to the DB
                DatabaseController.CreateTransaction(transaction);

                Label lblPersonWhoIsBillingInfo = new Label();
                lblPersonWhoIsBillingInfo.Text = "Billing Name: " + txtBillingName.Text + " " + "Billing Address: " + txtBillingAddress.Text;
                lblPersonWhoIsBillingInfo.Width = flpCustomersWhoOrdered.ClientSize.Width;
                flpCustomersWhoOrdered.Controls.Add(lblPersonWhoIsBillingInfo);

                txtBillingName.Text = "";
                txtBillingAddress.Text = "";

                //add database method to get transaction
            }
            
        }

        private DateTime GetCreditCardExpiration()
        {
            string month = txtExpDate.Text.Substring(0, 2);
            string year = txtExpDate.Text.Substring(2, 4);

            int intMonth = int.Parse(month);
            int intYear = int.Parse(year);
            DateTime expirationDate = new DateTime(intYear, intMonth, 1);
            return expirationDate;
        }

        private CardType GetCardType()
        {
            CardType cardType = CardType.VISA;
            if (cbCardType.SelectedItem.ToString() == "Master Card")
            {
                cardType = CardType.Master;
            }
            else if (cbCardType.SelectedItem.ToString() == "American Express")
            {
                cardType = CardType.AmericanExpress;
            }
            else if (cbCardType.SelectedItem.ToString() == "Visa")
            {
                cardType = CardType.VISA;
            }

            return cardType;
        }

        private bool IsTransactionValid()
        {
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("No book selected.");
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtCardNo.Text)){
                MessageBox.Show("Must enter card number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSecurityCode.Text))
            {
                MessageBox.Show("Must enter security code.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBillingName.Text))
            {
                MessageBox.Show("Must enter billing name.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBillingAddress.Text))
            {
                MessageBox.Show("Must enter billing address.");
                return false;
            }

            const string usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

            if (string.IsNullOrWhiteSpace(txtZIP.Text) || !Regex.Match(txtZIP.Text, usZipRegEx).Success)
            {
                MessageBox.Show("Must enter valid ZIP code.");
                return false;
            }

            if (cbCardType.SelectedItem == null)
            {
                MessageBox.Show("Must select a card type.");
                return false;
            }

            const string cardNoRegEx = @"^(?:\d[ -]*?){13,16}$";

            if(string.IsNullOrWhiteSpace(txtCardNo.Text) || !Regex.Match(txtCardNo.Text, cardNoRegEx).Success)
            {
                MessageBox.Show("Must enter valid credit card number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtExpDate.Text))
            {
                MessageBox.Show("Credit card expiration date is required.");
                return false;
            }

            if (txtExpDate.Text.Length != 6)
            {
                MessageBox.Show("Credit card expiration date must be in format MMYYYY.");
                return false;
            }

            string month = txtExpDate.Text.Substring(0, 2);
            string year = txtExpDate.Text.Substring(2, 4);

            int intMonth;
            int intYear;

            if (!int.TryParse(month, out intMonth))
            {
                MessageBox.Show("Credit card expiration date must be in format MMYYYY.");
                return false;
            }

            if (!int.TryParse(year, out intYear))
            {
                MessageBox.Show("Credit card expiration date must be in format MMYYYY.");
                return false;
            }

            try
            {
                DateTime expirationDate = new DateTime(intYear, intMonth, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Credit card expiration date must be in format MMYYYY.");
                return false;
            }

            
            if (cbState.SelectedItem == null)
            {
                MessageBox.Show("Please select a state.");
                return false;
            }

            if (cbCardType.SelectedItem == null)
            {
                MessageBox.Show("Please select a credit card type.");
                return false;
            }
          

            return true;
        }
    }
}
