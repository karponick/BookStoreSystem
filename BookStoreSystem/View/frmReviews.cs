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
    public partial class frmReviews : Form
    {
        private Panel reviewPanel;
        private const int offset = 400;
        public frmReviews(int bookId)
        {
            InitializeComponent();
            // Initialize datagridview properties
            dgvReviews.AutoGenerateColumns = false;
            dgvReviews.ColumnCount = 6;

            dgvReviews.Columns[0].HeaderText = "Username";
            dgvReviews.Columns[1].HeaderText = "Book Title";
            dgvReviews.Columns[2].HeaderText = "Description";
            dgvReviews.Columns[3].HeaderText = "Style Rating";
            dgvReviews.Columns[4].HeaderText = "Plot Rating";
            dgvReviews.Columns[5].HeaderText = "Character Rating";

            dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (Review review in DatabaseController.GetReviewList(bookId))
            {
                dgvReviews.Rows.Add(review.ToArray());
            }

            // Review panel
            reviewPanel = new Panel()
            {
                Size = new Size(offset - 10, dgvReviews.Height),
                Location = new Point(dgvReviews.Location.X + dgvReviews.Width + 10 - offset, dgvReviews.Location.Y),
                BackColor = Color.Red,
                Visible = false,
            };
            Controls.Add(reviewPanel);
        }

        private void frmReviews_Load(object sender, EventArgs e)
        {
            dgvReviews.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!reviewPanel.Visible)
            {
                // SHOW add review panel
                // Shorten dgv width
                dgvReviews.Width -= offset;
                // Show review inputs (Description, 3 ratings - 5 stars each, submit button)
                // button: Minimize review panel 
            }
            else
            {
                // HIDE add review panel
                dgvReviews.Width += offset;

            }
            reviewPanel.Visible = !reviewPanel.Visible;

        }
    }
}
