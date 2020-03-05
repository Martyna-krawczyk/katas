using System;
namespace FoundationalPayslip
{
    public class Payslip
    {
        public static void ReturnPayslip(Employee employee)
        {
            double grossIncome = Calculations.ReturnGrossIncome(employee.Salary);

            Console.WriteLine(
                "\nYour payslip has been generated:\n\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {OutputFormatter.FormatPayPeriod(employee)}\n" +
                $"Gross Income: {OutputFormatter.FormatGrossIncome(employee)}\n" +
                $"Income Tax: {OutputFormatter.FormatIncomeTax(employee)}\n" +
                $"Net Income: {OutputFormatter.FormatNetIncome()}\n" +
                $"Super: {OutputFormatter.FormatSuperValue(employee)}\n\n" +
                "Thank you for using MYOB!"
                );
        }
    } 
}



