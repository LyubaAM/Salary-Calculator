
namespace SalaryCalculator.Calculators
{
    /// <summary>
    /// Salary calculator for Imaginaria
    /// </summary>
    public class SalaryCalculatorImaginaria : ISalaryCalculator
    {
        private const double TAX_FREE_AMOUNT = 1000;
        private const double SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT = 3000;

        private double _grossSalary;
        private double _netSalary;

        /// <summary>
        /// Gross salary property
        /// </summary>
        public double GrossSalary
        {
            get
            {
                return _grossSalary;
            }
            set
            {
                _grossSalary = value;
            }
        }

        /// <summary>
        /// Net salary property
        /// </summary>
        public double NetSalary
        {
            get
            {
                return _netSalary;
            }
            set
            {
                _netSalary = value;
            }
        }

        /// <summary>
        /// SalaryCalculatorImaginaria constructor. 
        /// If the input gross salary is less than zero then an ArgumentException is thrown.
        /// </summary>
        /// <param name="grossSalary">The input gross salary</param>
        /// <exception cref="ArgumentException">If the input gross salary is less than zero then an ArgumentException is thrown.</exception>
        public SalaryCalculatorImaginaria(double grossSalary)
        {
            if (grossSalary >= 0)
                _grossSalary = grossSalary;
            else
                throw new ArgumentException(string.Format("The salary could not be less than zero: {0}", grossSalary));
        }

        /// <summary>
        /// Calculates the net salary
        /// </summary>
        public void CalculateNetSalary()
        {
            if (_grossSalary <= TAX_FREE_AMOUNT)    //check if the gross salary is less than tax free amount
                _netSalary = _grossSalary;
            else
            {
                double income;
                income = _grossSalary - TAX_FREE_AMOUNT;    //income on which the income tax should be calculated
                _netSalary = _grossSalary - CalculateIncomeTax(income);

                income = _grossSalary > SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT ? SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT - TAX_FREE_AMOUNT :  _grossSalary - TAX_FREE_AMOUNT;  //income on which the social contributions should be calculated
                _netSalary = _netSalary - CalculateSocialContributions(income);
            }
        }

        /// <summary>
        /// Displays the net salary as decimal number with two digits after the decimal point
        /// </summary>
        public void ShowNetSalary()
        {
            Console.WriteLine("The net salary is {0:f2}.", _netSalary);
        }

        /// <summary>
        /// Calculates the income tax
        /// </summary>
        /// <param name="income">Income on which the tax is calculated</param>
        /// <returns>Calculated tax</returns>
        private double CalculateIncomeTax(double income)
        {
            return 0.1 * income;    //10%
        }

        /// <summary>
        /// Calculates the social contributions
        /// </summary>
        /// <param name="income">Income on which the social contributions are calculated</param>
        /// <returns>Calculated social contributions</returns>
        private double CalculateSocialContributions(double income)
        {
            return 0.15 * income;   //15%
        }
    }
}
