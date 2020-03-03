using System;


namespace FoundationalPayslip
{
    public class Employee
    {
        public static string nameCapitalised;
        public static string surnameCapitalised;
        public static int salary;
        public static int superRate;
        public static string startDate;
        public static string endDate;


        public static string inputName()
        {
            Console.WriteLine("Please input your name:");
            string name = Console.ReadLine();
            nameCapitalised = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1); //save this for the payslip generator??
            
            return nameCapitalised;
        }


        public static string inputSurname()
        {
            Console.WriteLine("Please input your surname:");
            string surname = Console.ReadLine();
            surnameCapitalised = surname[0].ToString().ToUpper() + surname.Substring(1, surname.Length - 1);

            return surnameCapitalised;
        }


        public static int inputSalary()
        {
            Console.WriteLine("Please enter your annual salary:");
           
            string annualSalary = Console.ReadLine();
            if (!int.TryParse(annualSalary, out salary))
            {
                Console.WriteLine("The salary tryparse has failed");
            }
            
            Calculations.CalculateIncomeTax(salary);
            return salary;

        }


        public static int inputSuper()
        {
            Console.WriteLine("Please enter your super rate:");
            string super = Console.ReadLine();
            if (!int.TryParse(super, out superRate))
            {
                Console.WriteLine("The super tryparse has failed");
            }
            return superRate;

            
        }


        public static string inputStart() //could this be set up as a DateTime field?
        {
            Console.WriteLine("Please enter your payment start date:");
            startDate = Console.ReadLine();

            return startDate;
        }

        public static string inputEnd()
        {
            Console.WriteLine("Please enter your payment end date:");
            endDate = Console.ReadLine();

            return endDate;
        }




        public static void ReturnPayslip()
        {
            int grossIncome = Calculations.returnGrossIncome(salary);
            


            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine($"Name: {nameCapitalised} {surnameCapitalised}");
            Console.WriteLine($"Pay Period: {startDate} - {endDate}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {Calculations.CalculateIncomeTax(salary)}");
            Console.WriteLine($"Net Income: {Calculations.ReturnNetIncome()}");
            Console.WriteLine($"Super: {Calculations.CalculateSuper(grossIncome, superRate)} \n");
            Console.WriteLine("Thank you for using MYOB!");

        }



    }
}

