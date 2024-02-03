using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array for file lines
            string[] employees = File.ReadAllLines("C:/cprg211/labs/lab-2/Lab2/res/employees.txt");

            //list for employee objects
            List<Employee> newEmployees = new List<Employee>();
            double s = 0; // salaried employees
            double w = 0; //waged employees
            double p = 0; //num par-time employees


            foreach (string employee in employees)
            {
                // array for line data
                string[] employeeData = employee.Split(":");

                //Convert sin to long index[4]
                long sin;
                long.TryParse(employeeData[4], out sin);


                // subtract char '0' to find the integer value of what the id (index[0]) starts with
                int idStart = employeeData[0][0] - '0';

                //determine if each employee is salaried, waged, or part-time, then construct accordingly and add to a new list of employee objects
                //Salaried employees have ID numbers starting with 0–4
                if (0 <= idStart && idStart <= 4)
                {

                    //convert salary to double index 7
                    double salary;
                    double.TryParse(employeeData[7], out salary);

                    // 8 indexes that correspond to the order of the salaried constructor
                    Salaried newEmployee = new Salaried(employeeData[0], employeeData[1], employeeData[2], employeeData[3], sin, employeeData[5], employeeData[6], salary);
                    Console.WriteLine(newEmployee);
                    newEmployees.Add(newEmployee);
                    s++;
                }

                //wage employee’s IDs start with 5–7
                else if (5 <= idStart && idStart <= 7)
                {
                    //convert hours and rate to double
                    double rate; //index[7]
                    double hours; //index[8]

                    double.TryParse(employeeData[7], out rate);
                    double.TryParse(employeeData[8], out hours);

                    // 9 indexes that correspond to the order of the parttime constructor
                    Wages newEmployee = new Wages(employeeData[0], employeeData[1], employeeData[2], employeeData[3], sin, employeeData[5], employeeData[6], rate, hours);
                    Console.WriteLine(newEmployee);
                    newEmployees.Add(newEmployee);
                    w++;
                }

                //part-time employee’s IDs start with 8–9
                else
                {
                    //convert hours and rate to double
                    double rate; //index[7]
                    double hours; //index[8]

                    double.TryParse(employeeData[7], out rate);
                    double.TryParse(employeeData[8], out hours);

                    // 9 indexes that correspond to the order of the wages constructor
                    PartTime newEmployee = new PartTime(employeeData[0], employeeData[1], employeeData[2], employeeData[3], sin, employeeData[5], employeeData[6], rate, hours);
                    Console.WriteLine(newEmployee);
                    newEmployees.Add(newEmployee);
                    p++;
                }
            }
            double totPay = 0.0;
            double numEmployees = 0;

            //empty objects to reassign low and high pays to
            Wages highestWages = new Wages();
            
            Salaried lowestSalary = new Salaried();

            foreach (Employee e in newEmployees)
            {
                //Calculate and return the average weekly pay for all employees

                totPay += e.GetPay();
                numEmployees++;
                int idStart = e.id[0] - '0';

                if (e == newEmployees.Last())
                {
                    double avgPay = totPay / numEmployees;

                    Console.WriteLine($"The average pay is: ${avgPay}\n");
                }
                
                //Calculate and return the highest weekly pay for the wage employees, including the name of the employee

                if ((e.GetPay() > highestWages.GetPay()) && (5 <= idStart && idStart <= 7))
                {
                    highestWages = (Wages)e;

                }

                //Calculate and return the lowest salary for the salaried employees, including the name of the employee
                if ((e.GetPay() < lowestSalary.GetPay()) && (0 <= idStart && idStart <= 4))
                {

                    lowestSalary = (Salaried)e;
                }
            }
            Console.WriteLine($"The highest Full-time wage is ${highestWages.GetPay()} for {highestWages.name}");
            Console.WriteLine($"The lowest salary is ${lowestSalary.GetPay()} for {lowestSalary.name}\n");

            //percentage of the company’s employees in each employee category
            double percentSalary = s / numEmployees * 100;
            double percentParttime = p / numEmployees * 100;
            double percentWaged = w/ numEmployees * 100;


            Console.WriteLine($"The percent of salaried employees: {Math.Round(percentSalary, 2)}%\n");
            Console.WriteLine($"The percent of Part-time employees: {Math.Round(percentParttime, 2)}%\n");
            Console.WriteLine($"The percent of Full-time employees: {Math.Round(percentWaged, 2)}%\n");

        }

        
    }
}
