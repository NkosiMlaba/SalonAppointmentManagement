using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Data.SQLite;

namespace SalonAppointmentSystem
{
    public class DatabaseManager
    // this a class we created to manage the database, all database queries go through this class
    {
        private static readonly string dbPath = "SalonDatabase.sqlite";
        private static readonly string connectionString = $"Data Source={dbPath};Version=3;";

        public DatabaseManager()
        {
            InitializeDatabase();
        }


        public void InitializeDatabase()
        {
            if (!File.Exists("SalonDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("SalonDatabase.sqlite");
                CreateTables();
                EnterDefaultData();
            }

            // everytime
            CreateTables();
        }

        public void InsertCustomer(string email, string password, string name, string surname, string hairType, string gender)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Customer (Email, Password, Name, Surname, HairType, Gender)
                    VALUES (@Email, @Password, @Name, @Surname, @HairType, @Gender)";

                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@HairType", hairType);
                cmd.Parameters.AddWithValue("@Gender", gender);

                cmd.ExecuteNonQuery();
            }
        }


        public void InsertCatalogueItem(string productType, string productName, int sellingPrice, int costPrice)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Catalogue (ProductType, ProductName, SellingPrice, CostPrice)
                    VALUES (@ProductType, @ProductName, @SellingPrice, @CostPrice)";

                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@ProductType", productType);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                cmd.Parameters.AddWithValue("@CostPrice", costPrice);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAppointment(string date, string time, string customerEmail, string name, string surname, string productType, string productName, string accessories, string stylist)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Appointment (Date, Time, CustomerEmail, Name, Surname, ProductType, ProductName, Accessories, Stylist)
                    VALUES (@Date, @Time, @CustomerEmail, @Name, @Surname, @ProductType, @ProductName, @Accessories, @Stylist)";

                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);
                cmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@ProductType", productType);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Accessories", accessories);
                cmd.Parameters.AddWithValue("@Stylist", stylist);

                cmd.ExecuteNonQuery();
            }
        }


        public void InsertAdmin(string name, string surname, string email, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Admin (Name, Surname, Email, Password)
                    VALUES (@Name, @Surname, @Email, @Password)";

                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertPayment(string customerEmail, int totalAmount, int totalCost, string productName, string accessories, string date, string time)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Payment (CustomerEmail, TotalAmount, TotalCost, ProductName, Accessories, Date, Time)
                    VALUES (@CustomerEmail, @TotalAmount, @TotalCost, @ProductName, @Accessories, @Date, @Time)";

                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Accessories", accessories);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);

                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<string, string> GetCustomerByEmail(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Customer WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, string>
                        {
                            { "Email", reader["Email"].ToString() },
                            { "Name", reader["Name"].ToString() },
                            { "Surname", reader["Surname"].ToString() },
                            { "HairType", reader["HairType"].ToString() },
                            { "Gender", reader["Gender"].ToString() }
                        };
                    }
                    return null;
                }
            }
        }

        public string GetCustomerPassword(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password FROM Customer WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public Dictionary<string, string> GetAdminByEmail(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Admin WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, string>
                        {
                            { "Name", reader["Name"].ToString() },
                            { "Surname", reader["Surname"].ToString() },
                            { "Email", reader["Email"].ToString() }
                        };
                    }
                    return null;
                }
            }
        }

        public string GetAdminPassword(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password FROM Admin WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public List<Dictionary<string, string>> GetAppointmentsByCustomerEmail(string customerEmail)
        {
            var appointments = new List<Dictionary<string, string>>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE CustomerEmail = @CustomerEmail";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Dictionary<string, string>
                    {
                        { "Time", reader["Time"].ToString() },
                        { "Date", reader["Date"].ToString() },
                        { "ProductType", reader["ProductType"].ToString() },
                        { "ProductName", reader["ProductName"].ToString() },

                        { "Stylist", reader["Stylist"].ToString() },
                        { "Accessories", reader["Accessories"].ToString() }
                    });
                    }
                }
            }
            return appointments;
        }

        public List<Dictionary<string, string>> GetAppointmentsByDate(string date)
        {
            var appointments = new List<Dictionary<string, string>>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE Date = @Date";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Dictionary<string, string>
                        {
                            { "AppointmentID", reader["AppointmentID"].ToString() },
                            { "Date", reader["Date"].ToString() },
                            { "Time", reader["Time"].ToString() },
                            { "CustomerEmail", reader["CustomerEmail"].ToString() },
                            { "Name", reader["Name"].ToString() },
                            { "Surname", reader["Surname"].ToString() },
                            { "ProductType", reader["ProductType"].ToString() },
                            { "ProductName", reader["ProductName"].ToString() },
                            { "Accessories", reader["Accessories"].ToString() },
                            { "Stylist", reader["Stylist"].ToString() }
                        });
                    }
                }
            }
            return appointments;
        }

        public List<Dictionary<string, string>> GetPaymentsByDateRange(string startDate, string endDate)
        {
            var payments = new List<Dictionary<string, string>>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Payment WHERE Date BETWEEN @StartDate AND @EndDate";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Dictionary<string, string>
                        {
                            { "TransactionID", reader["TransactionID"].ToString() },
                            { "Date", reader["Date"].ToString() },
                            { "Time", reader["Time"].ToString() },
                            { "CustomerEmail", reader["CustomerEmail"].ToString() },
                            { "TotalAmount", reader["TotalAmount"].ToString() },
                            { "TotalCost", reader["TotalCost"].ToString() },
                            { "ProductName", reader["ProductName"].ToString() },
                            { "Accessories", reader["Accessories"].ToString() }

                        });
                    }
                }
            }
            return payments;
        }

        public bool IsStylistAvailable(string stylist, string date, string time)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Appointment WHERE Stylist = @Stylist AND Date = @Date AND Time = @Time";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Stylist", stylist);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }

        public bool IsCustomerExists(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Customer WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // Returns true if customer exists
            }
        }

        public bool IsAdminExists(string email)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Admin WHERE Email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // Returns true if Admin exists
            }
        }

        public Dictionary<string, string> GetCatalogueItemByName(string productName)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Catalogue WHERE ProductName = @ProductName";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", productName);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, string>
                        {
                            { "ProductID", reader["ProductID"].ToString() },
                            { "ProductType", reader["ProductType"].ToString() },
                            { "ProductName", reader["ProductName"].ToString() },
                            { "SellingPrice", reader["SellingPrice"].ToString() },
                            { "CostPrice", reader["CostPrice"].ToString() }
                        };
                    }
                    return null;
                }
            }
        }

        public bool DropTableData(string tableName)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = $"DELETE FROM {tableName}";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SQLiteException)
                {
                    return false;
                }
            }
        }

        public void EnterDefaultData()
        {
            // insert atleast one admin user
            var config = SmtpConfig.LoadConfig();
            if (config == null)
            {
                throw new Exception("Configuration file is empty or incorrectly formatted.");
            }
            InsertAdmin("John", "Doe", config.Username, "a3<$'5/<Ll3u");

            // Insert one customer dummy data
            InsertCustomer("notexistantemail@example.com", "erA(n.54_v64", "Jane", "Harvey", "Curly", "Female");

            // nails
            InsertCatalogueItem("Nails", "Square", 120, 60);
            InsertCatalogueItem("Nails", "Stiletto", 180, 90);
            InsertCatalogueItem("Nails", "Almond", 100, 50);
            InsertCatalogueItem("Nails", "Coffin", 150, 75);

            // hair
            InsertCatalogueItem("Hairstyle", "Cornrows", 100, 50);
            InsertCatalogueItem("Hairstyle", "Knotless braids", 600, 300);
            InsertCatalogueItem("Hairstyle", "Layered cut", 200, 100);
            InsertCatalogueItem("Hairstyle", "Fulani braids", 400, 200);

            InsertCatalogueItem("Hairstyle", "Fade cut", 100, 50);
            InsertCatalogueItem("Hairstyle", "Under cut", 120, 60);
            InsertCatalogueItem("Hairstyle", "Buzz cut", 50, 25);
            InsertCatalogueItem("Hairstyle", "Birds nest", 200, 100);

            // nail accessory
            InsertCatalogueItem("Accessory", "Chromes", 100, 50);
            InsertCatalogueItem("Accessory", "Nail art", 70, 35);
            InsertCatalogueItem("Accessory", "Pearls", 50, 25);
            InsertCatalogueItem("Accessory", "Rhine stones", 20, 10);

            // hair accessory
            InsertCatalogueItem("Accessory", "Beads", 70, 35);
            InsertCatalogueItem("Accessory", "Curls", 150, 75);
            InsertCatalogueItem("Accessory", "Highlights", 300, 150);

            InsertCatalogueItem("Accessory", "Hair dye", 50, 25);
            InsertCatalogueItem("Accessory", "Hair part", 20, 60);
            InsertCatalogueItem("Accessory", "Waves", 100, 50);
        }

        public Dictionary<string, string> GetCatalogueItemsWithPrices()
        {
            var items = new Dictionary<string, string>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProductName, SellingPrice FROM Catalogue";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        items[productName] = reader["SellingPrice"].ToString();
                    }
                }
            }
            return items;
        }

        public void CreateTables()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Customer (
                        Email TEXT PRIMARY KEY,
                        Password TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        Surname TEXT NOT NULL,
                        HairType TEXT NOT NULL,
                        Gender TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Catalogue (
                        ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProductType TEXT NOT NULL,
                        ProductName TEXT NOT NULL,
                        SellingPrice INTEGER NOT NULL,
                        CostPrice INTEGER NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Appointment (
                        AppointmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT NOT NULL,
                        Time TEXT NOT NULL,
                        CustomerEmail TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        Surname TEXT NOT NULL,
                        ProductType TEXT NOT NULL,
                        ProductName TEXT NOT NULL,
                        Accessories TEXT,
                        Stylist TEXT NOT NULL,
                        FOREIGN KEY (CustomerEmail) REFERENCES Customer(Email),
                        FOREIGN KEY (ProductName) REFERENCES Catalogue(ProductName)
                    );

                    CREATE TABLE IF NOT EXISTS Admin (
                        Name TEXT NOT NULL,
                        Surname TEXT NOT NULL,
                        Email TEXT UNIQUE NOT NULL,
                        Password TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Payment (
                        TransactionID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CustomerEmail TEXT NOT NULL,
                        TotalAmount INTEGER NOT NULL,
                        TotalCost INTEGER NOT NULL,
                        ProductName TEXT NOT NULL,
                        Accessories TEXT,
                        Date TEXT NOT NULL,
                        Time TEXT NOT NULL,
                        FOREIGN KEY (CustomerEmail) REFERENCES Customer(Email)
                    );
                ";
                SQLiteCommand cmd = new SQLiteCommand(createTablesQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
