using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreSystem.View;

namespace BookStoreSystem
{
    public partial class frmMenu : Form
    {
        /************************ Constructors ************************/
        public frmMenu()
        {
            InitializeComponent();
        }

        /*************************** Events ***************************/
        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBookList bookListForm = new frmBookList(true, 1);
            bookListForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            frmTransactionList transactionList = new frmTransactionList();
            transactionList.ShowDialog();
        }
    }
}
