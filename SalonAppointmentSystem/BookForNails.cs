using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonAppointmentSystem
{
    public partial class BookForNails : Form
    {

        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;

        private string nailStyle;
        private List<string> accessoriesList = new List<string>();

        private ToolTip priceToolTip = new ToolTip();
        private Dictionary<string, string> productsAndPrice = new Dictionary<string, string>();
        DatabaseManager databaseManager = new DatabaseManager();


        public BookForNails(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;

            SetProductPrices();
            SetToolTips();
        }

        private void btnToNailAppointment_Click(object sender, EventArgs e)
        {
            // clear previous values
            currentClient.CurrentAppointmentStylist = null;
            currentClient.CurrentChosenHairAccessories = null;
            currentClient.CurrentChosenHairStyle = null;
            currentClient.CurrentChosenNailAccessories = null;
            currentClient.CurrentChosenNailStyle = null;
            currentClient.CurrentAppointmentTime = null;

            // add to client data
            currentClient.CurrentChosenNailAccessories = accessoriesList;
            currentClient.CurrentChosenNailStyle = nailStyle;

            // reset current form values
            ResetValues();

            // nail appointment form
            currentFormManager.ShowForm(currentFormManager.nailAppointmentTimeForm, this);
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

        private void btnChooseNailStyle_Click(object sender, EventArgs e)
        {
            if (nailStyle == null)
            {
                MessageBox.Show("Choose nail style");
                return;
            }

            // next section
            grpNailAccessories.Enabled = true;

            // disable current button
            btnChooseNailStyle.Enabled = false;

        }

        private void picNailCoffin_Click(object sender, EventArgs e)
        {
            picNailCoffin.BorderStyle = BorderStyle.Fixed3D;
            nailStyle = "Coffin";

            picNailAlmond.BorderStyle = BorderStyle.None;
            picNailSquare.BorderStyle = BorderStyle.None;
            picNailStiletto.BorderStyle = BorderStyle.None;
        }

        private void picNailAlmond_Click(object sender, EventArgs e)
        {
            picNailAlmond.BorderStyle = BorderStyle.Fixed3D;
            nailStyle = "Almond";

            picNailCoffin.BorderStyle = BorderStyle.None;
            picNailSquare.BorderStyle = BorderStyle.None;
            picNailStiletto.BorderStyle = BorderStyle.None;
        }

        private void picNailSquare_Click(object sender, EventArgs e)
        {
            picNailSquare.BorderStyle = BorderStyle.Fixed3D;
            nailStyle = "Square";

            picNailStiletto.BorderStyle = BorderStyle.None;
            picNailCoffin.BorderStyle = BorderStyle.None;
            picNailAlmond.BorderStyle = BorderStyle.None;
        }

        private void picNailStiletto_Click(object sender, EventArgs e)
        {
            picNailStiletto.BorderStyle = BorderStyle.Fixed3D;
            nailStyle = "Stiletto";

            picNailSquare.BorderStyle = BorderStyle.None;
            picNailCoffin.BorderStyle = BorderStyle.None;
            picNailAlmond.BorderStyle = BorderStyle.None;
        }

        private void btnChooseAccessories_Click(object sender, EventArgs e)
        {
            List<string> localAccessoryList = new List<string>();
            if (chkChrome.Checked)
            {
                localAccessoryList.Add("Chromes");
            }
            if (chkNailart.Checked)
            {
                localAccessoryList.Add("Nail art");
            }
            if (chkPearls.Checked)
            {
                localAccessoryList.Add("Pearls");
            }
            if (chkRhinestones.Checked)
            {
                localAccessoryList.Add("Rhine stones");
            }

            accessoriesList = localAccessoryList;
            // next section
            btnToNailAppointment.Enabled = true;

            // disable current button
            btnChooseAccessories.Enabled = false;
        }

        private void ResetValues()
        {
            // reset current variables in this form
            nailStyle = string.Empty;
            accessoriesList = new List<string>();

            // uncheck checkboxes
            UncheckCheckboxes();


            // unselect image
            UnselectImages();

            // Disable controls
            grpNailAccessories.Enabled = false;
            btnToNailAppointment.Enabled = false;

            // enable buttons
            btnChooseNailStyle.Enabled = true;
            btnChooseAccessories.Enabled = true;
        }


        private void UncheckCheckboxes()
        {
            foreach (Control grpBox in this.Controls)
            {
                if (grpBox is GroupBox mainPanel)
                {
                    foreach (Control subControl in mainPanel.Controls)
                    {
                        if (subControl is CheckBox checkBox)
                        {
                            checkBox.Checked = false;
                        }
                    }
                }
            }
        }

        private void UnselectImages()
        {
            foreach (Control grpBox in this.Controls)
            {
                if (grpBox is GroupBox mainPanel)
                {
                    foreach (Control subControl in mainPanel.Controls)
                    {
                        if (subControl is TableLayoutPanel)
                        {
                            foreach (Control pictureBox in subControl.Controls)
                            {
                                if (pictureBox is PictureBox pic)
                                {
                                    pic.BorderStyle = BorderStyle.None;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BookForNails_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();
        }

        private void SetToolTips()
        {
            priceToolTip.SetToolTip(picNailStiletto, $"Stiletto nails: R{productsAndPrice["Stiletto"]}");
            priceToolTip.SetToolTip(picNailCoffin, $"Coffin nails: R{productsAndPrice["Coffin"]}");
            priceToolTip.SetToolTip(picNailSquare, $"Square nails: R{productsAndPrice["Square"]}");
            priceToolTip.SetToolTip(picNailAlmond, $"Almond nails: R{productsAndPrice["Almond"]}");

            priceToolTip.SetToolTip(chkChrome, $"Chromes accessory: R{productsAndPrice["Chromes"]}");
            priceToolTip.SetToolTip(chkNailart, $"Nail art accessory: R{productsAndPrice["Nail art"]}");
            priceToolTip.SetToolTip(chkPearls, $"Pearls accessory: R{productsAndPrice["Pearls"]}");
            priceToolTip.SetToolTip(chkRhinestones, $"Rhine stones accessory: R{productsAndPrice["Rhine stones"]}");
        }

        private void SetProductPrices()
        {
            productsAndPrice = databaseManager.GetCatalogueItemsWithPrices();
        }

        private void btnToClientDashboard_Click(object sender, EventArgs e)
        {
            currentFormManager.ShowForm(currentFormManager.clientDashboardForm, this);
        }
    }
}
