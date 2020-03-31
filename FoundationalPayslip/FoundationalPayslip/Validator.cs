using System;
using System.Globalization;

namespace FoundationalPayslip
{
    public class Validator : IValidator
    {
        public static bool IsValidName(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public static bool CanDateBeParsed(string date, string format)  
        {
            string[] dateFormat = { format };
            return DateTime.TryParseExact(date, dateFormat, new CultureInfo("en-US"),
                DateTimeStyles.None, out _);
        }

        public static bool CanSalaryBeParsed(string salary)  
        {
            return double.TryParse(salary, out double _);
        }

        public static bool CanSuperBeParsed(string super)  
        {
            return double.TryParse(super, out double _);
        }
    }
}