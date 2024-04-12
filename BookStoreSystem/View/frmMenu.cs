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
        /*************************** Fields ***************************/
        private static DatabaseController dbc;
        /************************ Constructors ************************/
        public frmMenu()
        {
            InitializeComponent();
            dbc = new DatabaseController();
        }
        /************************* Properties ************************/
        public static DatabaseController DBC { get { return dbc; } }

        /*************************** Events ***************************/
        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBookList bookListForm = new frmBookList();
            bookListForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

        }
    }
}
