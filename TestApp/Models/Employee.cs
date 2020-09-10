using System;
using TestApp.Interfaces;

namespace TestApp.Models
{
    public class Employee : IEmployee
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        public double Bonus { get; set; }

        public virtual double CalculateSalary()
        {
            return Salary + Bonus;
        }
    }
}
