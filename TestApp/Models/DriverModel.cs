using System;

namespace TestApp.Models
{
    public class DriverModel : Employee, IDriver
    {
        public double TimeWorked { get; set; }
        public string Category { get; set; }

        public override double CalculateSalary()
        {
            switch (Category)
            {
                case "A":
                    return ((Salary * TimeWorked) + Bonus) + (Salary * TimeWorked * 0.25);
                case "B":
                    return ((Salary * TimeWorked) + Bonus) + (Salary * TimeWorked * 0.15);
                case "C":
                    return ((Salary * TimeWorked) + Bonus);
            }
            // if category field is empty
            // or just throw an exception
            return ((Salary * TimeWorked) + Bonus);
        }
    }
}
