using System;


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


        //public static double setSalary(string salaryInput)
        //{
        //    double salary;

        //    while (!double.TryParse(salaryInput, out salary)) //tryparse returns a bool
        //    {
        //        Console.WriteLine("The salary tryparse has failed"); 
        //    }
        //    return salary;

        //}


        //This catches the error and sends the user to the end of the program, before it advises that the tryparse has failed
        public static double setSalary(string salaryInput)
        {
            double salary;

            while (true)
            {
                Console.WriteLine("Please enter your annual salary:");
                if (!double.TryParse(Console.ReadLine(), out salary))
                {
                    Console.WriteLine("The salary tryparse has failed");
                }
            return salary;
            }

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

