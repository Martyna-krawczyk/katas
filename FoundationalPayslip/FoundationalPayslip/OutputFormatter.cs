using System;
using System.Linq;
using System.Text;

namespace FoundationalPayslip
{
    public class OutputFormatter
    {

        //public static string ReadName() //I would like to set up this validation on the name and surname, but feel I still need some more time to fully understand why this doesn't run.
        //{
        //    Console.WriteLine("Please input your name:");

        //    string name = Console.ReadLine();

        //    while (true)
        //    {
        //        if (string.IsNullOrWhiteSpace(name))
        //        {
        //            Console.WriteLine("Please enter a valid name");   
        //        }
        //        return name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1);
        //    }

        //}

        public static string FormatName(string nameInput)
        {
            return nameInput[0].ToString().ToUpper() + nameInput.Substring(1, nameInput.Length - 1); //ToTitleCase() - check this out  whitespace?? Is it worth spending more time on formats?
        }


        public static string FormatSurname(string surnameInput)
        {
            return surnameInput[0].ToString().ToUpper() + surnameInput.Substring(1, surnameInput.Length - 1);
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

        //public static string FormatPayPeriod(Payslip payslip)
        //{
        //    //DateTime dT = DateTime.ParseExact(StartDate.ToString());
        //    //string s = dT.ToString("dd MMMM", CultureInfo.InvariantCulture);

        //    //return s;
        //    return payslip.StartDate.ToString("dd MMMM") + " - " + payslip.EndDate.ToString("dd MMMM");
        //}


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
