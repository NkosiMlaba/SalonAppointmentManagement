using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SalonAppointmentSystem
{
    public partial class AdminDashboardForm : Form
    {
        FormManager currentFormManager;
        Admin currentAdmin;
        private MemoryStream pdfStream;
        private DatabaseManager databaseManager = new DatabaseManager();
        private string date = DateTime.Today.ToString("yyyy-MM-dd");
        private ToolTip toolTip = new ToolTip();

        public AdminDashboardForm(FormManager formManager, Admin admin)
        {
            InitializeComponent();
            currentAdmin = admin;
            currentFormManager = formManager;

            // Tooltips
            toolTip.SetToolTip(btnToGenerateReports, "Click to generate reports");
            toolTip.SetToolTip(btnDownloadBookedAppointments, "Click to download the appointments as a PDF");
            toolTip.SetToolTip(btnEmailBookedAppointments, "Click to email the booked appointments to the admin");
            toolTip.SetToolTip(btnEmailToEmployee, "Click to email the booked appointments to the employee");
            toolTip.SetToolTip(txtEmployeeEmail, "Enter the employee's email address");
        }

        private void btnToGenerateReports_Click(object sender, EventArgs e)
        {
            currentFormManager.ShowForm(currentFormManager.generateReportsForm, this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            DisplayAppointmentsByDateInDataGridView(dgvViewDailyAppointments, date);
            GenerateDailyBookingInformation();

        }

        private void btnDownloadBookedAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    lblAppointmentsHeader.Text = "There are no bookings today, Unable to download.";
                    return;
                }
                else
                {
                    lblAppointmentsHeader.Text = "Download or email today's appointments using the buttons below.";
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    saveFileDialog.FileName = "SalonAppointmentsToday.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the in-memory PDF to the selected location
                        File.WriteAllBytes(saveFileDialog.FileName, pdfStream.ToArray());
                        MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (IOException ex) // Catching IOException for file-related errors
            {
                MessageBox.Show($"Error saving PDF: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        private void GenerateDailyBookingInformation()
        {
            try
            {
                List<Dictionary<string, string>> appointments = databaseManager.GetAppointmentsByDate(date);

                if (appointments == null || appointments.Count == 0)
                {
                    // Handle the case where no appointments were found (e.g., return null or an empty stream)
                    lblAppointmentsHeader.Text = "No appointments found for today.";
                    return;
                }
                else
                {
                    lblAppointmentsHeader.Text = "Download or email today's appointments using the buttons below.";
                }

                pdfStream = PDFHelper.GenerateDailyAppointmentsReport(appointments, date);
            }
            catch (Exception ex)
            {
                lblAppointmentsHeader.Text = $"Could not generate bookings. Error: {ex.Message}";
            }
        }

        public void DisplayAppointmentsByDateInDataGridView(DataGridView dgvViewDailyAppointments, string date)
        {
            try
            {
                List<Dictionary<string, string>> appointments = databaseManager.GetAppointmentsByDate(date);

                // Clear existing rows and columns
                dgvViewDailyAppointments.Rows.Clear();
                dgvViewDailyAppointments.Columns.Clear();

                if (appointments.Count > 0)
                {
                    // Add columns based on the dictionary keys
                    foreach (string key in appointments[0].Keys)
                    {
                        dgvViewDailyAppointments.Columns.Add(key, key);
                    }

                    // Add rows with data from the appointments list
                    foreach (var appointment in appointments)
                    {
                        var row = new string[appointment.Count];
                        int i = 0;
                        foreach (var value in appointment.Values)
                        {
                            row[i++] = value;
                        }
                        dgvViewDailyAppointments.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying appointments: {ex.Message}");
            }
        }

        private void btnEmailBookedAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    lblAppointmentsHeader.Text = "There are no bookings today, Unable to email";
                    return;
                }
                else
                {
                    lblAppointmentsHeader.Text = "Download or email today's appointments using the buttons below.";
                }

                if (string.IsNullOrEmpty(currentAdmin?.Email))
                {
                    MessageBox.Show("Admin email is not available. Please check the admin settings.");
                    return;
                }

                // send email to saved email, Email helper has built in exception handling on the SendEmail method!
                EmailHelper.SendDailyAppointmentsEmail(pdfStream, currentAdmin.Email, date);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }

        }

        private void btnEmailToEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    lblAppointmentsHeader.Text = "There are no bookings today, Unable to email";
                    return;
                }
                else
                {
                    lblAppointmentsHeader.Text = "Download or email today's appointments using the buttons below.";
                }

                // Get the secondary email entered by the user
                string secondaryEmail = txtEmployeeEmail.Text?.Trim();

                // Validate that the secondary email is not empty
                if (string.IsNullOrEmpty(secondaryEmail))
                {
                    MessageBox.Show("Secondary email is required.");
                    return;
                }

                // Validate the format of the secondary email
                if (!ValidateClass.IsValidEmail(secondaryEmail))
                {
                    MessageBox.Show("Invalid secondary email format!");
                    return;
                }


                // send email to secondary email
                EmailHelper.SendDailyAppointmentsEmail(pdfStream, secondaryEmail, date);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (currentAdmin != null)
                {
                    lblCurrentUser.Text = "Current User: \n" + currentAdmin.ToString();
                }
                else
                {
                    lblCurrentUser.Text = "Current User: Not available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private void txtEmployeeEmail_TextChanged(object sender, EventArgs e)
        {
            btnEmailToEmployee.Enabled = ValidateClass.IsValidEmail(txtEmployeeEmail.Text.Trim());
        }
    }
}
