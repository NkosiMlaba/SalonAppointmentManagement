
namespace SalonAppointmentSystem
{
    partial class ViewBookingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSecondaryEmail = new System.Windows.Forms.Label();
            this.txtSecondaryEmail = new System.Windows.Forms.TextBox();
            this.btnEmailToSecondaryEmail = new System.Windows.Forms.Button();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnEmailBookings = new System.Windows.Forms.Button();
            this.btnDownloadBookings = new System.Windows.Forms.Button();
            this.btnToClientDashboard = new System.Windows.Forms.Button();
            this.lblBookingsUpdates = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.lblSecondaryEmail);
            this.groupBox1.Controls.Add(this.txtSecondaryEmail);
            this.groupBox1.Controls.Add(this.btnEmailToSecondaryEmail);
            this.groupBox1.Controls.Add(this.dgvBookings);
            this.groupBox1.Controls.Add(this.btnEmailBookings);
            this.groupBox1.Controls.Add(this.btnDownloadBookings);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(778, 351);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Your Bookings In One Place";
            // 
            // lblSecondaryEmail
            // 
            this.lblSecondaryEmail.AutoSize = true;
            this.lblSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondaryEmail.Location = new System.Drawing.Point(507, 298);
            this.lblSecondaryEmail.Name = "lblSecondaryEmail";
            this.lblSecondaryEmail.Size = new System.Drawing.Size(47, 15);
            this.lblSecondaryEmail.TabIndex = 11;
            this.lblSecondaryEmail.Text = "Email :";
            // 
            // txtSecondaryEmail
            // 
            this.txtSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondaryEmail.Location = new System.Drawing.Point(560, 295);
            this.txtSecondaryEmail.Name = "txtSecondaryEmail";
            this.txtSecondaryEmail.Size = new System.Drawing.Size(155, 21);
            this.txtSecondaryEmail.TabIndex = 10;
            this.txtSecondaryEmail.TextChanged += new System.EventHandler(this.txtSecondaryEmail_TextChanged);
            // 
            // btnEmailToSecondaryEmail
            // 
            this.btnEmailToSecondaryEmail.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailToSecondaryEmail.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailToSecondaryEmail.Location = new System.Drawing.Point(529, 322);
            this.btnEmailToSecondaryEmail.Name = "btnEmailToSecondaryEmail";
            this.btnEmailToSecondaryEmail.Size = new System.Drawing.Size(171, 23);
            this.btnEmailToSecondaryEmail.TabIndex = 9;
            this.btnEmailToSecondaryEmail.Text = "Email To Secondary Email";
            this.btnEmailToSecondaryEmail.UseVisualStyleBackColor = false;
            this.btnEmailToSecondaryEmail.Click += new System.EventHandler(this.btnEmailToSecondaryEmail_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(3, 15);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 24;
            this.dgvBookings.Size = new System.Drawing.Size(770, 276);
            this.dgvBookings.TabIndex = 1;
            // 
            // btnEmailBookings
            // 
            this.btnEmailBookings.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailBookings.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailBookings.Location = new System.Drawing.Point(306, 306);
            this.btnEmailBookings.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailBookings.Name = "btnEmailBookings";
            this.btnEmailBookings.Size = new System.Drawing.Size(96, 40);
            this.btnEmailBookings.TabIndex = 8;
            this.btnEmailBookings.Text = "Email To Saved Email";
            this.btnEmailBookings.UseVisualStyleBackColor = false;
            this.btnEmailBookings.Click += new System.EventHandler(this.btnEmailBookings_Click);
            // 
            // btnDownloadBookings
            // 
            this.btnDownloadBookings.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDownloadBookings.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadBookings.Location = new System.Drawing.Point(82, 306);
            this.btnDownloadBookings.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadBookings.Name = "btnDownloadBookings";
            this.btnDownloadBookings.Size = new System.Drawing.Size(96, 40);
            this.btnDownloadBookings.TabIndex = 7;
            this.btnDownloadBookings.Text = "Download";
            this.btnDownloadBookings.UseVisualStyleBackColor = false;
            this.btnDownloadBookings.Click += new System.EventHandler(this.btnDownloadBookings_Click);
            // 
            // btnToClientDashboard
            // 
            this.btnToClientDashboard.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnToClientDashboard.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToClientDashboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnToClientDashboard.Location = new System.Drawing.Point(599, 11);
            this.btnToClientDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnToClientDashboard.Name = "btnToClientDashboard";
            this.btnToClientDashboard.Size = new System.Drawing.Size(190, 41);
            this.btnToClientDashboard.TabIndex = 14;
            this.btnToClientDashboard.Text = "Back To Dashboard";
            this.btnToClientDashboard.UseVisualStyleBackColor = false;
            this.btnToClientDashboard.Click += new System.EventHandler(this.btnToClientDashboard_Click);
            // 
            // lblBookingsUpdates
            // 
            this.lblBookingsUpdates.AutoSize = true;
            this.lblBookingsUpdates.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingsUpdates.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingsUpdates.Location = new System.Drawing.Point(172, 58);
            this.lblBookingsUpdates.Name = "lblBookingsUpdates";
            this.lblBookingsUpdates.Size = new System.Drawing.Size(124, 18);
            this.lblBookingsUpdates.TabIndex = 15;
            this.lblBookingsUpdates.Text = "Bookings Updates";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUser.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 11);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(76, 15);
            this.lblCurrentUser.TabIndex = 23;
            this.lblCurrentUser.Text = "Current User :";
            // 
            // ViewBookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalonAppointmentSystem.Properties.Resources._0pagebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblBookingsUpdates);
            this.Controls.Add(this.btnToClientDashboard);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewBookingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewBookingsForm";
            this.Load += new System.EventHandler(this.ViewBookingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnEmailBookings;
        private System.Windows.Forms.Button btnDownloadBookings;
        private System.Windows.Forms.Button btnToClientDashboard;
        private System.Windows.Forms.Label lblSecondaryEmail;
        private System.Windows.Forms.TextBox txtSecondaryEmail;
        private System.Windows.Forms.Button btnEmailToSecondaryEmail;
        private System.Windows.Forms.Label lblBookingsUpdates;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}