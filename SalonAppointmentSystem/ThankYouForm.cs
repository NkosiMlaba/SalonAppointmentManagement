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
    public partial class ThankYouForm : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;

        public ThankYouForm(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;
        }

        private void btnToDashboard_Click(object sender, EventArgs e)
        {
            // clear all appointment data
            ClearCurrentAppointment();

            // back to dashboard
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


        private void ClearCurrentAppointment()
        {
            // client
            Client copyClient = currentClient;
            currentClient = new Client(copyClient.Email, copyClient.Password, copyClient.Name, copyClient.Surname, copyClient.IsGuest, copyClient.Gender, copyClient.HairType);

            // appointment
            currentAppointment = new Appointment();
            currentAppointment.CurrentStyleChosen = null;
            currentAppointment.Accessory1 = null;
            currentAppointment.Accessory2 = null;
            currentAppointment.Accessory3 = null;
            currentAppointment.Accessory4 = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // close the application
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
