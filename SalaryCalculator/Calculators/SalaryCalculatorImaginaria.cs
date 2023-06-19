
namespace SalaryCalculator.Calculators
{
    public class SalaryCalculatorImaginaria : ISalaryCalculator
    {
        private const double TAX_FREE_AMOUNT = 1000;
        private const double SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT = 3000;

        private double _grossSalary;
        private double _netSalary;

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

        public SalaryCalculatorImaginaria(double grossSalary)
        {
            if (grossSalary >= 0)
                _grossSalary = grossSalary;
            else
                throw new ArgumentException(string.Format("The salary could not be less than zero: {0}", grossSalary));
        }

        public void CalculateNetSalary()
        {
            if (_grossSalary <= TAX_FREE_AMOUNT)
                _netSalary = _grossSalary;
            else
            {
                double income;
                income = _grossSalary - TAX_FREE_AMOUNT;
                _netSalary = _grossSalary - CalculateIncomeTax(income);

                income = _grossSalary > SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT ? SOCIAL_CONTRIBUTION_TAX_FREE_AMOUNT - TAX_FREE_AMOUNT :  _grossSalary - TAX_FREE_AMOUNT;
                _netSalary = _netSalary - CalculateSocialContributions(income);
            }
        }

        public void ShowNetSalary()
        {
            Console.WriteLine("The net salary is {0:f2}.", _netSalary);
        }

        private double CalculateIncomeTax(double income)
        {
            return 0.1 * income;
        }

        private double CalculateSocialContributions(double income)
        {
            return 0.15 * income;
        }
    }
}
