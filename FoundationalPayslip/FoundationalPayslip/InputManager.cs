using System;
using System.Diagnostics;


namespace FoundationalPayslip
{
    public class InputManager
    {
        private IValidator _validator;

        public InputManager(IValidator validator)
        {
            _validator = validator;
        }

        public string AskName()
        {
            string name;
            do
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();

                if (_validator.IsValidName(name))
                {
                    Console.WriteLine("Oops: You have not entered your name, or what you've input is not valid");
                }
            } while (_validator.IsValidName(name));
            
            return name;
        }

        public string AskSurname()
        {
            string surname;
            do
            {
                Console.WriteLine("Please enter your surname:");
                surname = Console.ReadLine();

                if (_validator.IsValidName(surname))
                {
                    Console.WriteLine("Oops: You have not entered your surname, or what you've input is not valid");
                }
            } while (_validator.IsValidName(surname));

            return surname;
        }

        public DateTime AskStartDate()
        {
            string format = "dd/MM";
            
            Console.WriteLine("Please enter your payment start date (dd/MM):");
            while (true)
            {
                var startDate = Console.ReadLine();
                
                if (_validator.CanDateBeParsed(startDate, format))
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
                
                if (_validator.CanDateBeParsed(endDate, format))
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
                
                if (_validator.CanSalaryBeParsed(salary))
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
                
                if (_validator.CanSuperBeParsed(super))
                {
                    return Convert.ToDouble(super);
                }
                Console.WriteLine("Please enter a valid super rate");
            }
        }
    }
}