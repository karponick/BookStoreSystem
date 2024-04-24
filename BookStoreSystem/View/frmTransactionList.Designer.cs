
namespace BookStoreSystem.View
{
    partial class frmTransactionList
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
            this.listViewTransactions = new System.Windows.Forms.ListView();
            this.flpBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewTransactions
            // 
            this.listViewTransactions.HideSelection = false;
            this.listViewTransactions.Location = new System.Drawing.Point(12, 38);
            this.listViewTransactions.Name = "listViewTransactions";
            this.listViewTransactions.Size = new System.Drawing.Size(612, 173);
            this.listViewTransactions.TabIndex = 0;
            this.listViewTransactions.UseCompatibleStateImageBehavior = false;
            this.listViewTransactions.SelectedIndexChanged += new System.EventHandler(this.listViewTransactions_SelectedIndexChanged);
            // 
            // flpBooks
            // 
            this.flpBooks.Location = new System.Drawing.Point(12, 240);
            this.flpBooks.Name = "flpBooks";
            this.flpBooks.Size = new System.Drawing.Size(612, 237);
            this.flpBooks.TabIndex = 1;
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.Location = new System.Drawing.Point(9, 9);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(90, 17);
            this.lblTransactions.TabIndex = 2;
            this.lblTransactions.Text = "Transactions";
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(12, 214);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(47, 17);
            this.lblBooks.TabIndex = 3;
            this.lblBooks.Text = "Books";
            // 
            // frmTransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 501);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblTransactions);
            this.Controls.Add(this.flpBooks);
            this.Controls.Add(this.listViewTransactions);
            this.Name = "frmTransactionList";
            this.Text = "List of Transactions Made";
            this.Load += new System.EventHandler(this.frmTransactionList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTransactions;
        private System.Windows.Forms.FlowLayoutPanel flpBooks;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Label lblBooks;
    }
}