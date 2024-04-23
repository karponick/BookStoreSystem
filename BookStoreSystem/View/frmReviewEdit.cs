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
        private int bookId;
        private bool forModification;
        public frmReviewEdit(int bookId)
        {
            this.bookId = bookId;
            forModification = false;
            InitializeComponent();
            // Add event to each check box
            foreach (GroupBox grp in Controls.OfType<GroupBox>())
            {
                foreach (CheckBox chk in grp.Controls.OfType<CheckBox>())
                {
                    chk.CheckedChanged += chk_CheckedChanged;
                }
            }
        }

        public frmReviewEdit(Review review)
        {
            forModification = true;
            InitializeComponent();
            // TODO: Fill in form with existing review data
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
            Review review = new Review(SystemController.CurrentUser.UserID.ToString(), bookId.ToString())
            {
                Description = txtDesc.Text,
                StyleRating = GetRating(gbStyle),
                PlotRating = GetRating(gbPlot),
                CharacterRating = GetRating(gbCharacter)
            };
            if (forModification) { DatabaseController.ModifyReview(review); }
            else { DatabaseController.AddReview(review); }
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
