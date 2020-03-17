using System;
using System.Globalization;

namespace FoundationalPayslip
{
    public class OutputFormatter
    {
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        public static string FormatName(string nameInput)
        {
            return myTI.ToTitleCase(nameInput);
        }


        public static string FormatSurname(string surnameInput)
        {
            return myTI.ToTitleCase(surnameInput);
        }


        public static DateTime ValidateStartDate()
        {
            Console.WriteLine("Please enter your payment start date (DD/MM/YYYY):");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime StartDate))
                {
                    
                    return StartDate;
                    
                }
                Console.WriteLine("Please enter a valid start date");
            }
        }


        public static DateTime ValidateEndDate()
        {
            Console.WriteLine("Please enter your payment end date (DD/MM/YYYY):"); 
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {

                    
                    return endDate;
                }
                Console.WriteLine("Please enter a valid end date");
            }
        }


        public static double FormatGrossIncome(Employee employee)
        {
            return Math.Round(Calculator.ReturnGrossIncome(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }


        public static double FormatIncomeTax(Employee employee)
        {
            return Math.Round(Calculator.CalculateIncomeTax(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }


        public static double FormatNetIncome()
        {
            return Math.Round(Calculator.ReturnNetIncome(), 0, MidpointRounding.AwayFromZero);
        }


        public static double FormatSuperValue(Employee employee)
        {
            return Math.Round(Calculator.CalculateSuper(Calculator.ReturnGrossIncome(employee.Salary), employee.SuperRate), 0, MidpointRounding.AwayFromZero);
        }


        public static double ReadSalary()
        {
            Console.WriteLine("Please enter your annual salary:");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double salary))
                {
                    return salary;
                }
                Console.WriteLine("Please enter a valid salary");
            }
        }


        public static double ReadSuper()
        {
            Console.WriteLine("Please enter your super rate:");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double superRate))
                {
                    return superRate;
                }
                Console.WriteLine("Please enter a valid super rate");
            }
        }


        public static void PrintPayslip(Employee employee, Payslip payslip)
        {
            string startString = ValidateStartDate().ToString("dd MMMM");

            Console.WriteLine(
                "\nYour payslip has been generated:\n\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {startString} - {payslip.EndDate.ToString()}\n" +
                $"Gross Income: {FormatGrossIncome(employee)}\n" +
                $"Income Tax: {FormatIncomeTax(employee)}\n" +
                $"Net Income: {FormatNetIncome()}\n" +
                $"Super: {FormatSuperValue(employee)}\n\n" +
                "Thank you for using MYOB!"
                );
        }
    }
}
