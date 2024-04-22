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
        private readonly int bookId;
        private readonly int userId;

        public frmOrderBook(int bookId, int userId)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.userId = userId;
        }

        private void frmOrderBook_Load(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (IsTransactionValid()) 
            {
                Transaction transaction = new Transaction(0, userId, bookId, DateTime.Now, double.Parse(txtTotalCost.Text), txtCardNo.Text, 
                    (CardType)Enum.Parse(typeof(CardType), cbCardType.Text), dtpExpDate.Value, int.Parse(txtSecurityCode.Text), txtBillingAddress.Text,
                    txtZIP.Text, cbState.SelectedItem.ToString()
                    );

            }
            
        }

        private bool IsTransactionValid()
        {
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

            if(dtpExpDate.Value < DateTime.Today)
            {
                MessageBox.Show("Your credit card has expired.");
                return false;
            }
          

            return true;
        }
    }
}
