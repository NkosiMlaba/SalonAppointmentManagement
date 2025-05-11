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
    public partial class AdminLogInForm : Form
    {

        DatabaseManager databaseManager = new DatabaseManager();
        ToolTip toolTip = new ToolTip();
        FormManager formManager;

        public AdminLogInForm(FormManager baseForms)
        {
            InitializeComponent();
            formManager = baseForms;

            // tooltips
            toolTip.SetToolTip(txtEmail, "Enter your registered email address.");
            toolTip.SetToolTip(txtPassword, "Enter your password.");
        }

        private void btnAdminLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string enteredPassword = txtPassword.Text.Trim();

                // Validate empty fields
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Please enter both email and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format
                if (!ValidateClass.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if admin exists in the database
                if (!databaseManager.IsAdminExists(email))
                {
                    MessageBox.Show("This admin account does not exist.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // password check with database
                string savedPassword = databaseManager.GetAdminPassword(email);
                if (savedPassword != enteredPassword)
                {
                    MessageBox.Show("Incorrect password entered");
                    txtPassword.Clear();
                    return;
                }

                // fetch admin data from database
                Dictionary<string, string> adminData = new Dictionary<string, string>();
                try
                {
                    adminData = databaseManager.GetAdminByEmail(email);
                }
                catch
                {
                    MessageBox.Show("Error retreiving admin data");
                    return;
                }



                try
                {
                    // create admin object from data
                    // "John", "Doe", "admin@salon.com", "password123",
                    Admin admin = new Admin(adminData["Name"], adminData["Surname"], adminData["Email"], savedPassword);

                    // create form manager object
                    FormManager formManager = new FormManager(admin);

                    // to admin dashboard switch
                    formManager.ShowForm(formManager.adminDashboardForm, this);
                }
                catch
                {
                    MessageBox.Show("Error creating admin object");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Enable/disable the password textbox based on email validity
            txtPassword.Enabled = ValidateClass.IsValidEmail(email);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Enable the "Login" button only when both fields are valid
            btnAdminLogIn.Enabled = ValidateClass.IsValidEmail(email) && ValidateClass.IsValidPassword(password);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Future forgot-password logic here
            MessageBox.Show("Forgot password functionality coming soon.");
        }

        private void welcomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.welcomeForm, this);
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.signUpForm, this);
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.logInForm, this);
        }

        private void guestModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.guestLogInForm, this);
        }
    }
}
