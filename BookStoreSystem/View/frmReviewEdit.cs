using BookStoreSystem.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreSystem.View
{
    public partial class frmReviewEdit : Form
    {
        private bool checkLock = false;
        private bool forModification;
        private int reviewIdForMod;
        private Review review;

        public frmReviewEdit(Review review, bool forModification)
        {
            this.review = review;
            this.forModification = forModification;
            InitializeComponent();
            InitializeCheckEvents();

            if (forModification) 
            {
                reviewIdForMod = review.Id;
                txtDesc.Text = review.Description;
                gbStyle.Controls.OfType<CheckBox>().ToList()[5 - review.StyleRating].Checked = true;
                gbPlot.Controls.OfType<CheckBox>().ToList()[5 - review.PlotRating].Checked = true;
                gbCharacter.Controls.OfType<CheckBox>().ToList()[5 - review.CharacterRating].Checked = true;
            }
        }

        private void InitializeCheckEvents()
        {
            // Add event to each check box
            foreach (GroupBox grp in Controls.OfType<GroupBox>())
            {
                foreach (CheckBox chk in grp.Controls.OfType<CheckBox>())
                {
                    chk.CheckedChanged += chk_CheckedChanged;
                }
            }
        }


        private int GetRating(GroupBox group)
        {
            int rating = 0;
            // Get rating for given groupbox
            foreach (CheckBox chk in group.Controls.OfType<CheckBox>())
            {
                if (chk.Checked) rating++;
            }
            return rating;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // validate inputs
            int styleRating = GetRating(gbStyle);
            int plotRating = GetRating(gbPlot);
            int characterRating = GetRating(gbCharacter);

            if (styleRating == 0 || plotRating == 0 || characterRating == 0) { MessageBox.Show("Invalid: Missing ratings"); return; }
            if (txtDesc.Text == string.Empty) { MessageBox.Show("Invalid: Missing description"); return; }


            // create review
            Review newReview = new Review(SystemController.CurrentUser.UserID.ToString(), review.BookId.ToString())
            {
                Description = txtDesc.Text,
                StyleRating = styleRating,
                PlotRating = plotRating,
                CharacterRating = characterRating
            };
            if (forModification)
            {
                newReview.Id = reviewIdForMod;
                newReview.LastEditDateTime = DateTime.UtcNow.ToString();
                DatabaseController.ModifyReview(newReview);
            }
            else
            {
                newReview.SubmissionDateTime = DateTime.UtcNow.ToString();
                DatabaseController.AddReview(newReview); 
            }
            Close();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLock) return;
            checkLock = true;
            CheckBox clickedChk = sender as CheckBox;
            // figure out which groupbox checkbox is a child of (parent property wasn't work
            List<CheckBox> chkList = clickedChk.Parent.Controls.OfType<CheckBox>().ToList();

            foreach (CheckBox chk in chkList)
            {
                chk.Checked = false;
            }
            for (int i = 4; i >= 4 - clickedChk.TabIndex; i--)
            {
                chkList[i].Checked = true;
            }
            checkLock = false;
        }
    }
}
