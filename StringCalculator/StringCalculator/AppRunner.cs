using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AppRunner
    {
        private readonly char[] _defaultDelimiter = {',', '\n'};
        
        public int Add(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? 0 : CalculateString(value);
        }

        private int CalculateString(string value)
        {
            var numbers = HasCustomDelimiter(value)
                ? ExtractNumbersWhereCustomDelimitersPresent(value)
                : ExtractNumbersToAddAsIntegers(value);
            
            if (ContainNegativeNumbers(numbers))
                ThrowNegativeNumberException(numbers);
            if (ContainNumbersOverOneThousand(numbers))
                numbers = ReturnNumbersUnderOneThousand(numbers);
            
            return SumOfNumbers(numbers);
        }

        private bool ContainNegativeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number < 0 );
        }
        
        private void ThrowNegativeNumberException(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        
        private bool ContainNumbersOverOneThousand(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number >= 1000);
        }
        
        private IEnumerable<int> ReturnNumbersUnderOneThousand(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < 1000);
        }
        
        private bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }
        
        private IEnumerable<int> ExtractNumbersWhereCustomDelimitersPresent(string value)
        {
            const int firstIndex = 2;
            return IsFormattedDelimiter(value)
                ? AccessDelimiterWhereCustomDelimiterIsFormatted(value, firstIndex)
                : AccessDelimiterWhereCustomDelimiterIsUnformatted(value, firstIndex);
        }
        
        private bool IsFormattedDelimiter(string value)
        {
            return value.Contains("[");
        }
        
        private IEnumerable<int> AccessDelimiterWhereCustomDelimiterIsFormatted(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("]", StringComparison.Ordinal);
            var delimiterSubstring = value.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
            var customDelimiter = delimiterSubstring.Split("][");
            ThrowInvalidDelimiterException(customDelimiter);
            return SplitValuesToSumOnDelimiter(value, customDelimiter);
        }
        
        private IEnumerable<int> AccessDelimiterWhereCustomDelimiterIsUnformatted(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("\n", StringComparison.Ordinal);
            var delimiter = value.Substring(firstIndex, lastIndex - firstIndex); 
            var customDelimiter = delimiter.ToCharArray().Select(c => c.ToString()).ToArray();
            return SplitValuesToSumOnDelimiter(value, customDelimiter);
        }
        
        private void ThrowInvalidDelimiterException(string[] customDelimiter)
        {
            if (InvalidDelimiter(customDelimiter))
            {
                throw new ArgumentException("Invalid delimiter passed.");
            }
        }
        
        private bool InvalidDelimiter(string[] delimiter)
        {
            var numberFoundOnEdge = false;
            var rx = new Regex(@"(^\d)|(\d$)");
            foreach (var d in delimiter)
            {
                numberFoundOnEdge = rx.IsMatch(d);
                if (numberFoundOnEdge)
                {
                    break;
                }
            }
            return numberFoundOnEdge;
        }
        
        private IEnumerable<int> SplitValuesToSumOnDelimiter(string value, string[] delimiter)
        {
            var splitStringNumbers = value.Split("\n");
            var valuesToSum = splitStringNumbers[1];
            var stringNumbers = valuesToSum.Split(delimiter, StringSplitOptions.None);
            return ConvertToInt(stringNumbers);
        }
        
        private IEnumerable<int> ExtractNumbersToAddAsIntegers(string value)
        {
            var stringNumbers = RemoveDefaultDelimiters(value);
            return ConvertToInt(stringNumbers);
        }
        
        private string[] RemoveDefaultDelimiters(string value)
        {
            var stringNumbers = value.Split(_defaultDelimiter);
            return stringNumbers;
        }
        
        private IEnumerable<int> ConvertToInt(IEnumerable<string> stringNumbers)
        {
            var intNumbers = stringNumbers.Select(s => new {Success = int.TryParse(s, out var value), value})
                .Where(pair => pair.Success)
                .Select(pair => pair.value);
            return intNumbers;
        }

        private int SumOfNumbers(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }
    }
}