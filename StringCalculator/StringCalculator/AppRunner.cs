using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class AppRunner
    {
        public string value;
        private int _result { get; set; }
        
        readonly char[] delimiter = {',', '\n', '/', ';', 'n', '*', '[', ']', '%', '#'};
        
        public int Add(string value)
        {
            if (IsEmptyString(value))
            {
                return 0;
            }
            
            var stringNumbers = value.Split(delimiter);
            
            var intNumbers = stringNumbers.Select(s => new { Success = int.TryParse(s, out var value), value })
                .Where(pair => pair.Success)
                .Select(pair => pair.value);


            if (ContainNegativeNumbers(intNumbers))
            {
                ThrowException(intNumbers);
            }
            else if (ContainNumbersOverOneThousand(intNumbers))
            {
                ReturnNumbersUnderOneThousand(intNumbers);
            }
            else
                _result = intNumbers.Sum();
            return _result;
        }

       

        private static bool IsEmptyString(string value)
        {
            return value == " ";
        }
        
        private static bool ContainNegativeNumbers(IEnumerable<int> intNumbers)
        {
            return intNumbers.Any(numbers => numbers < 0 );
        }
        
        private static void ThrowException(IEnumerable<int> intNumbers)
        {
            var negativeNumbers = intNumbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        
        private static bool ContainNumbersOverOneThousand(IEnumerable<int> intNumbers)
        {
            return intNumbers.Any(number => number >= 1000);
        }
        
        private void ReturnNumbersUnderOneThousand(IEnumerable<int> intNumbers)
        {
            var smallNumbers = intNumbers.Where(number => number < 1000);
            _result = smallNumbers.Sum();
        }
    }
    
}