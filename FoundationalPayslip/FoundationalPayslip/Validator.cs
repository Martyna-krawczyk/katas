using System;
using System.Globalization;

namespace FoundationalPayslip
{
    public class Validator : IValidator
    {
        public static bool IsValidName(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public static bool CanDateBeParsed(string date, string format)  
        {
            string[] dateFormat = { format };
            return DateTime.TryParseExact(date, dateFormat, new CultureInfo("en-US"),
                DateTimeStyles.None, out _);
        }

        public double ReadSalary() 
        {
            //Console.WriteLine("Please enter your annual salary:");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double salary))
                {
                    return salary;
                }
                Console.WriteLine("Please enter a valid salary");
            }
        }

        public double ReadSuper()
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
    }
}