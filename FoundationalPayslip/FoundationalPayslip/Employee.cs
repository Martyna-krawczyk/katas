using System;


namespace FoundationalPayslip
{
    public class Employee
    {
        public Employee(string name, string surname, double salary, double superRate) 
        {
            Name = name; 
            Surname = surname;
            Salary = salary;
            SuperRate = superRate;
        }


        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Salary { get; private set; }
        public double SuperRate { get; private set; }
        
    }
}

