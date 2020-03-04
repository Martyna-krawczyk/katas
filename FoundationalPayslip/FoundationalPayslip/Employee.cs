using System;


namespace FoundationalPayslip
{
    public class Employee
    {
        private string _name; 
        private string _surname;
        private int _salaryInt;
        private int _superRateInt;
        private string _startDate;
        private string _endDate;


        public Employee(string name, string surname, int salaryInt, int superRateInt, string startDate, string endDate) 
        {
            _name = name; 
            _surname = surname;
            _salaryInt = salaryInt;
            _superRateInt = superRateInt;
            _startDate = startDate;
            _endDate = endDate;
        }


        public string Name 
        {
            get{ return _name;}
            set{ _name = value;}
        }


        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }


        public int SalaryInt
        {
            get { return _salaryInt; }
            set { _salaryInt = value; }
        }


        public int SuperRateInt
        {
            get { return _superRateInt; }
            set { _superRateInt = value; }
        }


        public string startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }


        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }


        public static string capitaliseName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1); //ToTitleCase() - check this out  whitespace??
        }


        public static string capitaliseSurname(string surname)
        {
            return surname[0].ToString().ToUpper() + surname.Substring(1, surname.Length - 1);
        }


        public static int setSalary(string salary)
        {
            int salaryInt;

            while (!int.TryParse(salary, out salaryInt))
            {
                Console.WriteLine("The salary tryparse has failed");
            }
            return salaryInt;

        }


        public static int setSuper(string super)
        {
            int superRateInt;

            while (!int.TryParse(super, out superRateInt))
            {
                Console.WriteLine("The super tryparse has failed");
            } 
            return superRateInt;
        }


        public static DateTime setStart(string startDate)
        {
            DateTime payMonthStart;
            while (!DateTime.TryParse(startDate, out payMonthStart))
            {
                Console.WriteLine("You must enter a valid date");

            }
            return payMonthStart.Date;
         

        }


        public static DateTime setEnd(string endDate)
        {
            DateTime payMonthEnd;
            while (!DateTime.TryParse(endDate, out payMonthEnd))
            {
                Console.WriteLine("You must enter a valid date");
            }
            return payMonthEnd.Date;
        }

        
    }
}

