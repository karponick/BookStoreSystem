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
        private readonly Label username, description;
        private readonly Button edit, delete;
        // custom control for star ratings? * * * * * 
        public ReviewPanel(Review review, int tlpWidth)
        {
            // TODO: Get User from System controller and enable/disable buttons based on account matching

            // Main panel properties
            BorderStyle = BorderStyle.Fixed3D;
            Dock = DockStyle.Fill;
            MinimumSize = new Size(0,150);
            MaximumSize = new Size(1000,150);
            BackColor = Color.White;


            /*** Controls (text, ratings, buttons) ***/
            int halfWidth = (int)(tlpWidth * .66);
            username = new Label()
            {
                Text = "Name", // placeholder
                Size = new Size(halfWidth, 20),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(10, 10),
                
            };
            description = new Label()
            {
                Text = review.Description,
                Size = new Size(halfWidth, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, username.Location.Y + username.Height + 5),
            };
            Size buttonSize = new Size(80, 30);
            edit = new Button()
            {
                Text = "Edit",
                Size = buttonSize,
                Location = new Point(description.Location.X + description.Width + 10, 
                description.Location.Y + description.Height - buttonSize.Height)
            };
            edit.Click += edit_Click;
            delete = new Button()
            {
                Text = "Delete",
                Size = buttonSize,
                Location = new Point(edit.Location.X + edit.Width + 10, edit.Location.Y)
            };
            delete.Click += delete_Click;

            // Rating stars
            int y = 10;
            Stars styleRating = new Stars("Style", review.StyleRating, halfWidth)
            {
                Location = new Point(halfWidth, y)
            };
            Stars plotRating = new Stars("Plot", review.PlotRating, halfWidth)
            {
                Location = new Point(halfWidth, y+30)
            };
            Stars charRating = new Stars("Rating", review.CharacterRating, halfWidth)
            {
                Location = new Point(halfWidth, y+60)
            };

            // Add controls to main panel
            Controls.Add(username);
            Controls.Add(description);
            Controls.Add(edit);
            Controls.Add(delete);
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

        }
        private void delete_Click(object sender, EventArgs e)
        {

        }
    }
}
