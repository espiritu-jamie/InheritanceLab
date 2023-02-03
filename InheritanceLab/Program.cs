using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceLab.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace InheritanceLab

/// <remarks>Author: Jamie Espiritu </remarks>
/// <remarks>Date: Feb. 3, 2023</remarks>
/// <summary> Program calculates: the average weekly pay of the employees, name and pay of highest waged employee, 
/// name and pay of lowest salaried employee, and percentage of the company's employees that belong in each employee category </summary>
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "employees.txt";

            string[] lines;

            lines = File.ReadAllLines(path);

            // Create employee list
            List<Employee> employees = new List<Employee>();

            // Loop through each line from employees.txt and split each attribute
            foreach (string line in lines)
            {
                string[] parts;

                parts = line.Split(':');

                string id = parts[0];

                string name = parts[1];

                string address = parts[2];

                string phone = parts[3];

                string sin = parts[4];

                string birthdate = parts[5];

                string department = parts[6];

                // Determining the first digit of id to determine what type of employee
                string firstDigit;
                firstDigit = id.Substring(0,1);

                int firstDigitNum = int.Parse(firstDigit);

                // Salaried
                // example: if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    double salary = double.Parse(parts[7]);

                    // Create Salaried instance and add to employee list
                    Salaried salaried;

                    salaried = new Salaried(id, name, address, phone, sin, birthdate, department, salary);

                    employees.Add(salaried);
                }

                // Waged
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // Create Waged instance and add to employee list.
                    Waged waged = new Waged(id, name, address, phone, sin, birthdate, department, rate, hours);
                    employees.Add(waged);
                }

                // Part Time
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // Create PartTime instance and add to employee list.
                    PartTime partTime = new PartTime(id, name, address, phone, sin, birthdate, department, rate, hours);
                    employees.Add(partTime);
                }
                
            }
            
            // Calculating weekly average pay
            double weeklyPaySum = 0;
            
            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }

                else if (employee is Waged waged)
                {
                    double pay = waged.Pay;
                    weeklyPaySum += pay;
                }

                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;
                    weeklyPaySum += pay;
                }
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;
            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            // Checking highest weekly pay for waged employees and the name of the highest waged employee
            double highestWeeklyWage = 0;
            Waged highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    if (pay > highestWeeklyWage)
                    {
                        highestWeeklyWage = pay;
                        highestWagedEmployee = waged;
                    }
                }
            }

            Console.WriteLine(string.Format("The highest waged pay is: {0:C2}", highestWeeklyWage));
            Console.WriteLine("The highest waged employee is: " + highestWagedEmployee.Name);

            // Checking the lowest salary for the salaried employees and the name of the employee
            double lowestSalary = double.MaxValue;
            Salaried lowestSalariedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    if (pay < lowestSalary)
                    {
                        lowestSalary = pay;
                        lowestSalariedEmployee = salaried;
                    }
                }
            }

            Console.WriteLine(string.Format("The lowest salary is: {0:C2}", lowestSalary));
            Console.WriteLine("The lowest salaried employee is: " + lowestSalariedEmployee.Name);

            // Calculating the percentage of the company's employees that belong in each employee category

            double salariedEmployeeCount = 0;
            double wagedEmployeeCount = 0;
            double partTimeEmployeeCount = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    salariedEmployeeCount += 1;
                }

                else if (employee is Waged waged)
                {
                    wagedEmployeeCount += 1;
                }

                else if (employee is PartTime partTime)
                {
                    partTimeEmployeeCount += 1;
                }
            }

            double salariedPercent = salariedEmployeeCount / employees.Count;
            double wagedPercent = wagedEmployeeCount / employees.Count;
            double partTimePercent = partTimeEmployeeCount / employees.Count    ;

            Console.WriteLine(string.Format("The percentage of salaried employees is: {0:P2}", salariedPercent));
            Console.WriteLine(string.Format("The percentage of waged employees is: {0:P2}", wagedPercent));
            Console.WriteLine(string.Format("The percentage of part time employees is: {0:P2}", partTimePercent));

           
        }
    }
}
