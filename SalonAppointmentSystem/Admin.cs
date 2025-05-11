using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAppointmentSystem
{
    public class Admin
        // this class holds the data associated with an admin object
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Admin(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Admin: {Name} {Surname} ({Email})";
        }
    }
}
