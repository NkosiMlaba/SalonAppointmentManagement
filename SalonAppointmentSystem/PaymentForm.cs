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
    public partial class PaymentForm : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;
        private DatabaseManager database = new DatabaseManager();
        private decimal total = 0;
        private decimal totalCost = 0;
        private MemoryStream pdfStream;
        private ToolTip toolTip = new ToolTip();


        public PaymentForm(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;

            // Disable all textboxes initially
            txtCardHolder.Enabled = false;
            txtSecondaryEmail.Enabled = false;
            mtkCardNumber.Enabled = false;
            mtkCVV.Enabled = false;
            mtkExpiryDate.Enabled = false;

            // Add tooltips
            toolTip.SetToolTip(groupBox1, "Enter card details");
            toolTip.SetToolTip(rdoDebitCard, "Choose card type");
            toolTip.SetToolTip(rdoCreditCard, "Choose card type");
            toolTip.SetToolTip(txtCardHolder, "Enter the name on the card");
            toolTip.SetToolTip(mtkCardNumber, "Enter the 16-digit card number");
            toolTip.SetToolTip(mtkCVV, "Enter the 3-digit CCV code");
            toolTip.SetToolTip(mtkExpiryDate, "Enter expiry date (MM/YY)");

        }

        private void btnToThankYouForm_Click(object sender, EventArgs e)
        {
            // reset values
            ResetValues();

            // Thank you form
            currentFormManager.ShowForm(currentFormManager.thankYouForm, this);
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

        private void btnPayForAppointment_Click(object sender, EventArgs e)
        {
            string cardHolder = txtCardHolder.Text;
            string cardNumber = mtkCardNumber.Text;
            string cardExpiry = mtkExpiryDate.Text;
            string cardCVV = mtkCVV.Text;

            // secondary text validation, already have text validation in mtkTextChanged events
            if (!(rdoCreditCard.Checked || rdoDebitCard.Checked))
            {
                MessageBox.Show("Select one payment method");
                return;
            }

            if (string.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Enter valid card holder details");
                return;
            }


            try
            {
                // store appointment
                if (currentAppointment.CurrentStyleChosen["ProductType"] == "Hairstyle")
                {
                    // insert appointment
                    var accessories = String.Join(", ", currentClient.CurrentChosenHairAccessories.ToArray());
                    database.InsertAppointment(currentClient.CurrentAppointmentDate, currentClient.CurrentAppointmentTime, currentClient.Email, currentClient.Name,
                    currentClient.Surname, currentAppointment.CurrentStyleChosen["ProductType"], currentAppointment.CurrentStyleChosen["ProductName"],
                    accessories, currentClient.CurrentAppointmentStylist);


                    // store payment
                    database.InsertPayment(currentClient.Email, (int)total, (int)totalCost, currentAppointment.CurrentStyleChosen["ProductName"],
                        accessories, currentClient.CurrentAppointmentDate, currentClient.CurrentAppointmentTime);


                    // appointment dictionary
                    Dictionary<string, string> appointmentDetails = new Dictionary<string, string>
                {
                    { "Customer", $"{currentClient.Name} {currentClient.Surname} ({currentClient.Email})" },
                    { "Stylist", currentClient.CurrentAppointmentStylist},
                    { "Date", currentClient.CurrentAppointmentDate },
                    { "Time", currentClient.CurrentAppointmentTime },
                    { "Service", currentAppointment.CurrentStyleChosen["ProductName"] },
                    { "Accessories", accessories},
                    { "Total", "R" + total}
                };

                    // generate pdf of invoice
                    pdfStream = PDFHelper.GenerateAppointmentConfirmation(appointmentDetails);
                }
                else
                {
                    // insert appointment
                    var accessories = String.Join(", ", currentClient.CurrentChosenNailAccessories.ToArray());
                    database.InsertAppointment(currentClient.CurrentAppointmentDate, currentClient.CurrentAppointmentTime, currentClient.Email, currentClient.Name,
                    currentClient.Surname, currentAppointment.CurrentStyleChosen["ProductType"], currentAppointment.CurrentStyleChosen["ProductName"],
                    accessories, currentClient.CurrentAppointmentStylist);

                    // insert payment to database
                    database.InsertPayment(currentClient.Email, (int)total, (int)totalCost, currentAppointment.CurrentStyleChosen["ProductName"],
                        accessories, currentClient.CurrentAppointmentDate, currentClient.CurrentAppointmentTime);

                    // appointment dictionary
                    Dictionary<string, string> appointmentDetails = new Dictionary<string, string>
                {
                    { "Customer", $"{currentClient.Name} {currentClient.Surname}" },
                    { "Stylist", currentClient.CurrentAppointmentStylist},
                    { "Date", currentClient.CurrentAppointmentDate },
                    { "Time", currentClient.CurrentAppointmentTime },
                    { "Service", currentAppointment.CurrentStyleChosen["ProductName"] },
                    { "Accessories", accessories},
                    { "Total", "R" + total}
                };


                    // generate pdf of invoice
                    pdfStream = PDFHelper.GenerateAppointmentConfirmation(appointmentDetails);
                }
            }
            catch
            {
                MessageBox.Show("Error occured in store payment block");
            }

            // Successful payment
            MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // enable download, email and next
            txtSecondaryEmail.Enabled = true;
            btnDowloadInvoice.Enabled = true;
            btnEmailInvoice.Enabled = true;
            btnToThankYouForm.Enabled = true;
            btnEmailInvoiceToSecondary.Enabled = true;
            btnPayForAppointment.Enabled = false;
        }

        private void loadProductInformation()
        {
            currentAppointment.CurrentStyleChosen = new Dictionary<string, string>();
            currentAppointment.Accessory1 = new Dictionary<string, string>();
            currentAppointment.Accessory2 = new Dictionary<string, string>();
            currentAppointment.Accessory3 = new Dictionary<string, string>();
            currentAppointment.Accessory4 = new Dictionary<string, string>();


            if (currentClient.CurrentChosenHairStyle != "" && currentClient.CurrentChosenHairStyle != null)
            {
                currentAppointment.CurrentStyleChosen = FetchFromDatabase(currentClient.CurrentChosenHairStyle);
                if (currentClient.CurrentChosenHairAccessories.Count > 0)
                {
                    currentAppointment.Accessory1 = FetchFromDatabase(currentClient.CurrentChosenHairAccessories.ElementAt(0));
                }
                if (currentClient.CurrentChosenHairAccessories.Count > 1)
                {
                    currentAppointment.Accessory2 = FetchFromDatabase(currentClient.CurrentChosenHairAccessories.ElementAt(1));
                }
                if (currentClient.CurrentChosenHairAccessories.Count > 2)
                {
                    currentAppointment.Accessory3 = FetchFromDatabase(currentClient.CurrentChosenHairAccessories.ElementAt(2));
                }
            }
            else
            {
                currentAppointment.CurrentStyleChosen = FetchFromDatabase(currentClient.CurrentChosenNailStyle);
                if (currentClient.CurrentChosenNailAccessories.Count > 0)
                {
                    currentAppointment.Accessory1 = FetchFromDatabase(currentClient.CurrentChosenNailAccessories.ElementAt(0));
                }
                if (currentClient.CurrentChosenNailAccessories.Count > 1)
                {
                    currentAppointment.Accessory2 = FetchFromDatabase(currentClient.CurrentChosenNailAccessories.ElementAt(1));
                }
                if (currentClient.CurrentChosenNailAccessories.Count > 2)
                {
                    currentAppointment.Accessory3 = FetchFromDatabase(currentClient.CurrentChosenNailAccessories.ElementAt(2));
                }
                if (currentClient.CurrentChosenNailAccessories.Count > 3)
                {
                    currentAppointment.Accessory4 = FetchFromDatabase(currentClient.CurrentChosenNailAccessories.ElementAt(3));
                }
            }  
        }


        private Dictionary<string, string> FetchFromDatabase(string itemInfoRequired)
        {
            var item = database.GetCatalogueItemByName(itemInfoRequired);
            if (item != null)
            {
                string productType = item["ProductType"];
                int sellingPrice = int.Parse(item["SellingPrice"]);
                int costPrice = int.Parse(item["CostPrice"]);
            }
            return item;
        }

        private void EnterDataIntoListBox()
        {
            lstCosts.Items.Clear();
            lstCosts.Items.Add("Style Chosen:");
            lstCosts.Items.Add(new string('-', 100));

            if (currentAppointment.CurrentStyleChosen != null)
            {
                lstCosts.Items.Add(string.Format("{0,-20} {1,10:C}", currentAppointment.CurrentStyleChosen["ProductName"], Convert.ToDecimal(currentAppointment.CurrentStyleChosen["SellingPrice"])));
            }
            lstCosts.Items.Add(new string('-', 100));

            lstCosts.Items.Add("");
            lstCosts.Items.Add(Environment.NewLine);
            lstCosts.Items.Add("Accessories:");
            lstCosts.Items.Add(new string('-', 100));
            if (currentAppointment.Accessory1 != null && currentAppointment.Accessory1.Count > 0)
            {
                lstCosts.Items.Add(string.Format("{0,-20} {1,10:C}", currentAppointment.Accessory1["ProductName"], Convert.ToDecimal(currentAppointment.Accessory1["SellingPrice"])));
            }
            if (currentAppointment.Accessory2 != null && currentAppointment.Accessory2.Count > 0)
            {
                lstCosts.Items.Add(string.Format("{0,-20} {1,10:C}", currentAppointment.Accessory2["ProductName"], Convert.ToDecimal(currentAppointment.Accessory2["SellingPrice"])));
            }
            if (currentAppointment.Accessory3 != null && currentAppointment.Accessory3.Count > 0)
            {
                lstCosts.Items.Add(string.Format("{0,-20} {1,10:C}", currentAppointment.Accessory3["ProductName"], Convert.ToDecimal(currentAppointment.Accessory3["SellingPrice"])));
            }
            if (currentAppointment.Accessory4 != null && currentAppointment.Accessory4.Count > 0)
            {
                lstCosts.Items.Add(string.Format("{0,-20} {1,10:C}", currentAppointment.Accessory4["ProductName"], Convert.ToDecimal(currentAppointment.Accessory4["SellingPrice"])));
            }
            lstCosts.Items.Add(new string('-', 100));
        }

        private void CalculateTotal()
        {
            total = 0;
            totalCost = 0;
            if (currentAppointment.CurrentStyleChosen != null)
            {
                total += Convert.ToDecimal(currentAppointment.CurrentStyleChosen["SellingPrice"]);
                totalCost += Convert.ToDecimal(currentAppointment.CurrentStyleChosen["CostPrice"]);
            }
            if (currentAppointment.Accessory1 != null && currentAppointment.Accessory1.Count > 0)
            {
                total += Convert.ToDecimal(currentAppointment.Accessory1["SellingPrice"]);
                totalCost += Convert.ToDecimal(currentAppointment.Accessory1["CostPrice"]);
            }
            if (currentAppointment.Accessory2 != null && currentAppointment.Accessory2.Count > 0)
            {
                total += Convert.ToDecimal(currentAppointment.Accessory2["SellingPrice"]);
                totalCost += Convert.ToDecimal(currentAppointment.Accessory2["CostPrice"]);
            }
            if (currentAppointment.Accessory3 != null && currentAppointment.Accessory3.Count > 0)
            {
                total += Convert.ToDecimal(currentAppointment.Accessory3["SellingPrice"]);
                totalCost += Convert.ToDecimal(currentAppointment.Accessory3["CostPrice"]);
            }
            if (currentAppointment.Accessory4 != null && currentAppointment.Accessory4.Count > 0)
            {
                total += Convert.ToDecimal(currentAppointment.Accessory4["SellingPrice"]);
                totalCost += Convert.ToDecimal(currentAppointment.Accessory4["CostPrice"]);
            }
            txtTotalCost.Text = total.ToString("C");
        }

        private void ResetValues()
        {
            // reset values
            btnDowloadInvoice.Enabled = false;
            btnEmailInvoice.Enabled = false;
            btnToThankYouForm.Enabled = false;
            btnPayForAppointment.Enabled = false;
            btnEmailInvoiceToSecondary.Enabled = false;

            // clear cost list box
            lstCosts.Items.Clear();

            // clear text fields
            txtTotalCost.Text = "";
            txtCardHolder.Text = "";
            mtkCardNumber.Clear();
            mtkCVV.Clear();
            mtkExpiryDate.Clear();
        }

        protected override void OnActivated(EventArgs e)
        {
            // this was a key challange, as form_shown only works the first time a form is showed, but we show the payment form mulitple times
            base.OnActivated(e);
            loadProductInformation();
            EnterDataIntoListBox();
            CalculateTotal();
        }

        private void btnDowloadInvoice_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SalonInvoice.pdf";

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

        private void btnEmailInvoiceToSecondary_Click(object sender, EventArgs e)
        {
            if (pdfStream == null)
            {
                return;
            }

            string secondaryEmail = txtSecondaryEmail.Text;

            // validate if email is not empty
            if (string.IsNullOrEmpty(secondaryEmail))
            {
                MessageBox.Show("Secondary email address is required.");
                return;
            }

            // validate email format
            if (!ValidateClass.IsValidEmail(secondaryEmail))
            {
                MessageBox.Show("Invalid secondary email format. Please enter a valid email address.");
                return;
            }

            try
            {
                EmailHelper.SendInvoiceEmail(pdfStream, secondaryEmail, currentClient.Name, currentAppointment.CurrentStyleChosen["ProductName"], total);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }

        }

        private void btnEmailInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdfStream == null)
                {
                    MessageBox.Show("No PDF file available to send.");
                    return;
                }

                // Email to primary email
                EmailHelper.SendInvoiceEmail(pdfStream, currentClient.Email, currentClient.Name, currentAppointment.CurrentStyleChosen["ProductName"], total);
            }
            catch
            {
                MessageBox.Show("Error in sending email method");
            }

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();
        }

        private void txtCardHolder_TextChanged(object sender, EventArgs e)
        {
            string cardHolderText = txtCardHolder.Text.Trim();
            
            if (cardHolderText.Length < 1)
            {
                mtkCardNumber.Enabled = false;
            }
            else
            {
                mtkCardNumber.Enabled = true;
            }
        }

        private void mtkCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (mtkCardNumber.MaskFull)
            {
                mtkCVV.Enabled = true;
            }
            else
            {
                mtkCVV.Enabled = false;
                mtkExpiryDate.Enabled = false;
            }
        }

        private void mtkCVV_TextChanged(object sender, EventArgs e)
        {
            if (mtkCVV.MaskFull)
            {
                mtkExpiryDate.Enabled = true;
            }
            else
            {
                mtkExpiryDate.Enabled = false;
            }
        }

        private void mtkExpiryDate_TextChanged(object sender, EventArgs e)
        {
            if (mtkExpiryDate.MaskFull)
            {
                btnPayForAppointment.Enabled = true;
            }
            else
            {
                btnPayForAppointment.Enabled = false;
            }
        }

        private void txtSecondaryEmail_TextChanged(object sender, EventArgs e)
        {
            btnEmailInvoiceToSecondary.Enabled = ValidateClass.IsValidEmail(txtSecondaryEmail.Text.Trim());
        }

        private void rdoDebitCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCreditCard.Checked || rdoDebitCard.Checked)
            {
                txtCardHolder.Enabled = true;
            }
            else
            {
                txtCardHolder.Enabled = false;
            }
        }

        private void rdoCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCreditCard.Checked || rdoDebitCard.Checked)
            {
                txtCardHolder.Enabled = true;
            }
            else
            {
                txtCardHolder.Enabled = false;
            }
        }
    }
}
