using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AppRunner
    {
        private int Result { get; set; }
        private IEnumerable<int> Numbers { get; set; }
        private string[] DelimiterArray { get; set; }
        
        private readonly char[] _defaultDelimiter = {',', '\n'};
        
        public int Add(string value)
        {
            if (IsEmptyString(value))
                return 0;
            
            ProcessString(value);

            if (ContainNegativeNumbers())
                ThrowNegativeNumberException();
            else if (ContainNumbersOverOneThousand())
                ReturnNumbersUnderOneThousand();
            else if (HasCustomDelimiter(value))
                ProcessStringWithCustomDelimiters(value);
            return SumOfNumbers();
        }

        private void ProcessString(string value)
        {
            var stringNumbers = RemoveDefaultDelimiters(value);
            Numbers = ConvertToInt(stringNumbers);
        }
        
        private void ProcessStringWithCustomDelimiters(string value)
        {
            const int firstIndex = 2;
            if (IsFormattedDelimiter(value))
            {
                ProcessFormattedDelimiter(value, firstIndex);
                SplitValuesToSumOnDelimiter(value, DelimiterArray);
            }
            else
            {
                ProcessUnformattedDelimiter(value, firstIndex);
                SplitValuesToSumOnDelimiter(value, DelimiterArray);
            }
        }
        
        private string[] ProcessUnformattedDelimiter(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("\n", StringComparison.Ordinal);
            var delimiter = value.Substring(firstIndex, lastIndex - firstIndex); 
            DelimiterArray = delimiter.ToCharArray().Select(c => c.ToString()).ToArray();
            return DelimiterArray;
        }
        
        private string[] ProcessFormattedDelimiter(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("]", StringComparison.Ordinal);
            var delimiterSubstring = value.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
            DelimiterArray = delimiterSubstring.Split("][");
            if (InvalidDelimiter(DelimiterArray))
            {
                throw new ArgumentException("Invalid delimiter passed.");
            }
            return DelimiterArray;
        }

        private void SplitValuesToSumOnDelimiter(string value, string[] _delimiterArray)
        {
            var splitStringNumbers = value.Split("\n");
            var valuesToSum = splitStringNumbers[1];
            var stringNumbers = valuesToSum.Split(_delimiterArray, StringSplitOptions.None);
            Numbers = ConvertToInt(stringNumbers);
        }

        private bool IsFormattedDelimiter(string value)
        {
            return value.Contains("[");
        }
        
        private bool InvalidDelimiter(string[] delimiter)
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

        private int SumOfNumbers()
        {
            Result = Numbers.Sum();
            return Result;
        }

        private bool IsEmptyString(string value)
        {
            return value == " ";
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
        
        private bool ContainNegativeNumbers()
        {
            return Numbers.Any(numbers => numbers < 0 );
        }
        
        private void ThrowNegativeNumberException()
        {
            var negativeNumbers = Numbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        
        private bool ContainNumbersOverOneThousand()
        {
            return Numbers.Any(number => number >= 1000);
        }
        
        private IEnumerable<int> ReturnNumbersUnderOneThousand()
        {
            Numbers = Numbers.Where(number => number < 1000);
            return Numbers;
        }
        
        private bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }
    }
}