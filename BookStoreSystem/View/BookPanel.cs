using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public class BookPanel : FlowLayoutPanel
    {
        /*************************** Fields ***************************/
        private readonly Label title, author, genre, description, pages, price, publication;
        private readonly PictureBox cover;
        private Size defaultCoverSize;
        private readonly int padValue;
        /*************************** Constructors ***************************/
        public BookPanel()
        {
            //MouseEnter += bookPan_MouseEnter;
            //MouseLeave += bookPan_MouseLeave;
            padValue = 5;

            Size = new Size(250, 438);
            Location = new Point(720, 12);
            Padding = new Padding(padValue, padValue, padValue, padValue);
            BorderStyle = BorderStyle.FixedSingle;
            Visible = false;

            title = new Label();
            author = new Label();
            genre = new Label();
            description = new Label();
            pages = new Label();
            price = new Label();
            publication = new Label();


            defaultCoverSize = new Size(Width - padValue * 3 + 2, 203);
            cover = new PictureBox()
            {
                Size = defaultCoverSize,
                SizeMode = PictureBoxSizeMode.Zoom,
            };


            Controls.Add(title);
            Controls.Add(author);
            Controls.Add(genre);
            Controls.Add(description);
            Controls.Add(pages);
            Controls.Add(price);
            Controls.Add(publication);
            Controls.Add(cover);

            foreach (Label lbl in Controls.OfType<Label>())
            {
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Size = new Size(Width - padValue * 3, 20);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
            description.Size = new Size(Width - padValue * 3, 100);
        }

        /*************************** Methods ***************************/
        public void Populate(Book book)
        {
            title.Text = book.Title;
            author.Text = book.Author;
            genre.Text = book.Genre;
            description.Text = book.Description;
            pages.Text = book.Pages.ToString() + " Pages";
            price.Text = "Price: " + book.Price.ToString();
            publication.Text = "Published: " + book.Publication;

            cover.Size = defaultCoverSize;
            if (book.CoverImage == null)
            {
                try
                {
                    cover.Load(book.CoverUrl);
                    //cover.Size = cover.ClientSize;
                    book.CoverImage = cover.Image;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    book.CoverImage = Image.FromFile("placeholder.jpg");
                }
            }
            cover.Image = book.CoverImage;
            
            Visible = true;
        }

        /*************************** Events ***************************/
        private void bookPan_MouseEnter(object sender, EventArgs e)
        {
            Visible = true;
        }
        private void bookPan_MouseLeave(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
