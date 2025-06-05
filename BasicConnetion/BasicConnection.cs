using MySql.Data.MySqlClient;
using System;

namespace c__SQL.BasicConnetion
{
    internal class BasicConnection
    {
        private string connStr = "server=localhost;user=root;password=;database=classicmodels";

        public void CreateBasicConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    Console.WriteLine("Connection successful.");
                    string query = "SELECT firstName,lastName,email FROM employees";
                    var cmd = new MySqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string firstName = reader.GetString("firstName");
                        string lastName = reader.GetString("lastName");

                        Console.WriteLine($"first name: {firstName}, last name: {lastName}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }
}
