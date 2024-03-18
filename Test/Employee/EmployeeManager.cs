using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using System;

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

        public string getEmployee(string[] args)
        {
            using (DbContext context = new uvsprojectContext())
            {
                (string field, string value) = parseParameter(args, 1);
                int id = int.Parse(value);
                Employee? employee = context.FindAsync<Employee>(id).Result;

                if (employee == null) { 
                    throw new Exception(("Could not retrieve employee with id " + value));
                }

                return employee.Employeename + " " + employee.Employeesalary;
            }
        }

        public void setEmployee(string[] args)
        {
            using (DbContext context = new uvsprojectContext())
            {

            }
        }

        private (string, string) parseParameter(string[] args, int index)
        {
            switch (args[index]) { }
        }

    }
}
