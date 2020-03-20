using System;

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = OutputFormatter.FormatName();
            string surname = OutputFormatter.FormatSurname();
            double salary = OutputFormatter.ReadSalary();
            double super = OutputFormatter.ReadSuper();
            DateTime startDate = OutputFormatter.ValidateStartDate();
            DateTime endDate = OutputFormatter.ValidateEndDate();

            Employee employee = new Employee(name, surname, salary, super);

            Payslip payslip = new Payslip(startDate.ToString(), endDate.ToString());

            OutputFormatter.PrintPayslip(employee, payslip);
        }
    }
}
