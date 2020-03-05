using System;

namespace FoundationalPayslip
{
    public class OutputFormatter
    {

        public static string FormatName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1); //ToTitleCase() - check this out  whitespace??
        }


        public static string FormatSurname(string surname)
        {
            return surname[0].ToString().ToUpper() + surname.Substring(1, surname.Length - 1);
        }


        public static string FormatPayPeriod(Employee employee) //can I create a variable to hold the object so that I don't have to repeat this?
        {
            return Employee.setStart(employee.StartDate).ToString("dd MMMM") + " - " + Employee.setEnd(employee.EndDate).ToString("dd MMMM");
        }


        public static double FormatGrossIncome(Employee employee)
        {
            return Math.Round(Calculations.ReturnGrossIncome(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }


        public static double FormatIncomeTax(Employee employee)
        {
            return Math.Round(Calculations.CalculateIncomeTax(employee.Salary), 0, MidpointRounding.AwayFromZero);
        }


        public static double FormatNetIncome()
        {
            return Math.Round(Calculations.ReturnNetIncome(), 0, MidpointRounding.AwayFromZero);
        }

        public static double FormatSuperValue(Employee employee)
        {
            return Math.Round(Calculations.CalculateSuper(Calculations.ReturnGrossIncome(employee.Salary), employee.SuperRate), 0, MidpointRounding.AwayFromZero);
        }
    }
}
