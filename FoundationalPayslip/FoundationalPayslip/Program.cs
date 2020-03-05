using System;


namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please input your surname:");
            string surname = Console.ReadLine();

            Console.WriteLine("Please enter your annual salary:");
            string salaryString = Console.ReadLine();

            Console.WriteLine("Please enter your super rate:");
            string superString = Console.ReadLine();

            Console.WriteLine("Please enter your payment start date (DD/MM/YYYY):");
            string startDate = Console.ReadLine();

            Console.WriteLine("Please enter your payment end date (DD/MM/YYYY):");
            string endDate = Console.ReadLine();

            Employee emp1 = new Employee
                (

                OutputFormatter.FormatName(name),

                OutputFormatter.FormatSurname(surname),

                Employee.setSalary(salaryString),

                Employee.SetSuper(superString),

                Employee.setStart(startDate).ToString(),

                Employee.setEnd(endDate).ToString()

                );

            Payslip.ReturnPayslip(emp1);
        }
    }
}
