using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AppRunner
    {
        private int _result { get; set; }

        private readonly char[] defaultDelimiter = {',', '\n'};

        private int intValueToSubtract;
        
        public int Add(string value)
        {
            if (IsEmptyString(value))
            {
                return 0;
            }
            
            string[] _stringNumbers = RemoveDefaultDelimiters(value);
            IEnumerable<int> _intNumbers = ConvertToInt(_stringNumbers);

            if (ContainNegativeNumbers(_intNumbers))
            {
                ThrowException(_intNumbers);
            }
            else if (ContainNumbersOverOneThousand(_intNumbers))
            {
                ReturnNumbersUnderOneThousand(_intNumbers);
            }
            else if (HasCustomDelimiter(value))
            {
                var rx = new Regex(@"(\[.[0-9].])");
                var splitStringNumbers = value.Split("\n");
                var innerList = splitStringNumbers[0];
                var outerList = splitStringNumbers[1];
                if (rx.IsMatch(value))
                {
                    var testValue = rx.Match(value).Groups[1].Value;
    
                    if (innerList.Contains(testValue))
                    {
                        var matchedValue = testValue.Substring(1, testValue.Length - 2);
                        if (outerList.Contains(matchedValue))
                        {
                            var valueToSubtract = matchedValue.Substring(1, 1);
                            intValueToSubtract = int.Parse(valueToSubtract);
                        }
                    }

                    var numbersWithoutCustomDelimiters = Regex.Split(outerList, @"\D");
                       _intNumbers = ConvertToInt(numbersWithoutCustomDelimiters);
                       var sum = _intNumbers.Sum();
                       _result = sum - intValueToSubtract;
                }
                else
                {
                    var numbersWithoutCustomDelimiters = Regex.Split(outerList, @"\D");
                    _intNumbers = ConvertToInt(numbersWithoutCustomDelimiters);
                    _result = _intNumbers.Sum();
                }
                
            }
            else
                _result = _intNumbers.Sum();
            return _result;
        }

        private static bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }

        private static IEnumerable<int> ConvertToInt(string[] _stringNumbers)
        {
            var intNumbers = _stringNumbers.Select(s => new {Success = int.TryParse(s, out var value), value})
                .Where(pair => pair.Success)
                .Select(pair => pair.value);
            return intNumbers;
        }

        private static bool IsEmptyString(string value)
        {
            return value == " ";
        }
       
        private string[] RemoveDefaultDelimiters(string value)
        {
            var _stringNumbers = value.Split(defaultDelimiter);
            //var _stringNumbers = Regex.Split(value, @"\D+"); 
            return _stringNumbers;
        }

        // private bool ContainNumbersOnDelimiterBoundary(string value)
        // {
        //     string startPattern = "//[";
        //     var endPattern = '\n';
        //     value.StartsWith(startPattern) && value.EndsWith(endPattern);
        //         return true;
        // }
        // private string[] RemoveDelimitersAndNumbersOnBoundary(string value)
        // {
        //     //var stringNumbers = value.Split(delimiter);
        //     var _stringNumbers = Regex.Split(value, @"(^\/\/\[.+(?<=\\n))"); 
        //     return _stringNumbers;
        // }
        //
        
        
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