using System;


namespace FoundationalPayslip
{
    public class Employee
    {
        private string _name; //enforces the privacy
        private string _surname;
        private int _salaryInt;
        private int _superRateInt;
        private string _startDate;
        private string _endDate;

        public Employee(string name, string surname, int salaryInt, int superRateInt, string startDate, string endDate) 
        {
            _name = name; //_private c# convention
            _surname = surname;
            _salaryInt = salaryInt;
            _superRateInt = superRateInt;
            _startDate = startDate;
            _endDate = endDate;
        }


        public static string capitaliseName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1);
        }


        public static string capitaliseSurname(string surname)
        {
            return surname[0].ToString().ToUpper() + surname.Substring(1, surname.Length - 1);
        }


        public static int setSalary(string salary)
        {
            int salaryInt;

            if (!int.TryParse(salary, out salaryInt))
            {
                Console.WriteLine("The salary tryparse has failed");
            }
            
            Calculations.CalculateIncomeTax(salaryInt);
            return salaryInt;

        }


        public static int setSuper(string super)
        {
            int superRateInt;

            if (!int.TryParse(super, out superRateInt))
            {
                Console.WriteLine("The super tryparse has failed");
            }
            return superRateInt;

            
        }


        public static string setStart(string startDate) //could this be set up as a DateTime field?
        {
            return startDate;
        }

        public static string setEnd(string endDate)
        {
            return endDate;
        }




        public void ReturnPayslip()
        {
            int grossIncome = Calculations.returnGrossIncome(_salaryInt);
            


            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine($"Name: {_name} {_surname}");
            Console.WriteLine($"Pay Period: {_startDate} - {_endDate}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {Calculations.CalculateIncomeTax(_salaryInt)}");
            Console.WriteLine($"Net Income: {Calculations.ReturnNetIncome()}");
            Console.WriteLine($"Super: {Calculations.CalculateSuper(grossIncome, _superRateInt)} \n");
            Console.WriteLine("Thank you for using MYOB!");

        }



    }
}

