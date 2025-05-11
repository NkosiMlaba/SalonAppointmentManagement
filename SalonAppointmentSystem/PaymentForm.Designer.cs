
namespace SalonAppointmentSystem
{
    partial class PaymentForm
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
            this.btnDowloadInvoice = new System.Windows.Forms.Button();
            this.btnEmailInvoice = new System.Windows.Forms.Button();
            this.btnPayForAppointment = new System.Windows.Forms.Button();
            this.mtkExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.mtkCVV = new System.Windows.Forms.MaskedTextBox();
            this.mtkCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardHolder = new System.Windows.Forms.TextBox();
            this.rdoCreditCard = new System.Windows.Forms.RadioButton();
            this.rdoDebitCard = new System.Windows.Forms.RadioButton();
            this.btnToThankYouForm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstCosts = new System.Windows.Forms.ListBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnEmailInvoiceToSecondary = new System.Windows.Forms.Button();
            this.txtSecondaryEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDowloadInvoice
            // 
            this.btnDowloadInvoice.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDowloadInvoice.Enabled = false;
            this.btnDowloadInvoice.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDowloadInvoice.Location = new System.Drawing.Point(138, 386);
            this.btnDowloadInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnDowloadInvoice.Name = "btnDowloadInvoice";
            this.btnDowloadInvoice.Size = new System.Drawing.Size(164, 53);
            this.btnDowloadInvoice.TabIndex = 15;
            this.btnDowloadInvoice.Text = "Download Invoice ";
            this.btnDowloadInvoice.UseVisualStyleBackColor = false;
            this.btnDowloadInvoice.Click += new System.EventHandler(this.btnDowloadInvoice_Click);
            // 
            // btnEmailInvoice
            // 
            this.btnEmailInvoice.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailInvoice.Enabled = false;
            this.btnEmailInvoice.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailInvoice.Location = new System.Drawing.Point(323, 386);
            this.btnEmailInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailInvoice.Name = "btnEmailInvoice";
            this.btnEmailInvoice.Size = new System.Drawing.Size(151, 53);
            this.btnEmailInvoice.TabIndex = 14;
            this.btnEmailInvoice.Text = "Email Invoice ";
            this.btnEmailInvoice.UseVisualStyleBackColor = false;
            this.btnEmailInvoice.Click += new System.EventHandler(this.btnEmailInvoice_Click);
            // 
            // btnPayForAppointment
            // 
            this.btnPayForAppointment.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPayForAppointment.Enabled = false;
            this.btnPayForAppointment.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayForAppointment.Location = new System.Drawing.Point(135, 349);
            this.btnPayForAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayForAppointment.Name = "btnPayForAppointment";
            this.btnPayForAppointment.Size = new System.Drawing.Size(535, 24);
            this.btnPayForAppointment.TabIndex = 13;
            this.btnPayForAppointment.Text = "PAY ";
            this.btnPayForAppointment.UseVisualStyleBackColor = false;
            this.btnPayForAppointment.Click += new System.EventHandler(this.btnPayForAppointment_Click);
            // 
            // mtkExpiryDate
            // 
            this.mtkExpiryDate.Location = new System.Drawing.Point(97, 195);
            this.mtkExpiryDate.Margin = new System.Windows.Forms.Padding(2);
            this.mtkExpiryDate.Mask = "00/00";
            this.mtkExpiryDate.Name = "mtkExpiryDate";
            this.mtkExpiryDate.Size = new System.Drawing.Size(45, 21);
            this.mtkExpiryDate.TabIndex = 12;
            this.mtkExpiryDate.TextChanged += new System.EventHandler(this.mtkExpiryDate_TextChanged);
            // 
            // mtkCVV
            // 
            this.mtkCVV.Location = new System.Drawing.Point(97, 168);
            this.mtkCVV.Margin = new System.Windows.Forms.Padding(2);
            this.mtkCVV.Mask = "000";
            this.mtkCVV.Name = "mtkCVV";
            this.mtkCVV.Size = new System.Drawing.Size(35, 21);
            this.mtkCVV.TabIndex = 11;
            this.mtkCVV.TextChanged += new System.EventHandler(this.mtkCVV_TextChanged);
            // 
            // mtkCardNumber
            // 
            this.mtkCardNumber.Location = new System.Drawing.Point(97, 145);
            this.mtkCardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.mtkCardNumber.Mask = "0000-0000-0000-0000";
            this.mtkCardNumber.Name = "mtkCardNumber";
            this.mtkCardNumber.Size = new System.Drawing.Size(153, 21);
            this.mtkCardNumber.TabIndex = 10;
            this.mtkCardNumber.TextChanged += new System.EventHandler(this.mtkCardNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Expiry date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 318);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total Cost :";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCost.Location = new System.Drawing.Point(207, 315);
            this.txtTotalCost.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(105, 21);
            this.txtTotalCost.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cost of your appointment : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "CVV :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Card Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Card Holder : ";
            // 
            // txtCardHolder
            // 
            this.txtCardHolder.Location = new System.Drawing.Point(97, 117);
            this.txtCardHolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Size = new System.Drawing.Size(153, 21);
            this.txtCardHolder.TabIndex = 2;
            this.txtCardHolder.TextChanged += new System.EventHandler(this.txtCardHolder_TextChanged);
            // 
            // rdoCreditCard
            // 
            this.rdoCreditCard.AutoSize = true;
            this.rdoCreditCard.Location = new System.Drawing.Point(14, 60);
            this.rdoCreditCard.Margin = new System.Windows.Forms.Padding(2);
            this.rdoCreditCard.Name = "rdoCreditCard";
            this.rdoCreditCard.Size = new System.Drawing.Size(60, 19);
            this.rdoCreditCard.TabIndex = 1;
            this.rdoCreditCard.TabStop = true;
            this.rdoCreditCard.Text = "Credit ";
            this.rdoCreditCard.UseVisualStyleBackColor = true;
            this.rdoCreditCard.CheckedChanged += new System.EventHandler(this.rdoCreditCard_CheckedChanged);
            // 
            // rdoDebitCard
            // 
            this.rdoDebitCard.AutoSize = true;
            this.rdoDebitCard.Location = new System.Drawing.Point(14, 28);
            this.rdoDebitCard.Margin = new System.Windows.Forms.Padding(2);
            this.rdoDebitCard.Name = "rdoDebitCard";
            this.rdoDebitCard.Size = new System.Drawing.Size(57, 19);
            this.rdoDebitCard.TabIndex = 0;
            this.rdoDebitCard.TabStop = true;
            this.rdoDebitCard.Text = "Debit ";
            this.rdoDebitCard.UseVisualStyleBackColor = true;
            this.rdoDebitCard.CheckedChanged += new System.EventHandler(this.rdoDebitCard_CheckedChanged);
            // 
            // btnToThankYouForm
            // 
            this.btnToThankYouForm.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnToThankYouForm.Enabled = false;
            this.btnToThankYouForm.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToThankYouForm.Location = new System.Drawing.Point(696, 11);
            this.btnToThankYouForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnToThankYouForm.Name = "btnToThankYouForm";
            this.btnToThankYouForm.Size = new System.Drawing.Size(93, 37);
            this.btnToThankYouForm.TabIndex = 16;
            this.btnToThankYouForm.Text = "Next";
            this.btnToThankYouForm.UseVisualStyleBackColor = false;
            this.btnToThankYouForm.Click += new System.EventHandler(this.btnToThankYouForm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.mtkExpiryDate);
            this.groupBox1.Controls.Add(this.mtkCVV);
            this.groupBox1.Controls.Add(this.mtkCardNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCardHolder);
            this.groupBox1.Controls.Add(this.rdoCreditCard);
            this.groupBox1.Controls.Add(this.rdoDebitCard);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(409, 83);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(285, 261);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Your Card Details To Make A Payment";
            // 
            // lstCosts
            // 
            this.lstCosts.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCosts.FormattingEnabled = true;
            this.lstCosts.ItemHeight = 15;
            this.lstCosts.Location = new System.Drawing.Point(137, 83);
            this.lstCosts.Margin = new System.Windows.Forms.Padding(2);
            this.lstCosts.Name = "lstCosts";
            this.lstCosts.Size = new System.Drawing.Size(256, 214);
            this.lstCosts.TabIndex = 8;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUser.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(76, 15);
            this.lblCurrentUser.TabIndex = 23;
            this.lblCurrentUser.Text = "Current User :";
            // 
            // btnEmailInvoiceToSecondary
            // 
            this.btnEmailInvoiceToSecondary.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailInvoiceToSecondary.Enabled = false;
            this.btnEmailInvoiceToSecondary.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailInvoiceToSecondary.Location = new System.Drawing.Point(491, 411);
            this.btnEmailInvoiceToSecondary.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailInvoiceToSecondary.Name = "btnEmailInvoiceToSecondary";
            this.btnEmailInvoiceToSecondary.Size = new System.Drawing.Size(179, 28);
            this.btnEmailInvoiceToSecondary.TabIndex = 14;
            this.btnEmailInvoiceToSecondary.Text = "Email Invoice To Secondary Email";
            this.btnEmailInvoiceToSecondary.UseVisualStyleBackColor = false;
            this.btnEmailInvoiceToSecondary.Click += new System.EventHandler(this.btnEmailInvoiceToSecondary_Click);
            // 
            // txtSecondaryEmail
            // 
            this.txtSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondaryEmail.Location = new System.Drawing.Point(535, 390);
            this.txtSecondaryEmail.Name = "txtSecondaryEmail";
            this.txtSecondaryEmail.Size = new System.Drawing.Size(135, 21);
            this.txtSecondaryEmail.TabIndex = 24;
            this.txtSecondaryEmail.TextChanged += new System.EventHandler(this.txtSecondaryEmail_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(488, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Email :";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalonAppointmentSystem.Properties.Resources._0pagebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSecondaryEmail);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnDowloadInvoice);
            this.Controls.Add(this.btnEmailInvoiceToSecondary);
            this.Controls.Add(this.btnEmailInvoice);
            this.Controls.Add(this.btnPayForAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToThankYouForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstCosts);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDowloadInvoice;
        private System.Windows.Forms.Button btnEmailInvoice;
        private System.Windows.Forms.Button btnPayForAppointment;
        private System.Windows.Forms.MaskedTextBox mtkExpiryDate;
        private System.Windows.Forms.MaskedTextBox mtkCVV;
        private System.Windows.Forms.MaskedTextBox mtkCardNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCardHolder;
        private System.Windows.Forms.RadioButton rdoCreditCard;
        private System.Windows.Forms.RadioButton rdoDebitCard;
        private System.Windows.Forms.Button btnToThankYouForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstCosts;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnEmailInvoiceToSecondary;
        private System.Windows.Forms.TextBox txtSecondaryEmail;
        private System.Windows.Forms.Label label7;
    }
}