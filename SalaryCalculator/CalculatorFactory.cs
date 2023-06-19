using SalaryCalculator.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
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
