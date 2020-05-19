using System;
using System.Linq;

namespace StringCalculator
{
    public class AppRunner
    {
        private int _result;
        readonly char[] delimiter = new char[] {',', '\n', '/', ';', 'n'};
        
        public int Add(string value)
        {
            if (IsEmptyString(value))
            {
                return 0;
            }

            if (SingleInput(value, out _result))
            {
                return _result;
            }
            
            if (MultipleDelimitersMultipleInput(value))
            {
                RemoveSeparator(value);
            }
            return _result;
        }
        
        private static bool IsEmptyString(string value)
        {
            return value == " ";
        }
        
        private static bool SingleInput(string value, out int result)
        {
            return int.TryParse(value, out result);
        }
        
        private bool MultipleDelimitersMultipleInput(string value)
        {
            return delimiter.Any(value.Contains);
        }
        
        private int RemoveSeparator(string value)
        {
            var stringArray = value.Split(delimiter);
            foreach (var stringNumber in stringArray)
            {
                var intNumber = ParseStringToNumber(stringNumber);
                _result += intNumber;
            }
            return _result;
        }

        private static int ParseStringToNumber(string stringNumber)
        {
            Int32.TryParse(stringNumber, out var intNumber);
            return intNumber;
        }

       
    }
    
}