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
    public partial class GuestLogInForm : Form
    {
        ToolTip tooltip = new ToolTip();
        FormManager formManager;

        public GuestLogInForm(FormManager baseForms)
        {
            InitializeComponent();
            formManager = baseForms;


            this.Load += GuestLogInForm_Load;
            txtName.TextChanged += txtName_TextChanged;
            txtSurname.TextChanged += txtSurname_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
            mtxPhoneNumber.TextChanged += mtxPhoneNumber_TextChanged;
        }

        private void btnToGenderHairtype_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = mtxPhoneNumber.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("All fields are required!", "Missing Information");
                    return;
                }

                if (!ValidateClass.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format! Email must contain '@' and a valid domain.");
                    return;
                }

                if (!ValidateClass.IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Invalid phone number format! Enter your phone number starting with '0'.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error in input validation");
            }


            try
            {
                // create client object
                // "test@example.com", "John", "Doe", true
                Client client = new Client(email, name, surname, true);
                Appointment appointment = new Appointment();

                // create form manager object
                FormManager formManager = new FormManager(client, appointment);

                // switch to gender and hairstyles form
                formManager.ShowForm(formManager.genderAndHairtypeForm, this);
            }
            catch
            {
                MessageBox.Show("Error in Object creation");
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

        private void GuestLogInForm_Load(object sender, EventArgs e)
        {
            // Disable all except the first textbox
            txtSurname.Enabled = false;
            txtEmail.Enabled = false;
            mtxPhoneNumber.Enabled = false;
            btnToGenderHairtype.Enabled = false;

            // Add tooltips
            tooltip.SetToolTip(txtName, "Enter your first name to continue");
            tooltip.SetToolTip(txtSurname, "Enter your surname after first name");
            tooltip.SetToolTip(txtEmail, "Enter a valid email (e.g. name@example.com)");
            tooltip.SetToolTip(mtxPhoneNumber, "Enter a valid 10-digit phone number starting with '0'.");
            tooltip.SetToolTip(btnToGenderHairtype, "Click when all fields are completed correctly");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtSurname.Enabled = true;
            }
            else
            {
                txtSurname.Enabled = false;
                txtSurname.Clear();
                txtEmail.Enabled = false;
                txtEmail.Clear();
                mtxPhoneNumber.Enabled = false;
                mtxPhoneNumber.Clear();
                btnToGenderHairtype.Enabled = false;
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtEmail.Enabled = true;
            }
            else
            {
                txtEmail.Enabled = false;
                txtEmail.Clear();
                mtxPhoneNumber.Enabled = false;
                mtxPhoneNumber.Clear();
                btnToGenderHairtype.Enabled = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (ValidateClass.IsValidEmail(email))
            {
                mtxPhoneNumber.Enabled = true;

                // If phone is already valid, enable button
                if (ValidateClass.IsValidPhoneNumber(mtxPhoneNumber.Text.Trim()))
                {
                    btnToGenderHairtype.Enabled = true;
                }
            }
            else
            {
                mtxPhoneNumber.Enabled = false;
                mtxPhoneNumber.Clear();
                btnToGenderHairtype.Enabled = false;
            }
        }

        private void mtxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string phoneNumber = mtxPhoneNumber.Text.Trim();

            if (ValidateClass.IsValidPhoneNumber(phoneNumber))
            {
                btnToGenderHairtype.Enabled = true;
            }
            else
            {
                btnToGenderHairtype.Enabled = false;
            }
        }

        private void welcomeToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.adminLogInForm, this);
        }
    }
}
