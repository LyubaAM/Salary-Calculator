
namespace SalaryCalculator.Calculators
{
    /// <summary>
    /// Interface for salary calculator
    /// </summary>
    public interface ISalaryCalculator
    {
        /// <summary>
        /// Calculates net salary
        /// </summary>
        void CalculateNetSalary();

        /// <summary>
        /// Displays the net salary
        /// </summary>
        void ShowNetSalary();
    }
}
