using System;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;

namespace EmployeeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            switch(args[0])
            {
                case "get-employee":
                    Console.WriteLine(EmployeeManager.GetInstance().getEmployee(args));
                    break;
                case "set-employee":
                    EmployeeManager.GetInstance().setEmployee(args);
                    break;
                default:
                    throw new InvalidOperationException("Initial parameter must be get-employee or set-employee");
            }
        }
    }
}
