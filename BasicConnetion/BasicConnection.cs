using MySql.Data.MySqlClient;
using System;

namespace c__SQL.BasicConnetion
{
    internal class BasicConnection
    {
        private string connStr = "server=localhost;user=root;password=;database=classicmodels";
        private MySqlConnection _conn;
        public void CreateBasicConnection()
        {
            try
            {
                this._conn = new MySqlConnection(connStr);
                this._conn.Open();
                Console.WriteLine("Connection successful.");
                string query = "SELECT firstName,lastName,email FROM employees";
                var cmd = new MySqlCommand(query, this._conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string firstName = reader.GetString("firstName");
                    string lastName = reader.GetString("lastName");

                    Console.WriteLine($"first name: {firstName}, last name: {lastName}");
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
            finally { 
                this._conn.Close();
            }
        }
    }
}
