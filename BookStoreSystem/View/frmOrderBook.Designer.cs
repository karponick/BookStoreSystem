
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
            this.txtSecurityCode = new System.Windows.Forms.TextBox();
            this.lblSecurityCode = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.cbCardType = new System.Windows.Forms.ComboBox();
            this.txtBillingName = new System.Windows.Forms.TextBox();
            this.lblBillingName = new System.Windows.Forms.Label();
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.lblBillingAddress = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.txtZIP = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.txtExpDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpCustomersWhoOrdered
            // 
            this.flpCustomersWhoOrdered.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCustomersWhoOrdered.Location = new System.Drawing.Point(952, 329);
            this.flpCustomersWhoOrdered.Name = "flpCustomersWhoOrdered";
            this.flpCustomersWhoOrdered.Size = new System.Drawing.Size(333, 349);
            this.flpCustomersWhoOrdered.TabIndex = 14;
            // 
            // flpListOfBooks
            // 
            this.flpListOfBooks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpListOfBooks.Location = new System.Drawing.Point(40, 329);
            this.flpListOfBooks.Name = "flpListOfBooks";
            this.flpListOfBooks.Size = new System.Drawing.Size(834, 349);
            this.flpListOfBooks.TabIndex = 13;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(300, 262);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCost.TabIndex = 17;
            // 
            // lblSemesterCost
            // 
            this.lblSemesterCost.AutoSize = true;
            this.lblSemesterCost.Location = new System.Drawing.Point(218, 265);
            this.lblSemesterCost.Name = "lblSemesterCost";
            this.lblSemesterCost.Size = new System.Drawing.Size(76, 17);
            this.lblSemesterCost.TabIndex = 16;
            this.lblSemesterCost.Text = "Total Cost:";
            // 
            // lblSelectedBooks
            // 
            this.lblSelectedBooks.AutoSize = true;
            this.lblSelectedBooks.Location = new System.Drawing.Point(37, 265);
            this.lblSelectedBooks.Name = "lblSelectedBooks";
            this.lblSelectedBooks.Size = new System.Drawing.Size(106, 17);
            this.lblSelectedBooks.TabIndex = 15;
            this.lblSelectedBooks.Text = "Selected Books";
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.Location = new System.Drawing.Point(185, 179);
            this.txtSecurityCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.Size = new System.Drawing.Size(178, 22);
            this.txtSecurityCode.TabIndex = 60;
            // 
            // lblSecurityCode
            // 
            this.lblSecurityCode.AutoSize = true;
            this.lblSecurityCode.Location = new System.Drawing.Point(39, 184);
            this.lblSecurityCode.Name = "lblSecurityCode";
            this.lblSecurityCode.Size = new System.Drawing.Size(96, 17);
            this.lblSecurityCode.TabIndex = 59;
            this.lblSecurityCode.Text = "Security Code";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(185, 107);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(178, 22);
            this.txtCardNo.TabIndex = 56;
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Location = new System.Drawing.Point(39, 146);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(104, 17);
            this.lblExpDate.TabIndex = 54;
            this.lblExpDate.Text = "Expiration Date";
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(39, 112);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(92, 17);
            this.lblCardNo.TabIndex = 53;
            this.lblCardNo.Text = "Card Number";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(39, 81);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(74, 17);
            this.lblCardType.TabIndex = 52;
            this.lblCardType.Text = "Card Type";
            // 
            // cbCardType
            // 
            this.cbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardType.FormattingEnabled = true;
            this.cbCardType.Items.AddRange(new object[] {
            "Visa",
            "Master Card",
            "American Express"});
            this.cbCardType.Location = new System.Drawing.Point(185, 74);
            this.cbCardType.Name = "cbCardType";
            this.cbCardType.Size = new System.Drawing.Size(178, 24);
            this.cbCardType.TabIndex = 62;
            // 
            // txtBillingName
            // 
            this.txtBillingName.Location = new System.Drawing.Point(710, 69);
            this.txtBillingName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBillingName.Name = "txtBillingName";
            this.txtBillingName.Size = new System.Drawing.Size(178, 22);
            this.txtBillingName.TabIndex = 64;
            // 
            // lblBillingName
            // 
            this.lblBillingName.AutoSize = true;
            this.lblBillingName.Location = new System.Drawing.Point(564, 74);
            this.lblBillingName.Name = "lblBillingName";
            this.lblBillingName.Size = new System.Drawing.Size(86, 17);
            this.lblBillingName.TabIndex = 63;
            this.lblBillingName.Text = "Billing Name";
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.Location = new System.Drawing.Point(710, 107);
            this.txtBillingAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.Size = new System.Drawing.Size(178, 22);
            this.txtBillingAddress.TabIndex = 66;
            // 
            // lblBillingAddress
            // 
            this.lblBillingAddress.AutoSize = true;
            this.lblBillingAddress.Location = new System.Drawing.Point(564, 112);
            this.lblBillingAddress.Name = "lblBillingAddress";
            this.lblBillingAddress.Size = new System.Drawing.Size(101, 17);
            this.lblBillingAddress.TabIndex = 65;
            this.lblBillingAddress.Text = "Billing Address";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(565, 151);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(41, 17);
            this.lblState.TabIndex = 67;
            this.lblState.Text = "State";
            // 
            // txtZIP
            // 
            this.txtZIP.Location = new System.Drawing.Point(711, 189);
            this.txtZIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtZIP.Name = "txtZIP";
            this.txtZIP.Size = new System.Drawing.Size(178, 22);
            this.txtZIP.TabIndex = 70;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(565, 194);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(29, 17);
            this.lblZip.TabIndex = 69;
            this.lblZip.Text = "ZIP";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois\t",
            "Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana\tNebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Rhode Island\t",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "Washington DC",
            "West Virginia",
            "Wisconsin",
            "Wyoming"});
            this.cbState.Location = new System.Drawing.Point(710, 151);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(178, 24);
            this.cbState.TabIndex = 71;
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPurchase.Location = new System.Drawing.Point(969, 98);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(316, 65);
            this.btnPurchase.TabIndex = 72;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // txtExpDate
            // 
            this.txtExpDate.Location = new System.Drawing.Point(185, 143);
            this.txtExpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(178, 22);
            this.txtExpDate.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "MMYYYY";
            // 
            // frmOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 746);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExpDate);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.txtZIP);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtBillingAddress);
            this.Controls.Add(this.lblBillingAddress);
            this.Controls.Add(this.txtBillingName);
            this.Controls.Add(this.lblBillingName);
            this.Controls.Add(this.cbCardType);
            this.Controls.Add(this.txtSecurityCode);
            this.Controls.Add(this.lblSecurityCode);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblExpDate);
            this.Controls.Add(this.lblCardNo);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.lblSemesterCost);
            this.Controls.Add(this.lblSelectedBooks);
            this.Controls.Add(this.flpCustomersWhoOrdered);
            this.Controls.Add(this.flpListOfBooks);
            this.Name = "frmOrderBook";
            this.Text = "Book Order";
            this.Load += new System.EventHandler(this.frmOrderBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCustomersWhoOrdered;
        private System.Windows.Forms.FlowLayoutPanel flpListOfBooks;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label lblSemesterCost;
        private System.Windows.Forms.Label lblSelectedBooks;
        private System.Windows.Forms.TextBox txtSecurityCode;
        private System.Windows.Forms.Label lblSecurityCode;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.ComboBox cbCardType;
        private System.Windows.Forms.TextBox txtBillingName;
        private System.Windows.Forms.Label lblBillingName;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Label lblBillingAddress;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtZIP;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.TextBox txtExpDate;
        private System.Windows.Forms.Label label1;
    }
}