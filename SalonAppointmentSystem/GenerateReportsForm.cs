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
    public partial class GenerateReportsForm : Form
    {
        FormManager currentFormManager;
        Admin currentAdmin;
        private MemoryStream pdfStream;
        private DatabaseManager databaseManager = new DatabaseManager();

        string startDate;
        string endDate;

        public GenerateReportsForm(FormManager formManager, Admin admin)
        {
            InitializeComponent();
            currentAdmin = admin;
            currentFormManager = formManager;

        }

        private void btnToDashboard_Click(object sender, EventArgs e)
        {
            currentFormManager.ShowForm(currentFormManager.adminDashboardForm, this);
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

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {
            if (pdfStream == null)
            {
                MessageBox.Show("Please generate PDF first");
                return;
            }
            
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SalonFinancialReport.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Save the in-memory PDF to the selected location
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

        private bool GenerateFinancialReportInformation()
        {
            try
            {

                
                List<Dictionary<string, string>> paidAppointments = databaseManager.GetPaymentsByDateRange(startDate, endDate);

                if (paidAppointments == null || paidAppointments.Count == 0)
                {
                    // Handle the case where no appointments were found (e.g., return null or an empty stream)
                    MessageBox.Show("No financial information found.");
                    return false;
                }


                string adminSummary = $"{currentAdmin.Name} {currentAdmin.Surname} ({currentAdmin.Email})";
                pdfStream = PDFHelper.GenerateFinancialReport(paidAppointments, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Could not generate Bookings");
                return false;
            }

            return true;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            startDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");
            bool financialInfoAvailable = GenerateFinancialReportInformation();

            if (financialInfoAvailable)
            {
                // Enable buttons
                txtSecondaryEmail.Enabled = true;
                btnDownloadReport.Enabled = true;
                btnEmailReport.Enabled = true;
                btnEmailSecondaryEmail.Enabled = true;

                MessageBox.Show("Financial Report generated, " + Environment.NewLine + "proceed to Download or Email below");
            }
            else
            {
                MessageBox.Show("Financial Report could not be generated, " + Environment.NewLine + "invalid date range or there is no financial data available for specified date range");
            }

            
        }

        private void btnEmailReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    MessageBox.Show("Please generate PDF first");
                    return;
                }

                // email PDF to saved email
                EmailHelper.SendFinancialReportEmail(pdfStream, currentAdmin.Email, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Error sending email");
            }
        }

        private void btnEmailSecondaryEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    MessageBox.Show("Please generate PDF first");
                    return;
                }

                string secondaryEmail = txtSecondaryEmail.Text.Trim();
                
                // Validate if email is not empty
                if (string.IsNullOrEmpty(secondaryEmail))
                {
                    MessageBox.Show("Secondary email address is required.");
                    return; 
                }

                // Validate email format
                if (!ValidateClass.IsValidEmail(secondaryEmail))
                {
                    MessageBox.Show("Invalid secondary email format. Please enter a valid email address.");
                    return;  // Stop further execution if email format is invalid
                }

                // send email
                EmailHelper.SendFinancialReportEmail(pdfStream, secondaryEmail, startDate, endDate);
            }
            catch
            {
                MessageBox.Show("Error Sending Financial Report Email");
            }
        }

        private void GenerateReportsForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentAdmin.ToString();
        }

        private void txtSecondaryEmail_TextChanged(object sender, EventArgs e)
        {
            btnEmailSecondaryEmail.Enabled = ValidateClass.IsValidEmail(txtSecondaryEmail.Text.Trim()) && pdfStream != null;
        }
    }
}
