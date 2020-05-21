using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class AppRunner
    {
        
        private int _result { get; set; }
        
        readonly char[] delimiter = {',', '\n', '/', ';', 'n'};

        public string InputString()
        {
            var value = Console.ReadLine();
            return value;
        }
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
            
            var negativeNumbers = intNumbers.Where(numbers => numbers < 0);

            if (ContainNegativeNumbers(intNumbers))
                
                ThrowException(intNumbers);
            
            else
                _result = intNumbers.Sum();
            return _result;
        }
        private static void ThrowException(IEnumerable<int> intNumbers)
        {
            var negativeNumbers = intNumbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        private static bool ContainNegativeNumbers(IEnumerable<int> intNumbers)
        {
            return intNumbers.Any(numbers => numbers < 0 );
        }

        private static bool IsEmptyString(string _value)
        {
            return _value == " ";
        }
    }
    
}