
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
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.lblSemesterCost = new System.Windows.Forms.Label();
            this.lblSelectedBooks = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
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
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(314, 201);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCost.TabIndex = 17;
            // 
            // lblSemesterCost
            // 
            this.lblSemesterCost.AutoSize = true;
            this.lblSemesterCost.Location = new System.Drawing.Point(232, 204);
            this.lblSemesterCost.Name = "lblSemesterCost";
            this.lblSemesterCost.Size = new System.Drawing.Size(76, 17);
            this.lblSemesterCost.TabIndex = 16;
            this.lblSemesterCost.Text = "Total Cost:";
            // 
            // lblSelectedBooks
            // 
            this.lblSelectedBooks.AutoSize = true;
            this.lblSelectedBooks.Location = new System.Drawing.Point(51, 204);
            this.lblSelectedBooks.Name = "lblSelectedBooks";
            this.lblSelectedBooks.Size = new System.Drawing.Size(106, 17);
            this.lblSelectedBooks.TabIndex = 15;
            this.lblSelectedBooks.Text = "Selected Books";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Location = new System.Drawing.Point(688, 204);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(200, 22);
            this.dtpPurchaseDate.TabIndex = 18;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(576, 206);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(102, 17);
            this.lblPurchaseDate.TabIndex = 19;
            this.lblPurchaseDate.Text = "Purchase Date";
            // 
            // frmOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 669);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.lblSemesterCost);
            this.Controls.Add(this.lblSelectedBooks);
            this.Controls.Add(this.flpCustomersWhoOrdered);
            this.Controls.Add(this.flpListOfBooks);
            this.Name = "frmOrderBook";
            this.Text = "frmOrderBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCustomersWhoOrdered;
        private System.Windows.Forms.FlowLayoutPanel flpListOfBooks;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label lblSemesterCost;
        private System.Windows.Forms.Label lblSelectedBooks;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label lblPurchaseDate;
    }
}