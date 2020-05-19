using System;
using System.Linq;

namespace StringCalculator
{
    public class AppRunner
    {
        private int _result;
        readonly char delimiter = ',';
        
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
            
            if (CommaSeparatedMultipleInput(value))
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

        private int RemoveSeparator(string value)
        {
            var stringArray = value.Split(delimiter);
            foreach (var s in stringArray)
            {
                var number = ParseStringToNumber(s);
                _result += number;
            }
            return _result;
        }

        private static int ParseStringToNumber(string s)
        {
            Int32.TryParse(s, out var number);
            return number;
        }

        private bool CommaSeparatedMultipleInput(string value)
        {
            return value.Contains(delimiter);
        }
    }
    
}