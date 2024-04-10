using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem
{
    public partial class frmMenu : Form
    {
        private static DatabaseController dbc;
        public frmMenu()
        {
            InitializeComponent();
            dbc = new DatabaseController();
        }
        public static DatabaseController DBC { get { return dbc; } }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            frmBookList bookListForm = new frmBookList();
            bookListForm.ShowDialog();
        }
    }
}
