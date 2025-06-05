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
        List<Employee> empList = dal.getEmployees();
        foreach (Employee emp in empList)
        {
            emp.printDetails();
        }
    }
}
