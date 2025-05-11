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
    public partial class LogInForm : Form
    {
        private FormManager formManager;
        private ToolTip toolTip = new ToolTip();

        public LogInForm(FormManager baseForms)
        {
            InitializeComponent();
            formManager = baseForms;

            // Initial control states
            txtPassword.Enabled = false;
            btnLogIn.Enabled = false;

            // Initialize tooltips
            toolTip.SetToolTip(txtEmail, "Enter your email. Must include '@' and a domain (e.g., .com)");
            toolTip.SetToolTip(txtPassword, "Password must start with uppercase, contain a number and a special character.");
            toolTip.SetToolTip(btnLogIn, "Click to log into your account.");
            toolTip.SetToolTip(linkLabel1, "Click here if you forgot your password.");
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Check empty fields
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Email and Password cannot be empty!");
                    return;
                }

                if (!ValidateClass.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format!");
                    return;
                }

                if (!ValidateClass.IsValidPassword(password))
                {
                    MessageBox.Show("Password must have uppercase, contain number & symbol.");
                    return;
                }


                // check if customer exists
                DatabaseManager database = new DatabaseManager();
                if (!database.IsCustomerExists(email))
                {
                    MessageBox.Show("You do not have an account please sign up");
                    return;
                }

                // database check for password if they match
                string savedPassword = database.GetCustomerPassword(email);
                if (password != savedPassword)
                {
                    MessageBox.Show("Incorrect password!");
                    txtPassword.Clear();
                    return;
                }

                // must retrive all current user data from database
                Dictionary<string, string> savedUser = database.GetCustomerByEmail(email);

                // create current user object
                //public Client(string email, string password, string name, string surname, bool isGuest, string gender, string hairType)
                Client client = new Client(email, password, savedUser["Name"], savedUser["Surname"], false, savedUser["Gender"], savedUser["HairType"]);

                // apppointment object
                Appointment appointment = new Appointment();

                // create form manager object
                FormManager formManager = new FormManager(client, appointment);

                // switch to gender and hairstyles form
                formManager.ShowForm(formManager.clientDashboardForm, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Future forgot-password logic here
            MessageBox.Show("Forgot password functionality coming soon.");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();

            // Enable login only if both email is valid and password is filled
            btnLogIn.Enabled = ValidateClass.IsValidEmail(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(password);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Enable password only if email is valid
            if (ValidateClass.IsValidEmail(email))
            {
                txtPassword.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                txtPassword.Clear();
                btnLogIn.Enabled = false;
                return;
            }

            // Only enable login if password is already filled
            btnLogIn.Enabled = !string.IsNullOrEmpty(txtPassword.Text.Trim());
        }

        private void welcomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.welcomeForm, this);
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.signUpForm, this);
        }

        private void guestModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.guestLogInForm, this);
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.adminLogInForm, this);
        }
    }
}
