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
            {
                return 0;
            }

            var stringNumbers = RemoveDefaultDelimiters(value);
            _numbers = ConvertToInt(stringNumbers);

            if (ContainNegativeNumbers())
            {
                ThrowException();
            }
            else if (ContainNumbersOverOneThousand())
            {
                ReturnNumbersUnderOneThousand();
            }
            else if (HasCustomDelimiter(value))
            {

                if (value.Contains("["))
                {
                    //access delimiter
                    const int firstIndex = 2;
                    var lastIndex = value.LastIndexOf("]", StringComparison.Ordinal);
                    var delimiterSubstring = value.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
                    var delimiter = delimiterSubstring.Split("][");
                    if (InvalidDelimiter(delimiter))
                    {
                        throw new ArgumentException("Invalid delimiter passed.");
                    }
                    var splitStringNumbers = value.Split("\n");
                    var valuesToSum = splitStringNumbers[1];
                    stringNumbers = valuesToSum.Split(delimiter, StringSplitOptions.None);
                    _numbers = ConvertToInt(stringNumbers);
                }
                else
                {
                    const int firstIndex = 2;
                    var lastIndex = value.LastIndexOf("\n", StringComparison.Ordinal);
                    var delimiter = value.Substring(firstIndex, lastIndex - firstIndex);
                    var splitStringNumbers = value.Split("\n");
                    var valuesToSum = splitStringNumbers[1];
                    stringNumbers = valuesToSum.Split(delimiter);
                    _numbers = ConvertToInt(stringNumbers);
                }
            }

            return SumOfNumbers();
            
        }

        private static bool InvalidDelimiter(string[] delimiter)
        {
            var testResult = true;
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