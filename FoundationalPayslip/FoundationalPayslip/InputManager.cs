using System;
    

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

        public void AskSalary()
        {
            Console.WriteLine("Please enter your annual salary:");
        }
    }
}