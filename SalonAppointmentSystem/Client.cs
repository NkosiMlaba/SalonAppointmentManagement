using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAppointmentSystem
{
    public class Client
        // we created this class to hold data and methods related to a client/customer
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HairType { get; set; }
        public string Gender { get; set; }
        public bool IsGuest { get; set; }

        public string CurrentChosenNailStyle { get; set; }
        public List<string> CurrentChosenNailAccessories { get; set; }


        public string CurrentChosenHairStyle { get; set; }
        public List<string> CurrentChosenHairAccessories { get; set; }

        public string CurrentAppointmentTime { get; set; }
        public string CurrentAppointmentDate { get; set; }
        public string CurrentAppointmentStylist { get; set; }




        public Client(string email, string password, string name, string surname, bool isGuest)
        {
            // normal signing up client, other properties set later
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            IsGuest = isGuest;
        }

        public Client(string email, string password, string name, string surname, bool isGuest, string gender, string hairType)
        {
            // logging in client, all properties must be set
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            IsGuest = isGuest;
            Gender = gender;
            HairType = hairType;
        }

        public Client(string email,  string name, string surname, bool isGuest)
        {
            // guest, no password, other properties set later
            Email = email;
            Name = name;
            Surname = surname;
            IsGuest = isGuest;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} ({Email})";
        }
    }
}
