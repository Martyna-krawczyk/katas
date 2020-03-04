using System;
namespace FoundationalPayslip
{
    public class Payslip
    {
        public static void ReturnPayslip(Employee employee)
        {
            int grossIncome = Calculations.returnGrossIncome(employee.SalaryInt);

            Console.WriteLine("\nYour payslip has been generated:\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {Employee.setStart(employee.startDate).ToString("dd MMMM")}\n" +
                $"Gross Income: {grossIncome}\n" +
                $"Income Tax: {Calculations.CalculateIncomeTax(employee.SalaryInt)}\n" +
                $"Net Income: {Calculations.ReturnNetIncome()}\n" +
                $"Super: {Calculations.CalculateSuper(grossIncome, employee.SuperRateInt)}\n" +
                "Thank you for using MYOB!"
                );
            //Console.WriteLine($"Name: {employee.Name} {employee.Surname}");
            //Console.WriteLine($"Pay Period: {Employee.setStart(employee.startDate).ToString("dd MMMM")} - {Employee.setEnd(employee.EndDate).ToString("dd MMMM")} ");
            //Console.WriteLine($"Gross Income: {grossIncome}");
            //Console.WriteLine($"Income Tax: {Calculations.CalculateIncomeTax(employee.SalaryInt)}");
            //Console.WriteLine($"Net Income: {Calculations.ReturnNetIncome()}");
            //    Console.WriteLine($"Super: {Calculations.CalculateSuper(grossIncome, employee.SuperRateInt)} \n");
            //    Console.WriteLine("Thank you for using MYOB!");
        }
    } 
}



