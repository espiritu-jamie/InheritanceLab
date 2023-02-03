using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLab.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }

        public double Hours
        {
            get { return hours; }
        }

        public PartTime(string id, string name, string address, string phone, string sin, string birthdate, string department, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthdate = birthdate;
            this.department = department;
            this.rate = rate;
            this.hours = hours;
        }

        public double Pay
        {
            get
            {
                double rate = this.Rate;
                double hours = this.Hours;

                double pay = rate * hours;

                return pay;
            }

        }
    }
}
