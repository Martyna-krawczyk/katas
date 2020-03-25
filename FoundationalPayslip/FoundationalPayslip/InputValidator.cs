using System;
using System.Globalization;

namespace FoundationalPayslip
{
    public class InputValidator : IValidator
    {
        public string ReadName()
        {
            string name;
            do
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Oops: Please try again. Please enter your name");
                }
            } while (string.IsNullOrWhiteSpace(name));
            
            return name;
        }
        
        public string ReadSurname()
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

            return surname;
        }

        public double ReadSalary()
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