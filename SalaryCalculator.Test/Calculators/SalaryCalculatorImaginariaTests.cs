using SalaryCalculator.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Test.Calculators
{
    [TestFixture]
    public class SalaryCalculatorImaginariaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateNetSalary_WithSalaryLessThanTaxFreeAmount_ReturnsSameSallary()
        {
            //Arrange
            double grossSalary = 980;
            SalaryCalculatorImaginaria salaryCalculator = new SalaryCalculatorImaginaria(grossSalary);

            //Act
            salaryCalculator.CalculateNetSalary();

            //Assert
            Assert.That(salaryCalculator.NetSalary.Equals(980));
        }

        [Test]
        public void CalculateNetSalary_WithSalaryGreaterThanTaxFreeAmountAndGreaterThanSocialContributionTaxFreeAmount_ReturnsCorrectSallary()
        {
            //Arrange
            double grossSalary = 3400;
            SalaryCalculatorImaginaria salaryCalculator = new SalaryCalculatorImaginaria(grossSalary);

            //Act
            salaryCalculator.CalculateNetSalary();

            //Assert
            Assert.That(salaryCalculator.NetSalary.Equals(2860));
        }

        [Test]
        public void CalculateNetSalary_WithSalaryGreaterThanTaxFreeAmountAndLessThanSocialContributionTaxFreeAmount_ReturnsCorrectSallary()
        {
            //Arrange
            double grossSalary = 2400;
            SalaryCalculatorImaginaria salaryCalculator = new SalaryCalculatorImaginaria(grossSalary);

            //Act
            salaryCalculator.CalculateNetSalary();

            //Assert
            Assert.That(salaryCalculator.NetSalary.Equals(2050));
        }

        [Test]
        public void CalculateNetSalary_WithSalaryLessThanZero_ThrowsException()
        {
            //Arrange
            double grossSalary = -1;
            Action init = () => new SalaryCalculatorImaginaria(grossSalary);

            //Act/Assert
            Assert.That(init, Throws.TypeOf<ArgumentException>());
        }
    }
}
