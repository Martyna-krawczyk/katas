using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FoundationalPayslip
{
    public class OutputFormatter : IFormatter
    {
        private readonly TextInfo _textFormatter = new CultureInfo("en-US", false).TextInfo;
        
        //private readonly CultureInfo _dateFormatter = new CultureInfo("en-GB");
       
        //CultureInfo uk = new CultureInfo("en-GB");
        //private string shortUKDateFormatString = uk.DateTimeFormat.ShortDatePattern;
        //public DateTime FormatDate(DateTime startDate)
        //{
            //return _dateFormatter.Calendar.GetMonth(); //
        //}

        public string FormatName(string name)
        {
            return _textFormatter.ToTitleCase(name);
        }
        
        public string FormatSurname(string surname)
        {
            return _textFormatter.ToTitleCase(surname);
        }
        
    
        public double FormatGrossIncome(Employee employee)
        {
            return Math.Round(Calculator.ReturnGrossIncome(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }
        
        public double FormatIncomeTax(Employee employee)
        {
            return Math.Round(Calculator.CalculateIncomeTax(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }

        public double FormatNetIncome()
        {
            return Math.Round(Calculator.ReturnNetIncome(), 0, MidpointRounding.AwayFromZero);
        }

        public double FormatSuperValue(Employee employee)
        {
            return Math.Round(Calculator.CalculateSuper(Calculator.ReturnGrossIncome(employee.Salary), employee.SuperRate), 0, MidpointRounding.AwayFromZero);
        }
        
        public void PrintPayslip(Employee employee, Payslip payslip)
        {
            double grossIncome = FormatGrossIncome(employee);
            double incomeTax = FormatIncomeTax(employee);
            double netIncome = FormatNetIncome();
            double super = FormatSuperValue(employee);
            
            Console.WriteLine(
                "\nYour payslip has been generated:\n\n" +
                $"Name: {employee.Name} {employee.Surname}\n" +
                $"Pay Period: {payslip.StartDate.ToString("dd MMM")} - {payslip.EndDate.ToString("dd MMM")}\n" +
                $"Gross Income: {grossIncome}\n" +
                $"Income Tax: {incomeTax}\n" +
                $"Net Income: {netIncome}\n" +
                $"Super: {super}\n\n" +
                "Thank you for using MYOB!"
                );
        }
    }
}
