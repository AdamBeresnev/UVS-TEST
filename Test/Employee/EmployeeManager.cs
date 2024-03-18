using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EmployeeManager
{
    public class EmployeeManager
    {
        private static readonly EmployeeManager instance = new EmployeeManager();

        private EmployeeManager() { }

        public static EmployeeManager GetInstance()
        {
            return instance;
        }

        public void getEmployee(Dictionary<string, string> parameters)
        {
            using (DbContext context = new uvsprojectContext())
            {
                try
                {
                    int id = int.Parse(parameters.GetValueOrDefault("--employeeId") 
                        ?? throw new Exception("Incorrect employeeId"));
                    Employee employee = context.FindAsync<Employee>(id).Result
                        ?? throw new Exception("Could not retrieve employee with id " + id);

                    Console.WriteLine(employee.ToString());

                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Parameter {0} missing", e);
                }
            }
        }

        public void setEmployee(Dictionary<string, string> parameters)
        {
            using (DbContext context = new uvsprojectContext())
            {
                try
                {
                    int id = int.Parse(parameters.GetValueOrDefault("--employeeId")
                        ?? throw new Exception("Incorrect employeeId"));
                    string name = parameters.GetValueOrDefault("--employeeName")
                        ?? throw new Exception("Incorrect employeeName");
                    int salary = int.Parse(parameters.GetValueOrDefault("--employeeSalary")
                        ?? throw new Exception("Incorrect employeeSalary"));

                    Employee employee = new Employee();
                    employee.Employeeid = id;
                    employee.Employeename = name;
                    employee.Employeesalary = salary;

                    context.Add(employee);
                    context.SaveChanges();
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Parameter {0} missing", e);
                }
            }
        }
    }
}
