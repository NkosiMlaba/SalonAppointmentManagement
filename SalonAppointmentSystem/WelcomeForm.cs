using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalonAppointmentSystem
{
    public partial class WelcomeForm : Form
    {
        FormManager formManager;
        DatabaseManager databaseManager = new DatabaseManager();

        public WelcomeForm(FormManager baseForms)
        {
            InitializeComponent();

            formManager = baseForms;
            //EnterDatabaseData();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.signUpForm, this);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.logInForm, this);
        }

        private void btnGuestLogIn_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.guestLogInForm, this);
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            formManager.ShowForm(formManager.adminLogInForm, this);
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

        private void EnterDatabaseData()
        {
            // this is out method used to delete all data from database, should not be called by default else database will reset everytime you run the program
            DatabaseManager databaseManager = new DatabaseManager();

            List<string> tables = new List<string> { "Catalogue", "Appointment", "Payment", "Customer", "Admin" };

            foreach (string tableName in tables)
            {
                databaseManager.DropTableData(tableName);
            }

            databaseManager.EnterDefaultData();

        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
