using System;
using System.Collections.Generic;
using c__SQL.BasicConnetion;
using c__SQL.DAL;
using c__SQL.Models;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        // basic connection
        //BasicConnection bc = new BasicConnection();
        //bc.CreateBasicConnection();

        // DAL
        DAL dal = new DAL();
        List<Employee> allEmpList = dal.getEmployees();
        List<Employee> FilteredEmpList = dal.getEmployees("SELECT * FROM employees WHERE firstName LIKE '%D%' ");
        foreach (Employee emp in FilteredEmpList)
        {
            emp.printDetails();
        }
    }
}
