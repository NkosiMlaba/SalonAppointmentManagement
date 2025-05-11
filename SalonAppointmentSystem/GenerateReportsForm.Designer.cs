
namespace SalonAppointmentSystem
{
    partial class GenerateReportsForm
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
            this.btnToDashboard = new System.Windows.Forms.Button();
            this.btnEmailReport = new System.Windows.Forms.Button();
            this.btnDownloadReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnEmailSecondaryEmail = new System.Windows.Forms.Button();
            this.lblSecondaryEmail = new System.Windows.Forms.Label();
            this.txtSecondaryEmail = new System.Windows.Forms.TextBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToDashboard
            // 
            this.btnToDashboard.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnToDashboard.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToDashboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnToDashboard.Location = new System.Drawing.Point(616, 11);
            this.btnToDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnToDashboard.Name = "btnToDashboard";
            this.btnToDashboard.Size = new System.Drawing.Size(173, 48);
            this.btnToDashboard.TabIndex = 13;
            this.btnToDashboard.Text = "Back To Dashboard";
            this.btnToDashboard.UseVisualStyleBackColor = false;
            this.btnToDashboard.Click += new System.EventHandler(this.btnToDashboard_Click);
            // 
            // btnEmailReport
            // 
            this.btnEmailReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailReport.Enabled = false;
            this.btnEmailReport.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailReport.Location = new System.Drawing.Point(341, 298);
            this.btnEmailReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailReport.Name = "btnEmailReport";
            this.btnEmailReport.Size = new System.Drawing.Size(96, 40);
            this.btnEmailReport.TabIndex = 18;
            this.btnEmailReport.Text = "Email Report";
            this.btnEmailReport.UseVisualStyleBackColor = false;
            this.btnEmailReport.Click += new System.EventHandler(this.btnEmailReport_Click);
            // 
            // btnDownloadReport
            // 
            this.btnDownloadReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDownloadReport.Enabled = false;
            this.btnDownloadReport.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadReport.Location = new System.Drawing.Point(134, 293);
            this.btnDownloadReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadReport.Name = "btnDownloadReport";
            this.btnDownloadReport.Size = new System.Drawing.Size(96, 45);
            this.btnDownloadReport.TabIndex = 17;
            this.btnDownloadReport.Text = "Download Report";
            this.btnDownloadReport.UseVisualStyleBackColor = false;
            this.btnDownloadReport.Click += new System.EventHandler(this.btnDownloadReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "End Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(413, 67);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEndDate.MinDate = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(198, 21);
            this.dtpEndDate.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGenerateReport);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(778, 156);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Financial Reports";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(134, 67);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.MinDate = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(203, 21);
            this.dtpStartDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starting Date :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnGenerateReport.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(317, 103);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(109, 40);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnEmailSecondaryEmail
            // 
            this.btnEmailSecondaryEmail.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailSecondaryEmail.Enabled = false;
            this.btnEmailSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailSecondaryEmail.Location = new System.Drawing.Point(511, 293);
            this.btnEmailSecondaryEmail.Name = "btnEmailSecondaryEmail";
            this.btnEmailSecondaryEmail.Size = new System.Drawing.Size(141, 45);
            this.btnEmailSecondaryEmail.TabIndex = 19;
            this.btnEmailSecondaryEmail.Text = "Email Report To Secondary Email";
            this.btnEmailSecondaryEmail.UseVisualStyleBackColor = false;
            this.btnEmailSecondaryEmail.Click += new System.EventHandler(this.btnEmailSecondaryEmail_Click);
            // 
            // lblSecondaryEmail
            // 
            this.lblSecondaryEmail.AutoSize = true;
            this.lblSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondaryEmail.Location = new System.Drawing.Point(482, 269);
            this.lblSecondaryEmail.Name = "lblSecondaryEmail";
            this.lblSecondaryEmail.Size = new System.Drawing.Size(44, 15);
            this.lblSecondaryEmail.TabIndex = 20;
            this.lblSecondaryEmail.Text = "Email :";
            // 
            // txtSecondaryEmail
            // 
            this.txtSecondaryEmail.Enabled = false;
            this.txtSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondaryEmail.Location = new System.Drawing.Point(532, 267);
            this.txtSecondaryEmail.Name = "txtSecondaryEmail";
            this.txtSecondaryEmail.Size = new System.Drawing.Size(130, 20);
            this.txtSecondaryEmail.TabIndex = 21;
            this.txtSecondaryEmail.TextChanged += new System.EventHandler(this.txtSecondaryEmail_TextChanged);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUser.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 15);
            this.lblCurrentUser.TabIndex = 22;
            this.lblCurrentUser.Text = "Current User";
            // 
            // GenerateReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalonAppointmentSystem.Properties.Resources._0pagebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.txtSecondaryEmail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSecondaryEmail);
            this.Controls.Add(this.btnToDashboard);
            this.Controls.Add(this.btnEmailSecondaryEmail);
            this.Controls.Add(this.btnEmailReport);
            this.Controls.Add(this.btnDownloadReport);
            this.Name = "GenerateReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateReportsForm";
            this.Load += new System.EventHandler(this.GenerateReportsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToDashboard;
        private System.Windows.Forms.Button btnEmailReport;
        private System.Windows.Forms.Button btnDownloadReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnEmailSecondaryEmail;
        private System.Windows.Forms.Label lblSecondaryEmail;
        private System.Windows.Forms.TextBox txtSecondaryEmail;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}