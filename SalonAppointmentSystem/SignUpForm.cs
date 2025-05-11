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
    public partial class SignUpForm : Form
    {
        FormManager formManager;

        ToolTip toolTip = new ToolTip();

        public SignUpForm(FormManager baseForms)
        {
            InitializeComponent();
            formManager = baseForms;

            // disable text fields
            txtSurname.Enabled = false;
            txtEmail.Enabled = false;
            mskPhoneNumber.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmationPassword.Enabled = false;
            btnContinueSignUp.Enabled = false;

            // tooltips
            toolTip.SetToolTip(txtName, "Enter your first name.");
            toolTip.SetToolTip(txtSurname, "Enter your surname.");
            toolTip.SetToolTip(txtEmail, "Enter your email. Must include '@' and a '.'");
            toolTip.SetToolTip(mskPhoneNumber, "Enter a valid 10-digit phone number starting with '0'.");
            toolTip.SetToolTip(txtPassword, "Password must start with a capital letter, contain a number and a special character.");
            toolTip.SetToolTip(txtConfirmationPassword, "Re-enter your password for confirmation.");
            toolTip.SetToolTip(btnContinueSignUp, "Click to complete your sign-up.");
        }

        private void btnContinueSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string surname = txtSurname.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmationPassword = txtConfirmationPassword.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = mskPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmationPassword) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("All fields are required!");
                    return;
                }

                if (!ValidateClass.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format! Email must contain '@' and a number.");
                    return;
                }

                if (!ValidateClass.IsValidPassword(password))
                {
                    MessageBox.Show("Password must start with an uppercase letter, contain a number, and a symbol.");
                    return;
                }

                if (password != confirmationPassword)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }

                if (!ValidateClass.IsValidPhoneNumber(phone))
                {
                    MessageBox.Show("Invalid phone number format. Must be 10 digits and start with '0'.");
                    return;
                }


                // check if customer exists in database already
                DatabaseManager database = new DatabaseManager();
                if (database.IsCustomerExists(email))
                {
                    MessageBox.Show("User with this email already exists, use another email");
                    txtEmail.Clear();
                    return;
                }

                // create client object
                // "test@example.com", "password123", "John", "Doe", "Curly", "Male"
                Client client = new Client(email, password, name, surname, false);

                // appointment object
                Appointment appointment = new Appointment();

                // create form manager object
                FormManager formManager = new FormManager(client, appointment);

                // switch to gender and hairstyles form
                formManager.ShowForm(formManager.genderAndHairtypeForm, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sign up method " + ex.Message);
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtSurname.Enabled = !string.IsNullOrWhiteSpace(txtName.Text);
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = !string.IsNullOrWhiteSpace(txtSurname.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            mskPhoneNumber.Enabled = ValidateClass.IsValidEmail(txtEmail.Text.Trim());
        }

        private void mskPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (mskPhoneNumber.MaskCompleted && ValidateClass.IsValidPhoneNumber(mskPhoneNumber.Text.Trim()))
            {
                txtPassword.Enabled = true;
            }
            else if (mskPhoneNumber.MaskCompleted)
            {
                // pass
            }
            else
            {
                txtPassword.Enabled = false;
            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            bool valid = ValidateClass.IsValidPassword(txtPassword.Text.Trim());

            txtConfirmationPassword.Enabled = valid;

            if (!valid)
            {
                txtConfirmationPassword.Clear();
            }
        }

        private void txtConfirmationPassword_TextChanged(object sender, EventArgs e)
        {
            bool valid = ValidateClass.IsValidPassword(txtPassword.Text.Trim());

            btnContinueSignUp.Enabled = valid;

            if (!valid)
            {
                txtConfirmationPassword.Clear();
            }
        }

        private void welcomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.welcomeForm, this);
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.logInForm, this);
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
