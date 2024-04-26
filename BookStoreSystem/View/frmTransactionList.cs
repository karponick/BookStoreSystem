using BookStoreSystem.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public partial class frmTransactionList : Form
    {
        private readonly List<Transaction> transactions;
        public frmTransactionList()
        {
            InitializeComponent();
            transactions = DatabaseController.GetTransactions();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            listViewTransactions.View = System.Windows.Forms.View.Details;
            listViewTransactions.GridLines = true;
            listViewTransactions.FullRowSelect = true;
            listViewTransactions.Scrollable = true;
            listViewTransactions.MultiSelect = true;

            listViewTransactions.Columns.Add("Transaction ID", 100);
            listViewTransactions.Columns.Add("User ID", 100);
            listViewTransactions.Columns.Add("Purchase Date", 100);
            listViewTransactions.Columns.Add("Total Cost", 100);

            listViewTransactions.Items.Clear();
            
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

        private void listViewTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            if (listViewTransactions.SelectedIndices.Count > 0)
            {
                flpBooks.Controls.Clear();
                flpImages.Controls.Clear();
               
                Transaction selectedTrans = transactions[listViewTransactions.SelectedIndices[0]];
                List<Book> books = DatabaseController.GetBooksByTransaction(selectedTrans.TransactionID);
                int i = 1;
                foreach(Book book in books)
                {
                    Label l = new Label();
                    l.Text = i + ". " + book.Title + " - " + book.Author + " - " + book.Price;
                    l.Width = flpBooks.ClientSize.Width;//to increase label width
                    flpBooks.Controls.Add(l);
                    i++;

                    PictureBox pb = new PictureBox();
                    pb.Height = 50;//50 pixels
                    pb.Width = 50;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (!string.IsNullOrEmpty(book.CoverUrl))
                    {
                        try
                        {
                            pb.Load(book.CoverUrl);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            book.CoverImage = Image.FromFile("placeholder.jpg");
                        }
                    }
                    else
                    {
                        book.CoverImage = Image.FromFile("placeholder.jpg");
                    }
                    flpImages.Controls.Add(pb);
                }
            }
   
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string path = Path.Combine(fbd.SelectedPath, "transactions.csv");
                    if (FileController.ExportToCSV(transactions, path))
                    {
                        MessageBox.Show("Transaction information has been exported to the " + path + ".", "Export Transactions",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
