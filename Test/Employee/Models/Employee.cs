﻿namespace EmployeeManager.Models
{
    public partial class Employee
    {
        public int Employeeid { get; set; }
        public string Employeename { get; set; } = ""!;
        public int Employeesalary { get; set; }

        public override string ToString()
        {
            return Employeeid + " " + Employeename + " " + Employeesalary;
        }
    }
}
