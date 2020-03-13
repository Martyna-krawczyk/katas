using System;

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaxCalculator.SetDefaultTaxBrackets();


            Console.WriteLine("Please input your first name:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Please input your surname:");
            string surnameInput = Console.ReadLine();

            double salary = OutputFormatter.ReadSalary();
            double super = OutputFormatter.ReadSuper();
            DateTime startDate = OutputFormatter.ValidateStartDate();
            DateTime endDate = OutputFormatter.ValidateEndDate();


            Employee employee = new Employee(OutputFormatter.FormatName(nameInput), OutputFormatter.FormatSurname(surnameInput), salary, super);

            Payslip payslip = new Payslip(startDate.ToString(), endDate.ToString());

            OutputFormatter.PrintPayslip(employee, payslip);
        }
    }
}
