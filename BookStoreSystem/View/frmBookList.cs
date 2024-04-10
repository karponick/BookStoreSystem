using BookStoreSystem.View;
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
    public partial class frmBookList : Form
    {
        public frmBookList()
        {
            InitializeComponent();
            UpdateGrid();
        }
        // Methods
        private void UpdateGrid()
        {
            dgvBooks.DataSource = frmMenu.DBC.GetBookList();
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // Events
        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmBookEdit createBookForm = new frmBookEdit();
            createBookForm.ShowDialog();
            UpdateGrid();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBooks.SelectedRows)
            {
                int.TryParse(row.Cells[0].Value.ToString(), out int bookId);
                frmMenu.DBC.DeleteBook(bookId);
            }
            UpdateGrid();
        }
    }
}
