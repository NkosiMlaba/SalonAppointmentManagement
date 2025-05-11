using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAppointmentSystem
{
    class ValidateClass
    // this is our class that we created for validation methods e.g. email validatio and password validation
    // we decided to use a class after we saw that we were copying and pasting the same validation methods on multiple forms
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // validate use Net.Mail
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email && email.Contains("@") && email.Contains(".");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            // if empty
            if (string.IsNullOrEmpty(password)) 
            { 
                return false;
            }

            // checking for length, uppercase, digit, and special character
            return password.Length >= 6 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // checking for 10 digits and that first digit is 0
            string cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return cleaned.Length == 10 && cleaned.StartsWith("0");
        }
    }
}
