using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AppRunner
    {
        private static int _result { get; set; }
        private static IEnumerable<int> _numbers { get; set; }
        private readonly char[] _defaultDelimiter = {',', '\n'};
        public int Add(string value)
        {
            if (IsEmptyString(value))
                return 0;
            
            ProcessString(value);

            if (ContainNegativeNumbers())
                ThrowException();
            else if (ContainNumbersOverOneThousand())
                ReturnNumbersUnderOneThousand();
            else if (HasCustomDelimiter(value))
                ProcessStringWithCustomDelimiters(value);
            return SumOfNumbers();
        }

        private void ProcessString(string value)
        {
            var stringNumbers = RemoveDefaultDelimiters(value);
            _numbers = ConvertToInt(stringNumbers);
        }
        
        private static void ProcessStringWithCustomDelimiters(string value)
        {
            const int firstIndex = 2;
            string[] delimiterArray; 
            if (IsFormattedDelimiter(value))
            {
                var lastIndex = value.LastIndexOf("]", StringComparison.Ordinal);
                var delimiterSubstring = value.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
                delimiterArray = delimiterSubstring.Split("][");
                if (InvalidDelimiter(delimiterArray))
                {
                    throw new ArgumentException("Invalid delimiter passed.");
                }
                SplitValuesToSumOnDelimiter(value, delimiterArray);
            }
            else
            {
                var lastIndex = value.LastIndexOf("\n", StringComparison.Ordinal);
                var delimiter = value.Substring(firstIndex, lastIndex - firstIndex); //to array??
                delimiterArray = delimiter.ToCharArray().Select( c => c.ToString()).ToArray();
                SplitValuesToSumOnDelimiter(value, delimiterArray);
            }
        }

        private static void SplitValuesToSumOnDelimiter(string value, string[] delimiterArray)
        {
            var splitStringNumbers = value.Split("\n");
            var valuesToSum = splitStringNumbers[1];
            var stringNumbers = valuesToSum.Split(delimiterArray, StringSplitOptions.None);
            _numbers = ConvertToInt(stringNumbers);
        }

        private static bool IsFormattedDelimiter(string value)
        {
            return value.Contains("[");
        }
        
        private static bool InvalidDelimiter(string[] delimiter)
        {
            var testResult = false;
            foreach (var d in delimiter)
            {
                var rx = new Regex(@"(^\d)|(\d$)");
                testResult = rx.IsMatch(d);
                if (testResult)
                {
                    break;
                }
            }
            return testResult;
        }

        private static int SumOfNumbers()
        {
            _result = _numbers.Sum();
            return _result;
        }

        private static bool IsEmptyString(string value)
        {
            return value == " ";
        }
        
        private string[] RemoveDefaultDelimiters(string value)
        {
            var stringNumbers = value.Split(_defaultDelimiter);
            return stringNumbers;
        }
        
        private static IEnumerable<int> ConvertToInt(IEnumerable<string> stringNumbers)
        {
            var intNumbers = stringNumbers.Select(s => new {Success = int.TryParse(s, out var value), value})
                .Where(pair => pair.Success)
                .Select(pair => pair.value);
            return intNumbers;
        }
        
        private static bool ContainNegativeNumbers()
        {
            return _numbers.Any(numbers => numbers < 0 );
        }
        
        private static void ThrowException()
        {
            var negativeNumbers = _numbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        
        private static bool ContainNumbersOverOneThousand()
        {
            return _numbers.Any(number => number >= 1000);
        }
        
        private static IEnumerable<int> ReturnNumbersUnderOneThousand()
        {
            _numbers = _numbers.Where(number => number < 1000);
            return _numbers;
        }
        
        private static bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }
    }
}