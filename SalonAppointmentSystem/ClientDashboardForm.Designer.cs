
namespace SalonAppointmentSystem
{
    partial class ClientDashboardForm
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
            this.btnViewAppointments = new System.Windows.Forms.Button();
            this.rdoNails = new System.Windows.Forms.RadioButton();
            this.rdoHair = new System.Windows.Forms.RadioButton();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewAppointments
            // 
            this.btnViewAppointments.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnViewAppointments.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAppointments.Location = new System.Drawing.Point(587, 11);
            this.btnViewAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewAppointments.Name = "btnViewAppointments";
            this.btnViewAppointments.Size = new System.Drawing.Size(202, 56);
            this.btnViewAppointments.TabIndex = 11;
            this.btnViewAppointments.Text = "View Appointments";
            this.btnViewAppointments.UseVisualStyleBackColor = false;
            this.btnViewAppointments.Click += new System.EventHandler(this.btnViewAppointments_Click);
            // 
            // rdoNails
            // 
            this.rdoNails.AutoSize = true;
            this.rdoNails.Checked = true;
            this.rdoNails.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNails.Location = new System.Drawing.Point(213, 299);
            this.rdoNails.Margin = new System.Windows.Forms.Padding(2);
            this.rdoNails.Name = "rdoNails";
            this.rdoNails.Size = new System.Drawing.Size(60, 22);
            this.rdoNails.TabIndex = 8;
            this.rdoNails.TabStop = true;
            this.rdoNails.Text = "Nails";
            this.rdoNails.UseVisualStyleBackColor = true;
            // 
            // rdoHair
            // 
            this.rdoHair.AutoSize = true;
            this.rdoHair.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoHair.Location = new System.Drawing.Point(521, 299);
            this.rdoHair.Margin = new System.Windows.Forms.Padding(2);
            this.rdoHair.Name = "rdoHair";
            this.rdoHair.Size = new System.Drawing.Size(57, 22);
            this.rdoHair.TabIndex = 9;
            this.rdoHair.Text = "Hair";
            this.rdoHair.UseVisualStyleBackColor = true;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnMakeBooking.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeBooking.Location = new System.Drawing.Point(337, 333);
            this.btnMakeBooking.Margin = new System.Windows.Forms.Padding(2);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(107, 35);
            this.btnMakeBooking.TabIndex = 7;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = false;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rdoNails);
            this.groupBox1.Controls.Add(this.rdoHair);
            this.groupBox1.Controls.Add(this.btnMakeBooking);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(761, 378);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please Choose Hair or Nails Below To Make Your Booking :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SalonAppointmentSystem.Properties.Resources.ig__ednnamaartinss;
            this.pictureBox2.Location = new System.Drawing.Point(441, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(246, 273);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SalonAppointmentSystem.Properties.Resources.Soft_Nails;
            this.pictureBox1.Location = new System.Drawing.Point(119, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUser.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 15);
            this.lblCurrentUser.TabIndex = 23;
            this.lblCurrentUser.Text = "Current User";
            // 
            // ClientDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalonAppointmentSystem.Properties.Resources._0pagebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnViewAppointments);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientDashboardForm";
            this.Load += new System.EventHandler(this.ClientDashboardForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewAppointments;
        private System.Windows.Forms.RadioButton rdoNails;
        private System.Windows.Forms.RadioButton rdoHair;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}