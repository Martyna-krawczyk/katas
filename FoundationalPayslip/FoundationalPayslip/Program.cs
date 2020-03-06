using System;
using System.Linq;
using System.Text;

//I would like to catch the errors without them running recursively - how can I structure the code to bring the user back to their input prompt?

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input your name:");
            string nameInput = Console.ReadLine();

            Console.WriteLine("Please input your surname:");
            string surnameInput = Console.ReadLine();

            Console.WriteLine("Please enter your annual salary:");
            string salaryInput = Console.ReadLine();

            Console.WriteLine("Please enter your super rate:");
            string superInput = Console.ReadLine();

            Console.WriteLine("Please enter your payment start date (DD/MM/YYYY):");
            string startDateInput = Console.ReadLine();

            Console.WriteLine("Please enter your payment end date (DD/MM/YYYY):");
            string endDateInput = Console.ReadLine();

            Employee emp1 = new Employee
                (

                OutputFormatter.FormatName(nameInput),

                OutputFormatter.FormatSurname(surnameInput),

                Employee.setSalary(salaryInput),

                Employee.SetSuper(superInput)

                );

            Payslip pay1 = new Payslip
                (
                Payslip.setStart(startDateInput).ToString(),

                Payslip.setEnd(endDateInput).ToString()
                );


            Payslip.ReturnPayslip(emp1, pay1);
        }
    }
}
