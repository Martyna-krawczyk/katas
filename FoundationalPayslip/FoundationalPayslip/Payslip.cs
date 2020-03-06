using System;
using System.Linq;
using System.Text;
namespace FoundationalPayslip
{
    public class Payslip
    {
        //private string _startDate;
        private string _endDate;

        public Payslip(string startDate, string endDate)
        {
            StartDate = startDate;
            _endDate = endDate;
        }

        //public string StartDate
        //{
        //    get { return _startDate; }
        //    set { _startDate = value; }
        //}


        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public string StartDate { get; private set; }

        public static DateTime setStart(string startDateInput)
        {
            DateTime payMonthStart;
            while (!DateTime.TryParse(startDateInput, out payMonthStart))
            {
                Console.WriteLine("You must enter a valid date");

            }
            return payMonthStart;
        }


        public static DateTime setEnd(string endDateInput)
        {
            DateTime payMonthEnd;
            while (!DateTime.TryParse(endDateInput, out payMonthEnd))
            {
                Console.WriteLine("You must enter a valid date");
            }
            return payMonthEnd;
        }

        public static void ReturnPayslip(Employee employee, Payslip payslip)
        {
            //double grossIncome = Calculations.ReturnGrossIncome(employee.Salary);  //Is this the better convention instead of putting the methods directly into the Console.Writeline?

            Console.WriteLine(
                "\nYour payslip has been generated:\n\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {OutputFormatter.FormatPayPeriod(payslip)}\n" +
                $"Gross Income: {OutputFormatter.FormatGrossIncome(employee)}\n" +
                $"Income Tax: {OutputFormatter.FormatIncomeTax(employee)}\n" +
                $"Net Income: {OutputFormatter.FormatNetIncome()}\n" +
                $"Super: {OutputFormatter.FormatSuperValue(employee)}\n\n" +
                "Thank you for using MYOB!"
                );
        }
    } 
}



