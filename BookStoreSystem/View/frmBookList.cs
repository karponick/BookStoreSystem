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
        private readonly BookPanel bookPanel;
        public frmBookList()
        {
            InitializeComponent();
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.ColumnCount = 3;
            UpdateGrid();

            bookPanel = new BookPanel();
            Controls.Add(bookPanel);
            dgvBooks.SendToBack();
        }
        // Methods
        private void UpdateGrid()
        {
            dgvBooks.Columns[0].HeaderText = "Title";
            dgvBooks.Columns[0].DataPropertyName = "Title";
            dgvBooks.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBooks.Columns[1].HeaderText = "Author";
            dgvBooks.Columns[1].DataPropertyName = "Author";
            dgvBooks.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBooks.Columns[2].HeaderText = "Genre";
            dgvBooks.Columns[2].DataPropertyName = "Genre";
            dgvBooks.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

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

        private void dgvBooks_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) { return; }
            Book book = (Book)dgvBooks.Rows[row].DataBoundItem;
            bookPanel.Populate(book);

        }

        private void dgvBooks_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            bookPanel.Visible = false;
        }
    }
}
