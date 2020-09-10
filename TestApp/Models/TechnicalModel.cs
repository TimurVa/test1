using TestApp.Interfaces;

namespace TestApp.Models
{
    public class TechnicalModel : Employee, ITechnician
    {
        public string Category { get; set; }
        public override double CalculateSalary()
        {
            switch (Category)
            {
                case "A":
                    return (Salary + Bonus) + (Salary * 0.25);
                case "B":
                    return (Salary + Bonus) + (Salary * 0.15);
                case "C":
                    return Salary + Bonus;
            }
            // if category is empty
            // or throw exception
            return Salary + Bonus;
        }
    }
}
