using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Collections.Generic;
using SalonAppointmentSystem;

public static class EmailHelper
// this class is responsible for sending the various emails and contains methods with email content
{

    public static void SendInvoiceEmail(MemoryStream pdfStream, string email, string customerName, string service, decimal amount)
    {
        string subject = "Your Salon Invoice";
        string body = $@"
            <h2>Thank You for Booking an Appointment at The Atelier Salon!</h2>
            <p>Dear {customerName},</p>
            <p>We hope you will love your service! Attached is your invoice for your appointment.</p>
            <p><strong>Service:</strong> {service}</p>
            <p><strong>Amount:</strong> R{amount}</p>
            <p><strong>Date booked:</strong> {DateTime.Now.ToShortDateString()}</p>
            <p>We look forward to seeing you soon for your appointment!</p>
            <p>Best Regards,</p>
            <p><strong>The Atelier Salon</strong></p>";

        SendEmail(pdfStream, subject, body, "Invoice.pdf", email);
    }

    public static void SendFinancialReportEmail(MemoryStream pdfStream, string email, string startDate, string endDate)
    {
        string subject = $"Financial Report ({startDate} - {endDate})";
        string body = $@"
            <h2>Salon Financial Report</h2>
            <p>Dear Administrator,</p>
            <p>Please find attached the financial report for the period {startDate} - {endDate}.</p>
            <p>Best Regards,</p>
            <p><strong>The Atelier Salon</strong></p>";

        SendEmail(pdfStream, subject, body, "FinancialReport.pdf", email);
    }

    public static void SendBookingSummaryEmail(MemoryStream pdfStream, string email, string customerName)
    {
        string subject = "Your Salon Booking Summary";
        string body = $@"
            <h2>Your Booking Summary</h2>
            <p>Dear {customerName},</p>
            <p>Attached is the summary of your upcoming and past appointments with The Atelier Salon.</p>
            <p>If you have any questions or need to make changes, please contact us.</p>
            <p>Best Regards,</p>
            <p><strong>The Atelier Salon</strong></p>";

        SendEmail(pdfStream, subject, body, "BookingSummary.pdf", email);
    }

    public static void SendDailyAppointmentsEmail(MemoryStream pdfStream, string email, string date)
    {
        string subject = $"Daily Appointment Schedule - {date}";
        string body = $@"
            <h2>Daily Appointments for {date}</h2>
            <p>Dear Administrator,</p>
            <p>Attached is the appointment schedule for today.</p>
            <p>Please review the schedule to ensure all stylists are prepared and that inventory is stocked.</p>
            <p>Best Regards,</p>
            <p><strong>The Atelier Salon</strong></p>";

        SendEmail(pdfStream, subject, body, "DailyAppointments.pdf", email);
    }

    private static void SendEmail(MemoryStream pdfStream, string subject, string body, string attachmentName, string email)
    {
        try
        {
            // load SMTP configuration
            var config = SmtpConfig.LoadConfig();
            if (config == null)
            {
                throw new Exception("Configuration file is empty or incorrectly formatted.");
            }

            // create Email Message
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(config.Username),
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            };

            mail.To.Add(email);

            // attach PDF
            pdfStream.Position = 0;
            Attachment attachment = new Attachment(pdfStream, attachmentName, "application/pdf");
            mail.Attachments.Add(attachment);

            // SMTP Client Setup
            SmtpClient smtpClient = new SmtpClient(config.Server, config.Port)
            {
                Credentials = new NetworkCredential(config.Username, config.Password),
                EnableSsl = config.EnableSSL
            };

            // send Email
            smtpClient.Send(mail);
            MessageBox.Show($"Email sent successfully to {email}!");
        }
        catch
        {
            MessageBox.Show("Error sending email: Please make sure you have an active internet connection");
        }
    }


}
