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
            string salary = Console.ReadLine();

            Console.WriteLine("Please enter your super rate:");
            string super = Console.ReadLine();

            Console.WriteLine("Please enter your payment start date:");
            string startDate = Console.ReadLine();

            Console.WriteLine("Please enter your payment end date:");
            string endDate = Console.ReadLine();

            Employee emp1 = new Employee
                (

                Employee.capitaliseName(name),

                Employee.capitaliseSurname(surname),

                Employee.setSalary(salary),

                Employee.setSuper(super),

                Employee.setStart(startDate).ToString(),

                Employee.setEnd(endDate).ToString()

                );

            

            Payslip.ReturnPayslip(emp1);

            
        }
    }
}
