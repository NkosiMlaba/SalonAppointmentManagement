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
    public partial class ViewBookingsForm : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;
        private MemoryStream pdfStream;
        private DatabaseManager databaseManager = new DatabaseManager();

        public ViewBookingsForm(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;
        }

        private void btnToClientDashboard_Click(object sender, EventArgs e)
        {
            currentFormManager.ShowForm(currentFormManager.clientDashboardForm, this);
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
            // this was a key challange, as form_shown only works the first time a form is showed, but we show the payment form mulitple times
            base.OnActivated(e);
            DisplayAppointmentsInDataGridView(dgvBookings, currentClient.Email);
            GenerateBookingsInformation();
            
        }

        private void btnDownloadBookings_Click(object sender, EventArgs e)
        {
            // 
            if (pdfStream == null)
            {
                lblBookingsUpdates.Text = "There are no bookings made on this user, Unable to download";
                return;
            }
            else
            {
                lblBookingsUpdates.Text = "You can download or email your bookings by clicking the buttons below";
            }
            
            
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SalonBookings.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // save the in-memory PDF to the selected location
                        File.WriteAllBytes(saveFileDialog.FileName, pdfStream.ToArray());
                        MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving PDF: " + ex.Message);
                    }
                }
            }

            pdfStream.Position = 0;
        }

        private void GenerateBookingsInformation()
        {
            try
            {
                List<Dictionary<string, string>> appointments = databaseManager.GetAppointmentsByCustomerEmail(currentClient.Email);

                if (appointments == null || appointments.Count == 0)
                {
                    // Handle the case where no appointments were found
                    lblBookingsUpdates.Text = "No appointments found for the specified email.";
                    return;
                }
                else
                {
                    lblBookingsUpdates.Text = "You can download or email your bookings by clicking the buttons below";
                }


                string customerSummary = $"{currentClient.Name} {currentClient.Surname}";
                pdfStream = PDFHelper.GenerateAllAppointmentsSummary(appointments, customerSummary);
            }
            catch (Exception)
            {
                lblBookingsUpdates.Text = "Could not generate Bookings";
            }
        }

        public void DisplayAppointmentsInDataGridView(DataGridView dgvBookings, string customerEmail)
        {
            List<Dictionary<string, string>> appointments = databaseManager.GetAppointmentsByCustomerEmail(customerEmail);

            // Clear existing rows
            dgvBookings.Rows.Clear();
            dgvBookings.Columns.Clear();

            if (appointments.Count > 0)
            {
                // Add columns based on the dictionary keys
                foreach (string key in appointments[0].Keys)
                {
                    dgvBookings.Columns.Add(key, key);
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
                    dgvBookings.Rows.Add(row);
                }
            }
        }

        private void btnEmailBookings_Click(object sender, EventArgs e)
        {
            if (pdfStream == null)
            {
                lblBookingsUpdates.Text = "There are no bookings made on this user, Unable to email";
                return;
            }
            else
            {
                lblBookingsUpdates.Text = "You can download or email your bookings by clicking the buttons below";
            }

            // email to primary email
            EmailHelper.SendBookingSummaryEmail(pdfStream, currentClient.Email, currentClient.Name);
        }

        private void btnEmailToSecondaryEmail_Click(object sender, EventArgs e)
        {
            if (pdfStream == null)
            {
                lblBookingsUpdates.Text = "There are no bookings made on this user, Unable to email";
                return;
            }
            else
            {
                lblBookingsUpdates.Text = "You can download or email your bookings by clicking the buttons below";
            }

            string secondaryEmail = txtSecondaryEmail.Text;
            if (string.IsNullOrEmpty(secondaryEmail))
            {
                MessageBox.Show("Enter email");
                return;
            }
            
            if (!ValidateClass.IsValidEmail(secondaryEmail))
            {
                MessageBox.Show("Invalid secondary email format!");
                return;
            }
            
            EmailHelper.SendBookingSummaryEmail(pdfStream, secondaryEmail, currentClient.Name);
        }

        private void ViewBookingsForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();
        }

        private void txtSecondaryEmail_TextChanged(object sender, EventArgs e)
        {
            btnEmailToSecondaryEmail.Enabled = ValidateClass.IsValidEmail(txtSecondaryEmail.Text.Trim());
        }
    }
}
