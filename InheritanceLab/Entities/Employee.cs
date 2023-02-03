using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLab.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected string sin;
        protected string birthdate;
        protected string department;

        public string Id
        {
            get 
            { 
                return id;  
            }
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
        }

        public string Address
        {
            get 
            { 
                return address; 
            }
        }

        public string Phone
        {
            get 
            { 
                return phone; 
            }
        }

        public string Sin
        {
            get 
            { 
                return sin; 
            }
        }

        public string Birthdate
        {
            get 
            { 
                return birthdate; 
            }   
        }

        public string Department
        {
            get 
            { 
                return department; 
            }
        }

        public Employee()
        {

        }

        public Employee(string id, string name, string address, string phone, string sin, string birthdate, string department)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthdate = birthdate;
            this.department = department;
        }
    }
}
