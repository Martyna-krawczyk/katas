using System;

namespace FoundationalPayslip
{
    class Program
    {

        static void Main(string[] args)
        {
            double incomeTax;
            double roundedIncomeTax;
            int grossIncome;
            double roundedSuperValue;


            Console.WriteLine("Please input your name:");
            string name = Console.ReadLine();
            string nameCapitalised = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1);


            Console.WriteLine("Please input your surname:");
            string surname = Console.ReadLine();
            string surnameCapitalised = surname[0].ToString().ToUpper() + surname.Substring(1, surname.Length - 1);


            Console.WriteLine("Please enter your annual salary:");
            int salary = 0;
            string annualSalary = Console.ReadLine();
            if (!int.TryParse(annualSalary, out salary)) //is this the best way to convert the string to integer?
            {
                Console.WriteLine("The salary tryparse has failed");
            }
                grossIncome = salary / 12;

            if (salary >= 180001) {

                incomeTax = (54232 + (salary - 180000) * 0.45) / 12;
                roundedIncomeTax = Math.Round(incomeTax, 0, MidpointRounding.ToEven);
               
            } else if (salary >= 87001 && salary <= 180000)
            {
                incomeTax = (19822 + (salary - 87000) * 0.37) / 12;
                roundedIncomeTax = Math.Round(incomeTax, 0, MidpointRounding.ToEven);

            } else if (salary >= 37001 && salary <= 87000)
            {
                incomeTax = (3572 + (salary - 37000) * 0.325) / 12;
                roundedIncomeTax = Math.Round(incomeTax, 0, MidpointRounding.ToEven);

            } else if (salary >= 18201 && salary <= 37000)
            {
                incomeTax = ((salary - 18200) * 0.19) / 12;
                roundedIncomeTax = Math.Round(incomeTax, 0, MidpointRounding.ToEven);
            } else
            {
                roundedIncomeTax = 0;
            }

            double v = grossIncome - roundedIncomeTax;
            int netIncome = (int)v;


            Console.WriteLine("Please enter your super rate:");
            int super = 0;
            string superRate = Console.ReadLine();
            if(!int.TryParse(superRate, out super))
            {
                Console.WriteLine("The super tryparse has failed");
            }
            double superValue = (grossIncome * super) / 100;
            
            roundedSuperValue = Math.Round(superValue, 0, MidpointRounding.ToEven);



            Console.WriteLine("Please enter your payment start date:");
            string startDate = Console.ReadLine();

            Console.WriteLine("Please enter your payment end date:");
            string endDate = Console.ReadLine();



            ReturnPayslip(nameCapitalised, surnameCapitalised, startDate, endDate, grossIncome, roundedIncomeTax, roundedSuperValue, netIncome);


            static void ReturnPayslip(string nameCapitalised, string surnameCapitalised, string startDate, string endDate, int grossIncome, double roundedIncomeTax, double roundedSuperValue, int netIncome)
            {

                Console.WriteLine("\nYour payslip has been generated:\n");
                Console.WriteLine($"Name: {nameCapitalised} {surnameCapitalised}");
                Console.WriteLine($"Pay Period: {startDate} - {endDate}");
                Console.WriteLine($"Gross Income: {grossIncome}");
                Console.WriteLine($"Income Tax: {roundedIncomeTax}");
                Console.WriteLine($"Net Income: {netIncome}");
                Console.WriteLine($"Super: {roundedSuperValue} \n");
                Console.WriteLine("Thank you for using MYOB!");

            }
        }
    }
}
