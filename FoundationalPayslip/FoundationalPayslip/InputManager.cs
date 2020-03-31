using System;
using System.Diagnostics;


namespace FoundationalPayslip
{
    public class InputManager
    {
        public string AskName()
        {
            string name;
            do
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();

                if (Validator.IsValidName(name))
                {
                    Console.WriteLine("Oops: You have not entered your name, or what you've input is not valid");
                }
            } while (Validator.IsValidName(name));
            
            return name;
        }

        public string AskSurname()
        {
            string surname;
            do
            {
                Console.WriteLine("Please enter your surname:");
                surname = Console.ReadLine();

                if (Validator.IsValidName(surname))
                {
                    Console.WriteLine("Oops: You have not entered your surname, or what you've input is not valid");
                }
            } while (Validator.IsValidName(surname));

            return surname;
        }

        public DateTime AskStartDate()
        {
            string startDate;
            string format = "dd/MM";
            
            Console.WriteLine("Please enter your payment start date (dd/MM):");
            while (true)
            {
                startDate = Console.ReadLine();
                
                if (Validator.CanDateBeParsed(startDate, format))
                {
                    return DateTime.ParseExact(startDate, format, null );
                }
                Console.WriteLine("Please enter a valid start date");
            }
        }
        
        public DateTime AskEndDate()
        {
            string endDate;
            string format = "dd/MM";
            
            Console.WriteLine("Please enter your payment end date (DD/MM):"); 
            while (true)
            {
                endDate = Console.ReadLine();
                
                if (Validator.CanDateBeParsed(endDate, format))
                {
                    return DateTime.ParseExact(endDate, format, null );
                }
                Console.WriteLine("Please enter a valid start date");
            }
        }
    }
}