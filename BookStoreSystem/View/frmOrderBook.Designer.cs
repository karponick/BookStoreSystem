
namespace BookStoreSystem.View
{
    partial class frmOrderBook
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
            this.flpCustomersWhoOrdered = new System.Windows.Forms.FlowLayoutPanel();
            this.flpListOfBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpCustomersWhoOrdered
            // 
            this.flpCustomersWhoOrdered.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCustomersWhoOrdered.Location = new System.Drawing.Point(966, 268);
            this.flpCustomersWhoOrdered.Name = "flpCustomersWhoOrdered";
            this.flpCustomersWhoOrdered.Size = new System.Drawing.Size(333, 349);
            this.flpCustomersWhoOrdered.TabIndex = 14;
            // 
            // flpListOfBooks
            // 
            this.flpListOfBooks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpListOfBooks.Location = new System.Drawing.Point(54, 268);
            this.flpListOfBooks.Name = "flpListOfBooks";
            this.flpListOfBooks.Size = new System.Drawing.Size(834, 349);
            this.flpListOfBooks.TabIndex = 13;
            // 
            // frmOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 669);
            this.Controls.Add(this.flpCustomersWhoOrdered);
            this.Controls.Add(this.flpListOfBooks);
            this.Name = "frmOrderBook";
            this.Text = "frmOrderBook";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCustomersWhoOrdered;
        private System.Windows.Forms.FlowLayoutPanel flpListOfBooks;
    }
}