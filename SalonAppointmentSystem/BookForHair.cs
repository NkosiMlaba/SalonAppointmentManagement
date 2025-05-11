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
    public partial class BookForHair : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;

        private string hairstlye;
        private List<string> accessoriesList = new List<string>();

        private ToolTip priceToolTip = new ToolTip();
        private Dictionary<string, string> productsAndPrice = new Dictionary<string, string>();
        DatabaseManager databaseManager = new DatabaseManager();

        public BookForHair(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;

            SetProductPrices();
            SetToolTips();
        }

        private void btnToChooseHairAppointment_Click(object sender, EventArgs e)
        {
            // clear previous values
            currentClient.CurrentAppointmentStylist = null;
            currentClient.CurrentChosenHairAccessories = null;
            currentClient.CurrentChosenHairStyle = null;
            currentClient.CurrentChosenNailAccessories = null;
            currentClient.CurrentChosenNailStyle = null;
            currentClient.CurrentAppointmentTime = null;

            // set values to objects
            currentClient.CurrentChosenHairAccessories = accessoriesList;
            currentClient.CurrentChosenHairStyle = hairstlye;

            // reset current form values
            ResetValues();

            // Hair appointment form switching
            currentFormManager.ShowForm(currentFormManager.hairAppointmentTimeForm, this);
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

        private void BookForHair_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();

            string gender = currentClient.Gender?.Trim().ToLower();

            if (gender == "male")
            {
                CenterGroupBox(grpHairstylesMale, 41);
                CenterGroupBox(grpHairMaleAccessories, 355);
                grpHairstylesMale.Enabled = true;
                grpHairstylesMale.Visible = true;

                grpHairstylesFemale.Visible = false;
                grpHairstylesFemale.Enabled = false;
                grpHairFemaleAccessories.Visible = false;
            }
            else if (gender == "female")
            {
                CenterGroupBox(grpHairstylesFemale, 41);
                CenterGroupBox(grpHairFemaleAccessories, 355);
                grpHairstylesFemale.Enabled = true;
                grpHairstylesFemale.Visible = true;

                grpHairstylesMale.Enabled = false;
                grpHairstylesMale.Visible = false;
                grpHairMaleAccessories.Visible = false;
            }
            else
            {
                MessageBox.Show($"Could not detect gender.\nRaw value was: '{currentClient.Gender}'");
            }
        }

        private void CenterGroupBox(GroupBox groupBox, int yPosition)
        {
            // Center horizontally and vertically within the form
            int x = (this.ClientSize.Width - groupBox.Width) / 2;
            int y = yPosition; // Do not change
            groupBox.Location = new Point(x, y);
        }

        private void picFemaleCornrows_Click(object sender, EventArgs e)
        {
            picFemaleCornrows.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Cornrows";

            picFemaleFulanibraids.BorderStyle = BorderStyle.None;
            picFemaleKnotlessbraids.BorderStyle = BorderStyle.None;
            picFemaleLayeredcut.BorderStyle = BorderStyle.None;

        }

        private void picFemaleKnotlessbraids_Click(object sender, EventArgs e)
        {
            picFemaleKnotlessbraids.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Knotless braids";

            picFemaleFulanibraids.BorderStyle = BorderStyle.None;
            picFemaleCornrows.BorderStyle = BorderStyle.None;
            picFemaleLayeredcut.BorderStyle = BorderStyle.None;
        }

        private void picFemaleLayeredcut_Click(object sender, EventArgs e)
        {
            picFemaleLayeredcut.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Layered cut";

            picFemaleFulanibraids.BorderStyle = BorderStyle.None;
            picFemaleCornrows.BorderStyle = BorderStyle.None;
            picFemaleKnotlessbraids.BorderStyle = BorderStyle.None;
        }

        private void picFemaleFulanibraids_Click(object sender, EventArgs e)
        {
            picFemaleFulanibraids.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Fulani braids";

            picFemaleLayeredcut.BorderStyle = BorderStyle.None;
            picFemaleCornrows.BorderStyle = BorderStyle.None;
            picFemaleKnotlessbraids.BorderStyle = BorderStyle.None;
        }

        private void picMaleFadecut_Click(object sender, EventArgs e)
        {
            picMaleFadecut.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Fade cut";

            picMaleBuzzcut.BorderStyle = BorderStyle.None;
            picMaleBirdsnest.BorderStyle = BorderStyle.None;
            picMaleUndercut.BorderStyle = BorderStyle.None;
        }

        private void picMaleUndercut_Click(object sender, EventArgs e)
        {
            picMaleUndercut.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Under cut";

            picMaleBuzzcut.BorderStyle = BorderStyle.None;
            picMaleBirdsnest.BorderStyle = BorderStyle.None;
            picMaleFadecut.BorderStyle = BorderStyle.None;
        }

        private void picMaleBuzzcut_Click(object sender, EventArgs e)
        {
            picMaleBuzzcut.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Buzz cut";

            picMaleUndercut.BorderStyle = BorderStyle.None;
            picMaleBirdsnest.BorderStyle = BorderStyle.None;
            picMaleFadecut.BorderStyle = BorderStyle.None;
        }

        private void picMaleBirdsnest_Click(object sender, EventArgs e)
        {
            picMaleBirdsnest.BorderStyle = BorderStyle.Fixed3D;
            hairstlye = "Birds nest";

            picMaleUndercut.BorderStyle = BorderStyle.None;
            picMaleBuzzcut.BorderStyle = BorderStyle.None;
            picMaleFadecut.BorderStyle = BorderStyle.None;
        }

        private void btnChooseFemaleHairstyle_Click(object sender, EventArgs e)
        {
            if (hairstlye == null || hairstlye == "")
            {
                MessageBox.Show("Choose hairstyle style");
                return;
            }

            // enable next section
            grpHairFemaleAccessories.Enabled = true;

            // disable current button
            btnChooseFemaleHairstyle.Enabled = false;
        }

        private void btnChooseMaleHairstyle_Click(object sender, EventArgs e)
        {
            if (hairstlye == null || hairstlye == "")
            {
                MessageBox.Show("Choose hairstyle style");
                return;
            }

            // enable next section
            grpHairMaleAccessories.Enabled = true;

            // disable current button
            btnChooseMaleHairstyle.Enabled = false;


        }

        private void btnChooseFemaleAccessories_Click(object sender, EventArgs e)
        {
            List<string> localAccessoryList = new List<string>();
            if (chkFemaleBeads.Checked)
            {
                localAccessoryList.Add("Beads");
            }
            if (chkFemaleCurls.Checked)
            {
                localAccessoryList.Add("Curls");
            }
            if (chkFemaleHighlights.Checked)
            {
                localAccessoryList.Add("Highlights");
            }

            accessoriesList = localAccessoryList;
            btnToChooseHairAppointment.Enabled = true;

            // disable current button
            btnChooseFemaleAccessories.Enabled = false;
        }

        private void btnChooseMaleAccessories_Click(object sender, EventArgs e)
        {
            List<string> localAccessoryList = new List<string>();
            if (chkMaleHairdye.Checked)
            {
                localAccessoryList.Add("Hair dye");
            }
            if (chkMaleHairpart.Checked)
            {
                localAccessoryList.Add("Hair part");
            }
            if (chkMaleWaves.Checked)
            {
                localAccessoryList.Add("Waves");
            }

            accessoriesList = localAccessoryList;
            btnToChooseHairAppointment.Enabled = true;

            // disable current button
            btnChooseMaleAccessories.Enabled = false;
        }

        private void ResetValues()
        {
            // reset current variables in this form
            hairstlye = string.Empty;
            accessoriesList = new List<string>();

            // uncheck checkboxes
            UncheckCheckboxes();


            // unselect image
            UnselectImages();

            // Disable controls
            grpHairFemaleAccessories.Enabled = false;
            grpHairMaleAccessories.Enabled = false;
            btnToChooseHairAppointment.Enabled = false;

            // enable buttons
            btnChooseFemaleHairstyle.Enabled = true;
            btnChooseMaleHairstyle.Enabled = true;
            btnChooseMaleAccessories.Enabled = true;
            btnChooseFemaleAccessories.Enabled = true;
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

        private void SetToolTips()
        {
            // male
            priceToolTip.SetToolTip(picMaleBuzzcut, $"Buzz cut: R{productsAndPrice["Buzz cut"]}");
            priceToolTip.SetToolTip(picMaleFadecut, $"Fade cut: R{productsAndPrice["Fade cut"]}");
            priceToolTip.SetToolTip(picMaleUndercut, $"Under cut: R{productsAndPrice["Under cut"]}");
            priceToolTip.SetToolTip(picMaleBirdsnest, $"Birds nest: R{productsAndPrice["Birds nest"]}");

            priceToolTip.SetToolTip(chkMaleHairdye, $"Hair dye: R{productsAndPrice["Hair dye"]}");
            priceToolTip.SetToolTip(chkMaleHairpart, $"Hair part: R{productsAndPrice["Hair part"]}");
            priceToolTip.SetToolTip(chkMaleWaves, $"Waves: R{productsAndPrice["Waves"]}");

            // female
            priceToolTip.SetToolTip(picFemaleCornrows, $"Cornrows: R{productsAndPrice["Cornrows"]}");
            priceToolTip.SetToolTip(picFemaleFulanibraids, $"Fulani braids: R{productsAndPrice["Fulani braids"]}");
            priceToolTip.SetToolTip(picFemaleKnotlessbraids, $"Knotless braids: R{productsAndPrice["Knotless braids"]}");
            priceToolTip.SetToolTip(picFemaleLayeredcut, $"Layered cut: R{productsAndPrice["Layered cut"]}");

            priceToolTip.SetToolTip(chkFemaleBeads, $"Beads: R{productsAndPrice["Beads"]}");
            priceToolTip.SetToolTip(chkFemaleCurls, $"Curls: R{productsAndPrice["Curls"]}");
            priceToolTip.SetToolTip(chkFemaleHighlights, $"Highlights: R{productsAndPrice["Highlights"]}");
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
