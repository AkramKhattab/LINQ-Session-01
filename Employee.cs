using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Session_01
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, int age, string department, decimal salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Department = department;
            Salary = salary;
        }
    }
}
