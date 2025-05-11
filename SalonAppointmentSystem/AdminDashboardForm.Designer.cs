
namespace SalonAppointmentSystem
{
    partial class AdminDashboardForm
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
            this.btnToGenerateReports = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeEmail = new System.Windows.Forms.TextBox();
            this.btnEmailToEmployee = new System.Windows.Forms.Button();
            this.btnEmailBookedAppointments = new System.Windows.Forms.Button();
            this.btnDownloadBookedAppointments = new System.Windows.Forms.Button();
            this.dgvViewDailyAppointments = new System.Windows.Forms.DataGridView();
            this.lblAppointmentsHeader = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDailyAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToGenerateReports
            // 
            this.btnToGenerateReports.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnToGenerateReports.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToGenerateReports.Location = new System.Drawing.Point(606, 9);
            this.btnToGenerateReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnToGenerateReports.Name = "btnToGenerateReports";
            this.btnToGenerateReports.Size = new System.Drawing.Size(183, 45);
            this.btnToGenerateReports.TabIndex = 4;
            this.btnToGenerateReports.Text = "Go To Generate Reports Form";
            this.btnToGenerateReports.UseVisualStyleBackColor = false;
            this.btnToGenerateReports.Click += new System.EventHandler(this.btnToGenerateReports_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmployeeEmail);
            this.groupBox1.Controls.Add(this.btnEmailToEmployee);
            this.groupBox1.Controls.Add(this.btnEmailBookedAppointments);
            this.groupBox1.Controls.Add(this.btnDownloadBookedAppointments);
            this.groupBox1.Controls.Add(this.dgvViewDailyAppointments);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(745, 350);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointments Of The Day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email :";
            // 
            // txtEmployeeEmail
            // 
            this.txtEmployeeEmail.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeEmail.Location = new System.Drawing.Point(599, 292);
            this.txtEmployeeEmail.Name = "txtEmployeeEmail";
            this.txtEmployeeEmail.Size = new System.Drawing.Size(129, 21);
            this.txtEmployeeEmail.TabIndex = 3;
            this.txtEmployeeEmail.TextChanged += new System.EventHandler(this.txtEmployeeEmail_TextChanged);
            // 
            // btnEmailToEmployee
            // 
            this.btnEmailToEmployee.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailToEmployee.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailToEmployee.Location = new System.Drawing.Point(560, 314);
            this.btnEmailToEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailToEmployee.Name = "btnEmailToEmployee";
            this.btnEmailToEmployee.Size = new System.Drawing.Size(168, 24);
            this.btnEmailToEmployee.TabIndex = 2;
            this.btnEmailToEmployee.Text = "Email To Employee";
            this.btnEmailToEmployee.UseVisualStyleBackColor = false;
            this.btnEmailToEmployee.Click += new System.EventHandler(this.btnEmailToEmployee_Click);
            // 
            // btnEmailBookedAppointments
            // 
            this.btnEmailBookedAppointments.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEmailBookedAppointments.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailBookedAppointments.Location = new System.Drawing.Point(320, 295);
            this.btnEmailBookedAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailBookedAppointments.Name = "btnEmailBookedAppointments";
            this.btnEmailBookedAppointments.Size = new System.Drawing.Size(108, 43);
            this.btnEmailBookedAppointments.TabIndex = 2;
            this.btnEmailBookedAppointments.Text = "Email Appointments";
            this.btnEmailBookedAppointments.UseVisualStyleBackColor = false;
            this.btnEmailBookedAppointments.Click += new System.EventHandler(this.btnEmailBookedAppointments_Click);
            // 
            // btnDownloadBookedAppointments
            // 
            this.btnDownloadBookedAppointments.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDownloadBookedAppointments.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadBookedAppointments.Location = new System.Drawing.Point(17, 292);
            this.btnDownloadBookedAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadBookedAppointments.Name = "btnDownloadBookedAppointments";
            this.btnDownloadBookedAppointments.Size = new System.Drawing.Size(122, 43);
            this.btnDownloadBookedAppointments.TabIndex = 1;
            this.btnDownloadBookedAppointments.Text = "Download Appointments";
            this.btnDownloadBookedAppointments.UseVisualStyleBackColor = false;
            this.btnDownloadBookedAppointments.Click += new System.EventHandler(this.btnDownloadBookedAppointments_Click);
            // 
            // dgvViewDailyAppointments
            // 
            this.dgvViewDailyAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewDailyAppointments.Location = new System.Drawing.Point(4, 30);
            this.dgvViewDailyAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViewDailyAppointments.Name = "dgvViewDailyAppointments";
            this.dgvViewDailyAppointments.RowHeadersWidth = 51;
            this.dgvViewDailyAppointments.RowTemplate.Height = 24;
            this.dgvViewDailyAppointments.Size = new System.Drawing.Size(737, 240);
            this.dgvViewDailyAppointments.TabIndex = 0;
            // 
            // lblAppointmentsHeader
            // 
            this.lblAppointmentsHeader.AutoEllipsis = true;
            this.lblAppointmentsHeader.AutoSize = true;
            this.lblAppointmentsHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblAppointmentsHeader.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsHeader.Location = new System.Drawing.Point(169, 56);
            this.lblAppointmentsHeader.Name = "lblAppointmentsHeader";
            this.lblAppointmentsHeader.Size = new System.Drawing.Size(176, 21);
            this.lblAppointmentsHeader.TabIndex = 5;
            this.lblAppointmentsHeader.Text = "Appointment Updates";
            this.lblAppointmentsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalonAppointmentSystem.Properties.Resources._0pagebg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblAppointmentsHeader);
            this.Controls.Add(this.btnToGenerateReports);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDailyAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToGenerateReports;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEmailBookedAppointments;
        private System.Windows.Forms.Button btnDownloadBookedAppointments;
        private System.Windows.Forms.DataGridView dgvViewDailyAppointments;
        private System.Windows.Forms.Label lblAppointmentsHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeEmail;
        private System.Windows.Forms.Button btnEmailToEmployee;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}