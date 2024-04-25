using BookStoreSystem.Controller;
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
        private Label lblAverageRatings;
        public frmReviews(int bookId)
        {
            InitializeComponent();
            this.bookId = bookId;

            tlpReviews.HorizontalScroll.Maximum = 0;
            tlpReviews.AutoScroll = false;
            tlpReviews.VerticalScroll.Visible = false;
            tlpReviews.AutoScroll = true;

            Text = DatabaseController.GetBookTitle(bookId); // Form title text


            // Add average rating label
            lblAverageRatings = new Label()
            {
                Location = new Point(btnAdd.Location.X + btnAdd.Width + 40, btnAdd.Location.Y + 5),
                Size = btnAdd.Size
            };
            Controls.Add(lblAverageRatings);

            UpdateView();
        }


        /************************** Methods ***************************/
        public void UpdateView()
        {
            tlpReviews.Controls.Clear();
            tlpReviews.RowCount = 0;
            // Get reviews for given book id
            foreach (Review review in DatabaseController.GetReviewList(bookId))
            {
                tlpReviews.Controls.Add(new ReviewPanel(review, tlpReviews.Width) { Parent = this });
            }
            UpdateAverageText();
        }
        private void UpdateAverageText()
        {
            double[] averageRatings = DatabaseController.AverageRatings(bookId);
            lblAverageRatings.Text = string.Format("Average Ratings: \n{3}Style: {0:0.0}\n{3}Plot: {1:0.0}\n{3}Character: {2:0.0}",
                averageRatings[0], averageRatings[1], averageRatings[2], "        ");
        }

        /************************** Events ***************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Review newReview = new Review(SystemController.CurrentUser.UserID.ToString(), bookId.ToString());
            frmReviewEdit reviewEditForm = new frmReviewEdit(newReview, false);
            reviewEditForm.ShowDialog();
            UpdateView();
        }

        private void tlpReviews_ControlRemoved(object sender, ControlEventArgs e)
        {
            UpdateAverageText();
        }
    }
}
