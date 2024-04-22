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
        /*************************** Fields ***************************/
        private readonly BookPanel bookPanel;
        private int selectedIndex;
        private bool isAdmin;
        private readonly int userId;
        private List<Book> selectedBooks;

        /************************ Constructors ************************/
        public frmBookList(bool isAdmin, int userId)
        {
            InitializeComponent();
            selectedIndex = -1;
            this.isAdmin = isAdmin;
            this.userId = userId;
            if (isAdmin) { btnCreate.Visible = true; }
            selectedBooks = new List<Book>();

            // Initialize datagridview properties
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.ColumnCount = 3;

            dgvBooks.Columns[0].HeaderText = "Title";
            dgvBooks.Columns[0].DataPropertyName = "Title";
            dgvBooks.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBooks.Columns[1].HeaderText = "Author";
            dgvBooks.Columns[1].DataPropertyName = "Author";
            dgvBooks.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBooks.Columns[2].HeaderText = "Genre";
            dgvBooks.Columns[2].DataPropertyName = "Genre";
            dgvBooks.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Create book detail panel
            bookPanel = new BookPanel();
            Controls.Add(bookPanel);
            dgvBooks.SendToBack();

            UpdateGrid();
        }
        /************************** Methods ***************************/
        private void UpdateGrid()
        {
            // Get latest book list from DB and update datagrid
            dgvBooks.DataSource = DatabaseController.GetBookList();
            dgvBooks.Update();
            ClearSelection();
        }
        private void ClearSelection()
        {
            selectedIndex = -1;
            dgvBooks.ClearSelection();
            bookPanel.Visible = false;

            btnModify.Visible = false;
            btnDelete.Visible = false;

            btnPurchase.Visible = false;
            btnReviews.Visible = false;
        }
        /*************************** Events ***************************/
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Open Book Edit form to ADD book to DB and update datagrid
            frmBookEdit editBookForm = new frmBookEdit();
            editBookForm.ShowDialog();
            UpdateGrid();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // Open selected book in Book Edit form to Modify a book in list
            if (dgvBooks.SelectedRows.Count > 0)
            {
                Book book = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                frmBookEdit editBookForm = new frmBookEdit(book);
                editBookForm.ShowDialog();
                UpdateGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete selected book from DB and update datagrid
            if (dgvBooks.SelectedRows.Count > 0)
            {
                Book book = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                DatabaseController.DeleteBook(book.Id);
            }
            UpdateGrid();
        }

        private void dgvBooks_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedIndex != -1) { return; }
            // Show book detail panel when hovering over a book row
            int row = e.RowIndex;
            if (row < 0) { return; }
            Book book = (Book)dgvBooks.Rows[row].DataBoundItem;
            bookPanel.Populate(book);

        }

        private void dgvBooks_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedIndex != -1) { return; }
            // Hide book detail panel when not hovering over a book row
            bookPanel.Visible = false;
        }
        private void frmBookList_Load(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void dgvBooks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // When a row is selected, show User-available buttons and keep detail panel visible
            if (e.RowIndex == selectedIndex || e.RowIndex == -1)
            {
                ClearSelection();
            }
            else
            {
                selectedIndex = e.RowIndex;
                Book book = (Book)dgvBooks.Rows[selectedIndex].DataBoundItem;
                bookPanel.Populate(book);
                bookPanel.Visible = true;

                // If logged in User is an admin, enable Modify/Delete buttons
                if (isAdmin)
                {
                    btnModify.Visible = true;
                    btnDelete.Visible = true;
                }
                // If logged in User ia a customer, enable Purchase, Review buttons
                else
                {
                    btnPurchase.Visible = true;
                    btnAddToCart.Visible = true;
                }

                btnReviews.Visible = true;
            }
            
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("Please select at least one book");
            }
            
            frmOrderBook bookOrderForm = new frmOrderBook(selectedBooks, userId);
            bookOrderForm.ShowDialog();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            // TODO: Nick
            Book book = (Book)dgvBooks.Rows[selectedIndex].DataBoundItem;
            frmReviews reviewForm = new frmReviews(book.Id);
            reviewForm.ShowDialog();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Book book = (Book)dgvBooks.Rows[selectedIndex].DataBoundItem;
            selectedBooks.Add(book);
            MessageBox.Show("Total " + selectedBooks.Count + " item(s) in the cart.");
        }
    }
}
