using System;


//Is this the cleaner way to write this code?
//public Employee(string firstName, string lastName, double salary, double superRate)
//{
//    FirstName = firstName;
//    LastName = lastName;
//    Salary = salary;
//    SuperRate = superRate;
//}
//public string FirstName { get; private set; }
//public string LastName { get; private set; }
//public double Salary { get; private set; }
//public double SuperRate { get; private set; }

namespace FoundationalPayslip
{
    public class Employee
    {
        private string _name; 
        private string _surname;
        private double _salary;
        private double _superRate;

        public Employee(string name, string surname, double salary, double superRate) 
        {
            _name = name; 
            _surname = surname;
            _salary = salary;
            _superRate = superRate;
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


        public static double setSalary(string salaryInput)
        {
            double salary;

            while (!double.TryParse(salaryInput, out salary))
            {
                Console.WriteLine("The salary tryparse has failed");
            }
            return salary;

        }


        public static double SetSuper(string superInput)
        {
            double superRate;

            while (!double.TryParse(superInput, out superRate))
            {
                Console.WriteLine("The super tryparse has failed");
            } 
            return superRate;
        }
        
    }
}

