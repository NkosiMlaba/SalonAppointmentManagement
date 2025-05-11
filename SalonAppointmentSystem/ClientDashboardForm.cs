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
    public partial class ClientDashboardForm : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;

        public ClientDashboardForm(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            currentFormManager.ShowForm(currentFormManager.viewBookingsForm, this);
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            if (!(rdoHair.Checked || rdoNails.Checked))
            {
                MessageBox.Show("Choose one appointment type");
                return;
            }
            
            // client
            /*Client copyClient = currentClient;*/
            currentClient = new Client(currentClient.Email, currentClient.Password, currentClient.Name, currentClient.Surname, currentClient.IsGuest, currentClient.Gender, currentClient.HairType);

            // appointment
            currentAppointment = new Appointment();
            currentAppointment.CurrentStyleChosen = null;
            currentAppointment.Accessory1 = null;
            currentAppointment.Accessory2 = null;
            currentAppointment.Accessory3 = null;
            currentAppointment.Accessory4 = null;


            if (rdoHair.Checked)
            {
                currentFormManager.ShowForm(currentFormManager.bookForHairForm, this);
            }
            else
            {
                currentFormManager.ShowForm(currentFormManager.bookForNailsForm, this);
            }
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

        private void ClientDashboardForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User \n" + currentClient.ToString();

            if (currentClient.IsGuest)
            {
                btnViewAppointments.Enabled = false;
                btnViewAppointments.Text = "Guests Can Not View Saved Appointments";
            } 
            else
            {
                btnViewAppointments.Enabled = true;
            }
        }
    }
}
