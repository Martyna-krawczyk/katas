using System;


namespace FoundationalPayslip
{
    public class Employee
    {
        private string _name; 
        private string _surname;
        private double _salary;
        private double _superRate;
        private string _startDate;
        private string _endDate;
        //private double _grossIncome;


        public Employee(string name, string surname, double salary, double superRate, string startDate, string endDate) 
        {
            _name = name; 
            _surname = surname;
            _salary = salary;
            _superRate = superRate;
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


        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }


        public double SuperRate
        {
            get { return _superRate; }
            set { _superRate = value; }
        }


        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }


        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        //public double GrossIncome
        //{
        //    get { return _grossIncome; }
        //    set { _grossIncome = value; }
        //}


        public static double setSalary(string salaryString)
        {
            double salary;

            while (!double.TryParse(salaryString, out salary))
            {
                Console.WriteLine("The salary tryparse has failed");
            }
            return salary;

        }


        public static double SetSuper(string superString)
        {
            double superRate;

            while (!double.TryParse(superString, out superRate))
            {
                Console.WriteLine("The super tryparse has failed");
            } 
            return superRate;
        }


        public static DateTime setStart(string startDate)
        {
            DateTime payMonthStart;
            while (!DateTime.TryParse(startDate, out payMonthStart))
            {
                Console.WriteLine("You must enter a valid date");

            }
            return payMonthStart;
         

        }


        public static DateTime setEnd(string endDate)
        {
            DateTime payMonthEnd;
            while (!DateTime.TryParse(endDate, out payMonthEnd))
            {
                Console.WriteLine("You must enter a valid date");
            }
            return payMonthEnd;
        }

        
    }
}

