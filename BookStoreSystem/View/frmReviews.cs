using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public partial class frmReviews : Form
    {
        private int bookId;
        public frmReviews(int bookId)
        {
            InitializeComponent();
            this.bookId = bookId;

            Text = DatabaseController.GetBookTitle(bookId); // Form title text
            UpdateView();
        }


        /************************** Methods ***************************/
        private void UpdateView()
        {
            tlpReviews.RowCount = 0;
            // Get reviews for given book id
            foreach (Review review in DatabaseController.GetReviewList(bookId))
            {
                tlpReviews.Controls.Add(new ReviewPanel(review, tlpReviews.Width), column: 0, row: tlpReviews.RowCount);
            }
        }

        /************************** Events ***************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmReviewEdit reviewEditForm = new frmReviewEdit(bookId);
            reviewEditForm.ShowDialog();
            UpdateView();
        }
    }
}
