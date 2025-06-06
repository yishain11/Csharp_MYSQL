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

        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                Console.WriteLine("Connection successful.");
            }

            return _conn;
        }

        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }

        public DAL()
        {
            try
            {
                openConnection();
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

        public List<Employee> getEmployees(string query = "SELECT * FROM employees")
        {
            List<Employee> empList = new List<Employee>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int employeeNumber = reader.GetInt32("employeeNumber");
                    string lastName = reader.GetString("lastName");
                    string firstName = reader.GetString("firstName");
                    string jobTitle = reader.GetString("jobTitle");

                    Employee emp = new Employee(employeeNumber, firstName, lastName, jobTitle);
                    empList.Add(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching employees: {ex.Message}");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }

            return empList;
        }
    }
}
