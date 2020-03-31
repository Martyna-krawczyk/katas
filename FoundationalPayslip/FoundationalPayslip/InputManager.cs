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
            string format = "dd/MM";
            
            Console.WriteLine("Please enter your payment start date (dd/MM):");
            while (true)
            {
                var startDate = Console.ReadLine();
                
                if (Validator.CanDateBeParsed(startDate, format))
                {
                    return DateTime.ParseExact(startDate, format, null );
                }
                Console.WriteLine("Please enter a valid start date");
            }
        }
        
        public DateTime AskEndDate()
        {
            string format = "dd/MM";
            
            Console.WriteLine("Please enter your payment end date (DD/MM):"); 
            while (true)
            {
                var endDate = Console.ReadLine();
                
                if (Validator.CanDateBeParsed(endDate, format))
                {
                    return DateTime.ParseExact(endDate, format, null );
                }
                Console.WriteLine("Please enter a valid start date");
            }
        }
        
        public double AskSalary()
        {
            Console.WriteLine("Please enter your annual salary:");
            while (true)
            {
                var salary = Console.ReadLine();
                
                if (Validator.CanSalaryBeParsed(salary))
                {
                    return Convert.ToDouble(salary);
                }
                Console.WriteLine("Please enter a valid salary");
            }
        }
        
        public double AskSuper()
        {
            Console.WriteLine("Please enter your super rate:");
            while (true)
            {
                var super = Console.ReadLine();
                
                if (Validator.CanSuperBeParsed(super))
                {
                    return Convert.ToDouble(super);
                }
                Console.WriteLine("Please enter a valid super rate");
            }
        }
    }
}