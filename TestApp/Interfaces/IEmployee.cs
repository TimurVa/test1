namespace TestApp.Interfaces
{
    public interface IEmployee
    {
        /// <summary>
        /// it is not necessary to make it double because in test case there are only integers
        /// </summary>
        double Salary { get; set; }

        string Position { get; set; }

        double Bonus { get; set; }

        double CalculateSalary();
    }

}
