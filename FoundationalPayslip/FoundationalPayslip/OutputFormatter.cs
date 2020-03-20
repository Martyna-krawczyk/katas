using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FoundationalPayslip
{
    public class OutputFormatter
    {
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        

    public static string FormatName()
    {
        string name;
        do
        {
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Oops: Please try again. Please enter your name");
            }
        } while (String.IsNullOrWhiteSpace(name));
            
        return myTI.ToTitleCase(name);
    }


    public static string FormatSurname()
    {
        string surname;
        do
        {
            Console.WriteLine("Please enter your surname:");
            surname = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Oops: Please try again. Please enter your surname");
            }
        } while (String.IsNullOrWhiteSpace(surname));
            
        return myTI.ToTitleCase(surname);
    }


        public static DateTime ValidateStartDate()
        {
            Console.WriteLine("Please enter your payment start date (DD/MM/YYYY):");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    
                    return startDate;
                    
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
            Console.WriteLine(
                "\nYour payslip has been generated:\n\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {payslip.StartDate.ToString()} - {payslip.EndDate.ToString()}\n" +
                $"Gross Income: {FormatGrossIncome(employee)}\n" +
                $"Income Tax: {FormatIncomeTax(employee)}\n" +
                $"Net Income: {FormatNetIncome()}\n" +
                $"Super: {FormatSuperValue(employee)}\n\n" +
                "Thank you for using MYOB!"
                );
        }
    }
}
