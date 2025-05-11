using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

public static class PDFHelper
    // this class is used to create the various PDFs the user can download or email
{
    private const string BusinessName = "The Atelier Salon";
    private const string BusinessAddress = "123 Beauty Street, Durban";
    private const string BusinessContact = "Phone: (123) 456-7890 | Email: ateliersalon.owner@gmail.com";

    public static MemoryStream GenerateAppointmentConfirmation(Dictionary<string, string> appointmentDetails)
    {
        PdfDocument document = CreateDocument("Appointment Confirmation");
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

        int yPosition = DrawHeader(gfx, "Appointment Confirmation");

        foreach (var entry in appointmentDetails)
        {
            gfx.DrawString($"{entry.Key}: {entry.Value}", font, XBrushes.Black, new XPoint(50, yPosition));
            yPosition += 20;
        }


        MemoryStream pdfStream = new MemoryStream();
        document.Save(pdfStream, false);
        return pdfStream;


    }

    public static MemoryStream GenerateAllAppointmentsSummary(List<Dictionary<string, string>> appointments, string customerSummary)
    {
        PdfDocument document = CreateDocument("All Appointments Summary");
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 6, XFontStyle.Regular);

        int yPosition = DrawHeader(gfx, "Appointments for: " + customerSummary);
        int xPosition = 50;
        int rowHeight = 20;
        //int cellPadding = 5;


        if (appointments.Count > 0)
        {
            // Draw table headers
            var headers = appointments[0].Keys;
            foreach (var header in headers)
            {
                gfx.DrawString(header, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += 80;
            }
            yPosition += rowHeight;
            xPosition = 50;

            // Draw table rows
            foreach (var appointment in appointments)
            {
                foreach (var value in appointment.Values)
                {
                    gfx.DrawString(value, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                    xPosition += 80;
                }
                yPosition += rowHeight;
                xPosition = 50;
            }
        }
        else
        {
            gfx.DrawString("No Appointments Found", font, XBrushes.Black, new XPoint(50, yPosition));
        }

        MemoryStream pdfStream = new MemoryStream();
        document.Save(pdfStream, false);
        return pdfStream;
    }

    public static MemoryStream GenerateDailyAppointmentsReport(List<Dictionary<string, string>> appointments, string date)
    {
        PdfDocument document = CreateDocument($"Appointments for {date}");
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 7, XFontStyle.Regular);

        int yPosition = DrawHeader(gfx, $"Appointments for {date}");

        // Define table headers
        string[] headers = { "AppointmentID",  "Date", "CustomerEmail", "Name", "Stylist", "ProductName", "Accessories",  };
        int[] columnWidths = { 60, 50, 120, 50, 50, 50, 100, };
        int xPosition = 50;
        int rowHeight = 20;

        // Draw table headers
        for (int i = 0; i < headers.Length; i++)
        {
            gfx.DrawString(headers[i], font, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += columnWidths[i];
        }
        yPosition += rowHeight;
        xPosition = 50;

        // Draw table rows
        foreach (var appointment in appointments)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                string value = appointment.ContainsKey(headers[i]) ? appointment[headers[i]] : "";
                gfx.DrawString(value, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += columnWidths[i];
            }
            yPosition += rowHeight;
            xPosition = 50;
        }

        MemoryStream pdfStream = new MemoryStream();
        document.Save(pdfStream, false);
        return pdfStream;
    }

    public static MemoryStream GenerateFinancialReport(List<Dictionary<string, string>> payments, string startDate, string endDate)
    {
        PdfDocument document = CreateDocument($"Financial Report ({startDate} - {endDate})");
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 7, XFontStyle.Regular);
        XFont boldFont = new XFont("Verdana", 7, XFontStyle.Bold);

        int yPosition = DrawHeader(gfx, $"Financial Report ({startDate} - {endDate})");

        int totalRevenue = 0, totalCost = 0;

        // Define table headers
        string[] headers = { "TransactionID", "Date", "CustomerEmail", "TotalAmount", "TotalCost", "ProductName", "Accessories" };
        int[] columnWidths = { 60, 50, 120, 50, 50, 50, 50, 80 };
        int xPosition = 50;
        int rowHeight = 15;
        //int cellPadding = 2;

        // Draw table headers
        for (int i = 0; i < headers.Length; i++)
        {
            gfx.DrawString(headers[i], font, XBrushes.Black, new XPoint(xPosition, yPosition));
            xPosition += columnWidths[i];
        }
        yPosition += rowHeight;
        xPosition = 50;

        // Draw table rows
        foreach (var payment in payments)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                string value = payment.ContainsKey(headers[i]) ? payment[headers[i]] : "";
                gfx.DrawString(value, font, XBrushes.Black, new XPoint(xPosition, yPosition));
                xPosition += columnWidths[i];
            }
            yPosition += rowHeight;
            xPosition = 50;

            if (payment.ContainsKey("TotalAmount") && payment.ContainsKey("TotalCost"))
            {
                totalRevenue += int.Parse(payment["TotalAmount"]);
                totalCost += int.Parse(payment["TotalCost"]);
            }
        }

        int profit = totalRevenue - totalCost;

        yPosition += 20;
        gfx.DrawString($"________________________________________________________________________________________________", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 15;
        gfx.DrawString($"Total Revenue: R{totalRevenue}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 15;
        gfx.DrawString($"Total Cost: R{totalCost}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 15;
        gfx.DrawString($"Total Profit: R{profit}", boldFont, XBrushes.Black, new XPoint(50, yPosition));

        MemoryStream pdfStream = new MemoryStream();
        document.Save(pdfStream, false);
        return pdfStream;
    }

    private static PdfDocument CreateDocument(string title)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = title;
        return document;
    }

    private static int DrawHeader(XGraphics gfx, string title)
    {
        XFont headerFont = new XFont("Verdana", 16, XFontStyle.Bold);
        XFont subFont = new XFont("Verdana", 12, XFontStyle.Regular);

        gfx.DrawString(BusinessName, headerFont, XBrushes.Black, new XPoint(50, 50));
        gfx.DrawString(BusinessAddress, subFont, XBrushes.Black, new XPoint(50, 70));
        gfx.DrawString(BusinessContact, subFont, XBrushes.Black, new XPoint(50, 90));

        gfx.DrawString(title, headerFont, XBrushes.Black, new XPoint(50, 120));

        return 140;
    }

    private static void SaveAndOpen(PdfDocument document, string filePath)
    {
        document.Save(filePath);
        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
    }
}
