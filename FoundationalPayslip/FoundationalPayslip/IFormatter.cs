using System;
using System.Globalization;

namespace FoundationalPayslip
{
    public interface IFormatter
    {
        string FormatName(string name);
        
        string FormatSurname(string surname);
        
        double FormatGrossIncome(Employee employee);
        
        double FormatIncomeTax(Employee employee);
        
        double FormatNetIncome();
        
        double FormatSuperValue(Employee employee);

        void PrintPayslip(Employee employee, Payslip payslip);

    }
}