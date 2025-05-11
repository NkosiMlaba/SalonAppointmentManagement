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
    public partial class NailAppointmentTime : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;
        private DatabaseManager database = new DatabaseManager();

        private string selectedAppointmentTime = string.Empty;
        private string selectedAppointmentDate = string.Empty;
        private string selectedStylist = string.Empty;

        public NailAppointmentTime(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;

            AddEvenHandlerToRadioButtons();

            dtpZandile.ValueChanged += DateTimePicker_ValueChanged;
            dtpLinden.ValueChanged += DateTimePicker_ValueChanged;
            dtpAnupama.ValueChanged += DateTimePicker_ValueChanged;
            dtpCeleste.ValueChanged += DateTimePicker_ValueChanged;


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

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButton selectedRB = sender as RadioButton;
                TableLayoutPanel parentTableLayoutPanel = selectedRB.Parent as TableLayoutPanel;
                // The enclosing Panel
                Panel parentPanel = parentTableLayoutPanel?.Parent as Panel; 
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
                        string selectedDate = associatedDTP.Value.ToString("yyyy-MM-dd");
                        string selectedTime = selectedRB.Text; 

                        // Combine Date & Time
                        selectedAppointmentTime = $"{selectedTime}:00";
                        selectedAppointmentDate = $"{selectedDate}";

                        // Uncheck all other RadioButtons in all TableLayoutPanels within any Panel
                        foreach (Control panel in this.Controls)
                        {
                            // Loop through main panels
                            if (panel is Panel mainPanel) 
                            {
                                foreach (Control subControl in mainPanel.Controls)
                                {
                                    // Loop through TableLayoutPanels
                                    if (subControl is TableLayoutPanel tlp) 
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
            rdoAnupama07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAnupama11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAnupama15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoAnupama20h00.CheckedChanged += RadioButton_CheckedChanged;

            rdoCeleste07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoCeleste11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoCeleste15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoCeleste20h00.CheckedChanged += RadioButton_CheckedChanged;

            rdoLinden07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoLinden11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoLinden15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoLinden20h00.CheckedChanged += RadioButton_CheckedChanged;

            rdoZandile07h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoZandile11h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoZandile15h00.CheckedChanged += RadioButton_CheckedChanged;
            rdoZandile20h00.CheckedChanged += RadioButton_CheckedChanged;



        }

        private void ResetValues()
        {
            selectedAppointmentTime = string.Empty;
            selectedAppointmentDate = string.Empty;
            selectedStylist = string.Empty;

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

        private void btnToPayment_Click(object sender, EventArgs e)
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


            // next form
            currentFormManager.ShowForm(currentFormManager.paymentForm, this);
        }

        private void UpdateAvailability()
        {
            // List of stylists and their controls
            var stylistControls = new Dictionary<string, (DateTimePicker dtp, TableLayoutPanel tlp, RadioButton[] rdos)>
    {
        { "Zandile", (dtpZandile, tlpZandile, new RadioButton[] { rdoZandile07h00, rdoZandile11h00, rdoZandile15h00, rdoZandile20h00 }) },
        { "Linden", (dtpLinden, tlpLinden, new RadioButton[] { rdoLinden07h00, rdoLinden11h00, rdoLinden15h00, rdoLinden20h00 }) },
        { "Anupama", (dtpAnupama, tlpAnupama, new RadioButton[] { rdoAnupama07h00, rdoAnupama11h00, rdoAnupama15h00, rdoAnupama20h00 }) },
        { "Celeste", (dtpCeleste, tlpCeleste, new RadioButton[] { rdoCeleste07h00, rdoCeleste11h00, rdoCeleste15h00, rdoCeleste20h00 }) }
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
            // this was a key challange, as form_shown only works the first time a form is showed, but we show the payment form mulitple times
            base.OnActivated(e);
            UpdateAvailability();
        }

        private void NailAppointmentTime_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();
            SetDatePickerLimits();
        }

        private void SetDatePickerLimits()
        {
            DateTime today = DateTime.Today;

            // Set the minimum date for all DateTimePickers to today
            dtpLinden.MinDate = today;
            dtpAnupama.MinDate = today;
            dtpZandile.MinDate = today;
            dtpCeleste.MinDate = today;
        }
    }
}
