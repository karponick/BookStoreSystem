using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public partial class frmTransactionList : Form
    {
        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            listViewTransactions.View = System.Windows.Forms.View.Details;
            listViewTransactions.GridLines = true;
            listViewTransactions.FullRowSelect = true;
            listViewTransactions.Scrollable = true;

            listViewTransactions.Columns.Add("Transaction ID", 100);
            listViewTransactions.Columns.Add("User ID", 100);
            listViewTransactions.Columns.Add("Purchase Date", 100);
            listViewTransactions.Columns.Add("Total Cost", 100);

            listViewTransactions.Items.Clear();
            List<Transaction> transactions = DatabaseController.GetTransactions();
            foreach (var transaction in transactions)
            {
                string[] arr = new string[4];
                arr[0] = transaction.TransactionID.ToString();
                arr[1] = transaction.UserID.ToString();
                arr[2] = transaction.PurchaseDate.ToString();
                arr[3] = transaction.TotalCost.ToString("c");
                ListViewItem transactionItem = new ListViewItem(arr);
                listViewTransactions.Items.Add(transactionItem);
            }
        }
    }
}
