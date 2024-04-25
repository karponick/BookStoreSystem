using BookStoreSystem.Controller;
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
    public partial class frmGoogleSearch : Form
    {
        private frmBookEdit parent;
        private List<Book> books;
        private int position;
        public frmGoogleSearch(frmBookEdit parent)
        {
            InitializeComponent();
            this.parent = parent;
            position = 0;
        }

        private void DisplayCurrentBook()
        {
            if (books == null || books.Count == 0) { return; }
            parent.Populate(books[position]);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty && txtAuthor.Text == string.Empty)
            {
                MessageBox.Show("Missing title and/or author query");
                return;
            }
            books = APIController.GoogleSearch(txtTitle.Text, txtAuthor.Text);
            DisplayCurrentBook();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (books == null) { return; }
            position = (position  + books.Count + 1) % books.Count;
            DisplayCurrentBook();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (books == null) { return; }
            position = (position + books.Count - 1) % books.Count;
            DisplayCurrentBook();
        }
    }
}
