using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonAppointmentSystem
    // this is a class with all the forms in application, we create an object of this class and give it to every form
        // so that each form can navigate forwards and backwards when required
{
    public class FormManager
    {
        // Primary forms
        public SignUpForm signUpForm { get; private set; }
        public WelcomeForm welcomeForm { get; private set; }
        public LogInForm logInForm { get; private set; }
        public AdminLogInForm adminLogInForm { get; private set; }
        public GuestLogInForm guestLogInForm { get; private set; }

        // Client forms
        public GenderAndHairtypeForm genderAndHairtypeForm { get; private set; }
        public ClientDashboardForm clientDashboardForm { get; private set; }
        public ViewBookingsForm viewBookingsForm { get; private set; }
        public BookForHair bookForHairForm { get; private set; }
        public BookForNails bookForNailsForm { get; private set; }
        public HairAppointmentTime hairAppointmentTimeForm { get; private set; }
        public NailAppointmentTime nailAppointmentTimeForm { get; private set; }
        public PaymentForm paymentForm { get; private set; }
        public ThankYouForm thankYouForm { get; private set; }

        // Admin forms
        public AdminDashboardForm adminDashboardForm { get; private set; }
        public GenerateReportsForm generateReportsForm { get; private set; }

        public FormManager(Client client, Appointment appointment)
        {
            // Create all forms and pass the FormManager instance
            genderAndHairtypeForm = new GenderAndHairtypeForm(this, client, appointment);
            clientDashboardForm = new ClientDashboardForm(this, client, appointment);
            viewBookingsForm = new ViewBookingsForm(this, client, appointment);

            bookForHairForm = new BookForHair(this, client, appointment);
            bookForNailsForm = new BookForNails(this, client, appointment);

            hairAppointmentTimeForm = new HairAppointmentTime(this, client, appointment);
            nailAppointmentTimeForm = new NailAppointmentTime(this, client, appointment);

            paymentForm = new PaymentForm(this, client, appointment);
            thankYouForm = new ThankYouForm(this, client, appointment);
        }

        public FormManager(Admin admin)
        {
            // Create all forms and pass the FormManager instance
            adminDashboardForm = new AdminDashboardForm(this, admin);
            generateReportsForm = new GenerateReportsForm(this, admin);
            
        }


        public FormManager()
        {
            signUpForm = new SignUpForm(this);
            logInForm = new LogInForm(this);
            adminLogInForm = new AdminLogInForm (this);
            guestLogInForm = new GuestLogInForm(this);
            welcomeForm = new WelcomeForm(this);
        }

        public void ShowForm(Form formToShow, Form formToHide)
        {
            formToShow.Show();
            formToHide.Hide();
        }
    }
}
