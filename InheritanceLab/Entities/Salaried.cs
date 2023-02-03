using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InheritanceLab.Entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get 
            { 
                return salary; 
            }
        }

        public double Pay
        {
            get
            {
                return salary;
            }
        }
        public Salaried(string id, string name, string address, string phone, string sin, string birthdate, string department, double salary)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthdate = birthdate;
            this.department = department;
            this.salary = salary;
        }
    }
}
