using System;
namespace FoundationalPayslip
{
    public class Payslip
    {

        public static void ReturnPayslip(Employee employee)
        {
            int grossIncome = Calculations.returnGrossIncome(employee.SalaryInt);



            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine($"Name: {employee.Name} {employee.Surname}");
            Console.WriteLine($"Pay Period: {Employee.setStart(employee.startDate)} - {Employee.setEnd(employee.EndDate)} ");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {Calculations.CalculateIncomeTax(employee.SalaryInt)}");
            Console.WriteLine($"Net Income: {Calculations.ReturnNetIncome()}");
            Console.WriteLine($"Super: {Calculations.CalculateSuper(grossIncome, employee.SuperRateInt)} \n");
            Console.WriteLine("Thank you for using MYOB!");

        }
    } 
}



