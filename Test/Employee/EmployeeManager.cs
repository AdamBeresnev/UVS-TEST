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
                        ?? throw new KeyNotFoundException("--employeeId"));
                    Employee employee = context.FindAsync<Employee>(id).Result
                        ?? throw new InvalidOperationException("Could not retrieve employee with id " + id);

                    Console.WriteLine(employee.ToString());
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Parameter {0} missing", e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
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
                        ?? throw new KeyNotFoundException("--employeeId"));
                    string name = parameters.GetValueOrDefault("--employeeName")
                        ?? throw new KeyNotFoundException("--employeeName");
                    int salary = int.Parse(parameters.GetValueOrDefault("--employeeSalary")
                        ?? throw new KeyNotFoundException("--employeeSalary"));

                    Employee employee = new Employee();
                    employee.Employeeid = id;
                    employee.Employeename = name;
                    employee.Employeesalary = salary;

                    context.Add(employee);
                    context.SaveChanges();
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Parameter {0} missing", e.Message);
                }
            }
        }
    }
}
