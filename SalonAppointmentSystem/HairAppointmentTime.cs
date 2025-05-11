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
    public partial class HairAppointmentTime : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;
        private DatabaseManager database = new DatabaseManager();

        private string selectedAppointmentTime = string.Empty;
        private string selectedAppointmentDate = string.Empty;
        private string selectedStylist = string.Empty;

        public HairAppointmentTime(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;
            AddEvenHandlerToRadioButtons();

            dtpShanae.ValueChanged += DateTimePicker_ValueChanged;
            dtpIrwin.ValueChanged += DateTimePicker_ValueChanged;
            dtpAsabe.ValueChanged += DateTimePicker_ValueChanged;
            dtpJanine.ValueChanged += DateTimePicker_ValueChanged;

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

        private void btnToPaymentForm_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentTime == null || selectedAppointmentTime == "" || selectedStylist == "" || selectedStylist == "Unknown")
            {
                MessageBox.Show("Select one appointment");
                return;
            }

            // do something with the data
            currentClient.CurrentAppointmentStylist = selectedStylist;
            currentClient.CurrentAppointmentTime = selectedAppointmentTime;
            currentClient.CurrentAppointmentDate = selectedAppointmentDate;


            // reset values
            ResetValues();


            currentFormManager.ShowForm(currentFormManager.paymentForm, this);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButton selectedRB = sender as RadioButton;
                TableLayoutPanel parentTableLayoutPanel = selectedRB.Parent as TableLayoutPanel;
                Panel parentPanel = parentTableLayoutPanel?.Parent as Panel; // The enclosing Panel
                DateTimePicker associatedDTP = null;

                if (parentPanel != null)
                {
                    // Get the stylist name from the Panel's Tag property
                    selectedStylist = parentPanel.Tag?.ToString() ?? "Unknown";

                    // Find the corresponding DateTimePicker within the same parent Panel
                    foreach (Control ctrl in parentPanel.Controls)
                    {
                        if (ctrl is DateTimePicker dtp)
                        {
                            associatedDTP = dtp;
                            break;
                        }
                    }

                    if (associatedDTP != null)
                    {
                        string selectedDate = associatedDTP.Value.ToString("yyyy-MM-dd"); // Extract date
                        string selectedTime = selectedRB.Text; // Assume radio button text stores the time (e.g., "07:00", "11:00")

                        // Combine Date & Time
                        selectedAppointmentTime = $"{selectedTime}:00";
                        selectedAppointmentDate = $"{selectedDate}";

                        // Uncheck all other RadioButtons in all TableLayoutPanels within any Panel
                        foreach (Control panel in this.Controls)
                        {
                            if (panel is Panel mainPanel) // Loop through main panels
                            {
                                foreach (Control subControl in mainPanel.Controls)
                                {
                                    if (subControl is TableLayoutPanel tlp) // Loop through TableLayoutPanels
                                    {
                                        foreach (Control rb in tlp.Controls)
                                        {
                                            if (rb is RadioButton radioButton && radioButton != sender)
                                            {
                                                radioButton.Checked = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddEvenHandlerToRadioButtons()
        {
            rdoShanae07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoShanae11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoShanae15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoShanae20h00.CheckedChanged += RadioButton_CheckedChanged;
            
            rdoIrwin07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoIrwin11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoIrwin15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoIrwin20h00.CheckedChanged += RadioButton_CheckedChanged;

            rdoAsabe07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAsabe11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAsabe15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAsabe20h00.CheckedChanged += RadioButton_CheckedChanged;

            rdoJanine07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoJanine11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoJanine15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoJanine20h00.CheckedChanged += RadioButton_CheckedChanged;
            


        }

        private void HairAppointmentTime_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();
            SetDatePickerLimits();
        }

        private void ResetValues()
        {
            // reset form variables
            selectedAppointmentTime = string.Empty;
            selectedAppointmentDate = string.Empty;
            selectedStylist = string.Empty;

            // uncheck appointments
            foreach (Control panel in this.Controls)
            {
                if (panel is Panel mainPanel)
                {
                    foreach (Control subControl in mainPanel.Controls)
                    {
                        if (subControl is TableLayoutPanel tlp)
                        {
                            foreach (Control rb in tlp.Controls)
                            {
                                if (rb is RadioButton radioButton)
                                {
                                    radioButton.Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateAvailability()
        {
            // List of stylists and their controls
            var stylistControls = new Dictionary<string, (DateTimePicker dtp, TableLayoutPanel tlp, RadioButton[] rdos)>
    {
        { "Shanae", (dtpShanae, tlpShanae, new RadioButton[] { rdoShanae07h00, rdoShanae11h00, rdoShanae15h00, rdoShanae20h00 }) },
        { "Irwin", (dtpIrwin, tlpIrwin, new RadioButton[] { rdoIrwin07h00, rdoIrwin11h00, rdoIrwin15h00, rdoIrwin20h00 }) },
        { "Asabe", (dtpAsabe, tlpAsabe, new RadioButton[] { rdoAsabe07h00, rdoAsabe11h00, rdoAsabe15h00, rdoAsabe20h00 }) },
        { "Janine", (dtpJanine, tlpJanine, new RadioButton[] { rdoJanine07h00, rdoJanine11h00, rdoJanine15h00, rdoJanine20h00 }) }
    };

            string[] timeSlots = { "07:00:00", "11:00:00", "15:00:00", "20:00:00" };

            foreach (var stylist in stylistControls)
            {
                string stylistName = stylist.Key;
                DateTimePicker dtp = stylist.Value.dtp;
                RadioButton[] radioButtons = stylist.Value.rdos;
                string selectedDate = dtp.Value.ToString("yyyy-MM-dd");

                for (int i = 0; i < timeSlots.Length; i++)
                {
                    string time = timeSlots[i];

                    DateTime appointmentDateTime = DateTime.ParseExact($"{selectedDate} {time}", "yyyy-MM-dd HH:mm:ss", null);

                    bool isInPast = appointmentDateTime < DateTime.Now;

                    bool isAvailable = !isInPast && database.IsStylistAvailable(stylistName, selectedDate, time);

                    radioButtons[i].Enabled = isAvailable;
                }
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAvailability();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            UpdateAvailability();
        }

        private void SetDatePickerLimits()
        {
            DateTime today = DateTime.Today;

            // Set the minimum date for all DateTimePickers to today
            dtpShanae.MinDate = today;
            dtpIrwin.MinDate = today;
            dtpAsabe.MinDate = today;
            dtpJanine.MinDate = today;
        }

    }
}
