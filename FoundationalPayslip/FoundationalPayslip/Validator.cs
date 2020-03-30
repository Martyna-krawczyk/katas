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
        

        public double ReadSalary() //not really sure how to handle the readline output and assigning of variable with these ones.
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
        
        public DateTime ReadStartDate()
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
        
        public DateTime ReadEndDate()
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
        
    }
}