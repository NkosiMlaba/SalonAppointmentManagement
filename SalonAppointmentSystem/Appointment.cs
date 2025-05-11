using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAppointmentSystem
{
    public class Appointment
        // this class helps use keep the data about each appointment in an appointment object, and includes all data about an appointment
    {
        public int AppointmentID { get; set; }
        public string Time { get; set; }
        public string CustomerEmail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProductType { get; set; }
        public Dictionary<string, string> CurrentStyleChosen { get; set; }
        public Dictionary<string, string> Accessory1 { get; set; }
        public Dictionary<string, string> Accessory2 { get; set; }
        public Dictionary<string, string> Accessory3 { get; set; }
        public Dictionary<string, string> Accessory4 { get; set; }
        public string Stylist { get; set; }

        public Appointment()
        {
            //pass
        }

        public override string ToString()
        {
            return $"Appointment for {Name} {Surname} at {Time} with stylist {Stylist}.";
        }
    }
}
