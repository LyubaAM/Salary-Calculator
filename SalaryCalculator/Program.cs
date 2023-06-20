// See https://aka.ms/new-console-template for more information
using SalaryCalculator;
using SalaryCalculator.Calculators;
using SalaryCalculator.Enums;

Console.WriteLine("Calculate net salary application.");
bool enterNewGrossSalary = true;
int i = 0;

double grossSalary;
CountryCalculatorsEnums chooseCalculator = CountryCalculatorsEnums.Imaginaria; //Default for Imaginaria
ISalaryCalculator salaryCalc;

while (enterNewGrossSalary) //On every cycle the user could enter a gross salary, select country calculator and see the calculated net salary.
{
    Console.Write("Enter the gross salary: ");
    try
    {
        grossSalary = Convert.ToDouble(Console.ReadLine());

        i = 0;
        Console.WriteLine("Choose one of the following country calculator:");
        foreach (string calculator in Enum.GetNames<CountryCalculatorsEnums>()) //display the available calculators
        {
            Console.WriteLine(string.Format("{0} : {1}", i, $"{calculator}"));
            i++;
        }
        Console.WriteLine();
        chooseCalculator = (CountryCalculatorsEnums)Convert.ToInt16(Console.ReadLine());    //choose a calculator

        salaryCalc = CalculatorFactory.Create("SalaryCalculator" + chooseCalculator.ToString(), grossSalary);   //create instance of the choosen calculator

        salaryCalc.CalculateNetSalary();
        salaryCalc.ShowNetSalary();
    }
    catch (Exception ex)
    {
        if (ex.InnerException != null)
        {
            Console.WriteLine(ex.InnerException.Message);
        }
        else
        {
            Console.WriteLine(ex.Message);
        }
    }

    Console.Write("Do you want to enter a new gross salary (Y/N): ");   //decide if a new gross salary should be entered
    enterNewGrossSalary = Console.ReadLine().ToUpper().Equals("Y") ? true : false;
    Console.WriteLine();
}
