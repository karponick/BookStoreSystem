using BookStoreSystem.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public class ReviewPanel : Panel
    {
        private Label username, description, times;
        private Button edit, delete;
        private Review review;
        private int tlpWidth;
        // custom control for star ratings? * * * * * 
        public ReviewPanel(Review review, int tlpWidth)
        {
            this.review = review;
            this.tlpWidth = tlpWidth;

            // Main panel properties
            BorderStyle = BorderStyle.Fixed3D;
            Dock = DockStyle.Fill;
            MinimumSize = new Size(0,180);
            BackColor = Color.LightGoldenrodYellow;
            Margin = new Padding(15,15,30,15);

            PopulatePanel();
        }

        private void PopulatePanel()
        {
            Controls.Clear();
            /*** Controls (text, ratings, buttons) ***/
            int halfWidth = (int)(tlpWidth * .66);
            username = new Label()
            {
                Text = DatabaseController.GetUsername(review.UserId),
                Size = new Size(halfWidth / 2, 20),
                //BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(10, 10),
            };
            description = new Label()
            {
                Text = review.Description,
                Size = new Size(halfWidth - 10, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Wheat,
                Location = new Point(10, username.Location.Y + username.Height + 5),
            };
            times = new Label()
            {
                Text = "Submitted: " + review.SubmissionDateTime,
                Size = new Size(halfWidth / 2, 30),
                //BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, description.Location.Y + description.Height + 5)
            };
            if (review.LastEditDateTime != string.Empty) { times.Text += "\nLast Edit: " + review.LastEditDateTime; }


            Size buttonSize = new Size(50, 30);
            edit = new Button()
            {
                Text = "Edit",
                Size = buttonSize,
                Location = new Point(description.Location.X + description.Width - buttonSize.Width * 2 - 5,
                                     times.Location.Y)
            };
            edit.Click += edit_Click;
            delete = new Button()
            {
                Text = "Delete",
                Size = buttonSize,
                Location = new Point(edit.Location.X + edit.Width + 5, edit.Location.Y)
            };
            delete.Click += delete_Click;

            // Rating stars
            int x = halfWidth - 20;
            int y = description.Location.Y;
            Stars styleRating = new Stars("Style", review.StyleRating, halfWidth)
            {
                Location = new Point(x, y)
            };
            Stars plotRating = new Stars("Plot", review.PlotRating, halfWidth)
            {
                Location = new Point(x, y + 30)
            };
            Stars charRating = new Stars("Rating", review.CharacterRating, halfWidth)
            {
                Location = new Point(x, y + 60)
            };

            // Add controls to main panel
            Controls.Add(username);
            Controls.Add(description);
            Controls.Add(times);
            // Only add edit/delete buttons if it's from logged in account
            if (review.UserId == SystemController.CurrentUser.UserID)
            {
                Controls.Add(edit);
                Controls.Add(delete);
            }
            Controls.Add(styleRating);
            Controls.Add(plotRating);
            Controls.Add(charRating);
        }

        // Star class for ratings
        private class Stars : FlowLayoutPanel
        {
            private Size starSize = new Size(20, 20);
            public Stars(string category, int value, int width)
            {
                Size = new Size(width - 50, 30);

                Label text = new Label()
                {
                    Text = category,
                    Padding = new Padding(5, 5, 0, 0),
                    AutoSize = false,
                    Size = new Size(60, 20),
                    TextAlign = ContentAlignment.MiddleRight
                };
                Controls.Add(text);
                for (int i = 1; i <= 5; i++)
                {
                    Label star = new Label()
                    {
                        Size = starSize,
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(0, 8, 2, 0),
                    };
                    if (i <= value) { star.BackColor = Color.Gold; }
                    else { star.BackColor = Color.White; }
                    Controls.Add(star);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // Open ReviewEdit form with existing review details
            frmReviewEdit editReviewForm = new frmReviewEdit(review, true);
            editReviewForm.ShowDialog();

            review = DatabaseController.GetReview(review.Id);
            PopulatePanel();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            DatabaseController.DeleteReview(review.Id);
            Parent.Controls.Remove(this);
        }
    }
}
