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
    public partial class frmBookEdit : Form
    {
        public frmBookEdit()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            int.TryParse(txtId.Text, out int id);
            int.TryParse(txtPages.Text, out int pages);
            int.TryParse(txtPrice.Text, out int price);
            Book newBook = new Book()
            {
                Id = id,
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = cmbGenre.SelectedText,
                Description = txtDescription.Text,
                Pages = pages,
                Price = price,
                Publication = datePublication.Value.Date,
            };
            frmMenu.DBC.AddBook(newBook);
        }
    }
}
