using c__SQL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace c__SQL.DAL
{
    internal class DAL
    {
        private string connStr = "server=localhost;user=root;password=;database=classicmodels";
        private MySqlConnection _conn;
        private MySqlCommand _command;

        public MySqlConnection openConnection() {
            if (this._conn == null) {
                this._conn = new MySqlConnection(connStr);
            }
            this._conn = new MySqlConnection(connStr);
            this._conn.Open();
            Console.WriteLine("Connection successful.");
            return this._conn;

        }
        public DAL() {
            try {
                this.openConnection();
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

        // get employees - all or filtered
        public List<Employee> getEmployees(string query = "SELECT * FROM employees") {
            List<Employee> empList = new List<Employee>();
            var cmd = new MySqlCommand(query, this._conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                int employeeNumber = reader.GetInt32("employeeNumber");
                string lastName = reader.GetString("lastName");
                string firstName = reader.GetString("firstName");
                string jobTitle = reader.GetString("jobTitle");
                Employee emp = new Employee(employeeNumber,firstName,lastName,jobTitle);
                empList.Add(emp);
    }       
            return empList;
        }
    }
}
