using SalaryCalculator.Calculators;

namespace SalaryCalculator
{
    /// <summary>
    /// Factory for creating a calculator instance depending on the choice of country calculator
    /// </summary>
    public static class CalculatorFactory
    {
        public static ISalaryCalculator Create(string CalculatorName, double param)
        {
            var type = Type.GetType(typeof(ISalaryCalculator).Namespace + "." + CalculatorName, throwOnError: false);

            if (type == null)
            {
                throw new InvalidOperationException(CalculatorName.ToString() + " is not a known Salary Calculator type");
            }

            if (!typeof(ISalaryCalculator).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(type.Name + " does not inherit from ISalaryCalculator");
            }

            return (ISalaryCalculator)Activator.CreateInstance(type, param);
        }
    }
}
