namespace BookStoreSystem
{
    partial class frmBookEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPublication = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtPublication = new System.Windows.Forms.TextBox();
            this.txtCoverUrl = new System.Windows.Forms.TextBox();
            this.lblCoverUrl = new System.Windows.Forms.Label();
            this.picCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(118, 10);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(118, 36);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 20);
            this.txtAuthor.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(118, 89);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(118, 115);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(200, 20);
            this.txtPages.TabIndex = 4;
            this.txtPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(118, 141);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(52, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 20);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(52, 35);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(60, 20);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "Author";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGenre
            // 
            this.lblGenre.Location = new System.Drawing.Point(52, 62);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(60, 20);
            this.lblGenre.TabIndex = 10;
            this.lblGenre.Text = "Genre";
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(52, 88);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 20);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPages
            // 
            this.lblPages.Location = new System.Drawing.Point(52, 115);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(60, 20);
            this.lblPages.TabIndex = 12;
            this.lblPages.Text = "Pages";
            this.lblPages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(52, 141);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(60, 20);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPublication
            // 
            this.lblPublication.Location = new System.Drawing.Point(12, 167);
            this.lblPublication.Name = "lblPublication";
            this.lblPublication.Size = new System.Drawing.Size(100, 20);
            this.lblPublication.TabIndex = 14;
            this.lblPublication.Text = "Publication Year";
            this.lblPublication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "Fantasy",
            "History",
            "Drama",
            "Non-Fiction",
            "Science-Fiction",
            "Fairy Tale",
            "Poetry",
            "Historical Fiction",
            "Folklore",
            "Fable Fiction",
            "Horror",
            "Humor",
            "Mystery",
            "Mythology",
            "Biography"});
            this.cmbGenre.Location = new System.Drawing.Point(118, 62);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(200, 21);
            this.cmbGenre.TabIndex = 15;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(116, 225);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(202, 23);
            this.btnSubmit.TabIndex = 17;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtPublication
            // 
            this.txtPublication.Location = new System.Drawing.Point(118, 167);
            this.txtPublication.Name = "txtPublication";
            this.txtPublication.Size = new System.Drawing.Size(200, 20);
            this.txtPublication.TabIndex = 18;
            this.txtPublication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_TextChanged);
            // 
            // txtCoverUrl
            // 
            this.txtCoverUrl.Location = new System.Drawing.Point(118, 193);
            this.txtCoverUrl.Name = "txtCoverUrl";
            this.txtCoverUrl.Size = new System.Drawing.Size(200, 20);
            this.txtCoverUrl.TabIndex = 20;
            this.txtCoverUrl.TextChanged += new System.EventHandler(this.txtCoverUrl_TextChanged);
            // 
            // lblCoverUrl
            // 
            this.lblCoverUrl.Location = new System.Drawing.Point(12, 193);
            this.lblCoverUrl.Name = "lblCoverUrl";
            this.lblCoverUrl.Size = new System.Drawing.Size(100, 20);
            this.lblCoverUrl.TabIndex = 19;
            this.lblCoverUrl.Text = "Cover Image Url";
            this.lblCoverUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(324, 10);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(150, 203);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 21;
            this.picCover.TabStop = false;
            // 
            // frmBookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 261);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.txtCoverUrl);
            this.Controls.Add(this.lblCoverUrl);
            this.Controls.Add(this.txtPublication);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.lblPublication);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookEdit";
            this.Text = "Book Editing Tool";
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPublication;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtPublication;
        private System.Windows.Forms.TextBox txtCoverUrl;
        private System.Windows.Forms.Label lblCoverUrl;
        private System.Windows.Forms.PictureBox picCover;
    }
}