using System;
using System.Linq;
using System.Text;

namespace FoundationalPayslip
{
    public class OutputFormatter
    {

        public static string FormatName(string nameInput)
        {
            return nameInput[0].ToString().ToUpper() + nameInput.Substring(1, nameInput.Length - 1); //ToTitleCase() - check this out  whitespace??
        }


        public static string FormatSurname(string surnameInput)
        {
            return surnameInput[0].ToString().ToUpper() + surnameInput.Substring(1, surnameInput.Length - 1);
        }


        public static string FormatPayPeriod(Payslip payslip) 
        {
            return Payslip.setStart(payslip.StartDate).ToString("dd MMMM") + " - " + Payslip.setEnd(payslip.EndDate).ToString("dd MMMM");
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
