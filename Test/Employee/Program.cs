using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> arguments;
            switch (args[0])
            {
                case "get-employee":
                    arguments = parseArguments(args.Where(s => s != "get-employee").ToArray());
                    EmployeeManager.GetInstance().getEmployee(arguments);
                    break;
                case "set-employee": 
                    arguments = parseArguments(args.Where(s => s != "set-employee").ToArray());
                    EmployeeManager.GetInstance().setEmployee(arguments);
                    break;
                default:
                    throw new InvalidOperationException("Initial parameter must be get-employee or set-employee");
            }
        }

        private static Dictionary<string, string> parseArguments(string[] args)
        {
            Dictionary<string, string> parsedArguments = new Dictionary<string, string>();
            for (int i = 0; i < args.Length - 1; i += 2)
            {
                parsedArguments.Add(args[i], args[i + 1]);
            }
            return parsedArguments;
        }
    }
}
