using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem
{
    public partial class frmBookEdit : Form
    {
        /*************************** Fields ***************************/
        private readonly bool forModification;
        private int id;
        /************************ Constructors ************************/
        public frmBookEdit()
        {
            // Constructor for ADDING a new book
            // Information is initially empty
            InitializeComponent();
            forModification = false;
        }
        public frmBookEdit(Book book)
        {
            // Constructor for MODIFYING an existing book
            // Fills in existing information
            InitializeComponent();
            forModification = true;

            id = book.Id;
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            cmbGenre.SelectedIndex = cmbGenre.Items.IndexOf(book.Genre);
            txtDescription.Text = book.Description;
            txtPages.Text = book.Pages.ToString();
            txtPrice.Text = book.Price.ToString();
            txtPublication.Text = book.Publication;
            txtCoverUrl.Text = book.CoverUrl;
        }

        /*************************** Events ***************************/
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Create Book object using values from Form inputs
            int.TryParse(txtPages.Text, out int pages);
            double.TryParse(txtPrice.Text, out double price);
            Book book = new Book()
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Description = txtDescription.Text,
                Pages = pages,
                Price = price,
                Publication = txtPublication.Text,
                CoverUrl = txtCoverUrl.Text
            };
            if (cmbGenre.SelectedIndex != -1) { book.Genre = cmbGenre.SelectedItem.ToString(); }

            // Either MODIFY existing book or ADD new book
            if (forModification) { book.Id = id; DatabaseController.ModifyBook(book); }
            else { DatabaseController.AddBook(book); }
            Close();
        }

        private void txtCoverUrl_TextChanged(object sender, EventArgs e)
        {
            // Try to load Cover image from Url when the url text is changed
            try
            {
                picCover.Load(txtCoverUrl.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                picCover.Image = Image.FromFile("placeholder.jpg");
            }
        }
    }
}
