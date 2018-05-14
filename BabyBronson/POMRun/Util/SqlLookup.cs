using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Data.SqlClient;
using Waitcon = SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace POMRun.Util
{
    class SqlLookup
    {
        public User GetUser(String connectionString, String GUID)
        {
            string queryString = "SELECT [ApplicantId],[Guid],[FirstName],[LastName]FROM[dbo].[Applicants]";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[1].ToString().ToUpper().Equals(GUID))
                        {

                            return new User(
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[1].ToString(),
                                int.Parse(reader[0].ToString())
                                );

                        }

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("No user found");
            return new User("Not a", "Real User", "NULL", -1); ;
        }

        public String GetConnectionString()
        {

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            string connectionString = String.Format("Data Source=intrideo-can-test-sql.database.windows.net;" +
                                            "Initial Catalog=intrideo-can-test-db;" +
                                            "user id={0};" +
                                            "password={1}", username, password);
            return connectionString;
        }

        public Boolean IsValidEmail(string email)
        {

            if (email.Contains("@gmail.com"))
            {
                return true;
            }
            else { return false; }

        }
    }
}
