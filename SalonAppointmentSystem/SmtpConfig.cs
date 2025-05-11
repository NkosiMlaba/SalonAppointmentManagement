using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Mail;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SalonAppointmentSystem
{
    public class SmtpConfig
    // this is a class helping use retrieve the account details of the salon owner
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }


        public static SmtpConfig LoadConfig()
        {
            string configPath = "appsettings.json";

            if (!File.Exists(configPath))
            {
                Console.WriteLine("Error: Configuration file not found.");
                return null;
            }

            string json = File.ReadAllText(configPath);

            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Error: Configuration file is empty.");
                return null;
            }

            try
            {
                JObject parsedJson = JObject.Parse(json);
                JObject smtpConfigJson = (JObject)parsedJson["SmtpConfig"];

                if (smtpConfigJson == null)
                {
                    Console.WriteLine("Error: 'SmtpConfig' section is missing.");
                    return null;
                }

                SmtpConfig config = new SmtpConfig
                {
                    Server = smtpConfigJson["Server"]?.ToString(),
                    Port = smtpConfigJson["Port"]?.ToObject<int>() ?? 0,
                    Username = smtpConfigJson["Username"]?.ToString(),
                    Password = smtpConfigJson["Password"]?.ToString(),
                    EnableSSL = smtpConfigJson["EnableSSL"]?.ToObject<bool>() ?? false
                };

                if (string.IsNullOrWhiteSpace(config.Username))
                {
                    throw new Exception("Email address is missing in config.");
                }

                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing config file: {ex.Message}");
                return null;
            }


        }
    }

}
