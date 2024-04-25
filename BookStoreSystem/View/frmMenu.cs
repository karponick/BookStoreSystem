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
            frmBookList bookListForm = new frmBookList();
            bookListForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUserList userList = new frmUserList();
            userList.ShowDialog();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            frmTransactionList transactionList = new frmTransactionList();
            transactionList.ShowDialog();
        }
    }
}
