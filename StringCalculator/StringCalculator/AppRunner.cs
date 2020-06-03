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
        private string[] CustomDelimiter { get; set; }
        
        private readonly char[] _defaultDelimiter = {',', '\n'};
        
        private readonly IInput _input;
        public AppRunner(IInput input)
        {
            _input = input;
        }
        
        public int Add(string _input)
        {
            return IsEmptyString(_input) ? 0 : CalculateString(_input);
        }
        
        private bool IsEmptyString(string value)
        {
            return value == " ";
        }
        
        private int CalculateString(string value)
        {
            ExtractNumbersToAddAsIntegers(value);

            if (ContainNegativeNumbers())
                ThrowNegativeNumberException();
            else if (ContainNumbersOverOneThousand())
                ReturnNumbersUnderOneThousand();
            else if (HasCustomDelimiter(value))
                ExtractNumbersWhereCustomDelimitersPresent(value);
            return SumOfNumbers();
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
        
        private void ReturnNumbersUnderOneThousand()
        {
            Numbers = Numbers.Where(number => number < 1000);
        }
        
        private bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }
        
        private void ExtractNumbersWhereCustomDelimitersPresent(string value)
        {
            const int firstIndex = 2;
            if (IsFormattedDelimiter(value))
                AccessDelimiterWhereCustomDelimiterIsFormatted(value, firstIndex);
            else
                AccessDelimiterWhereCustomDelimiterIsUnformatted(value, firstIndex);
        }
        
        private bool IsFormattedDelimiter(string value)
        {
            return value.Contains("[");
        }
        
        private void AccessDelimiterWhereCustomDelimiterIsFormatted(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("]", StringComparison.Ordinal);
            var delimiterSubstring = value.Substring(firstIndex + 1, lastIndex - firstIndex - 1);
            CustomDelimiter = delimiterSubstring.Split("][");
            ThrowInvalidDelimiterException();
            SplitValuesToSumOnDelimiter(value, CustomDelimiter);
        }
        
        private void AccessDelimiterWhereCustomDelimiterIsUnformatted(string value, int firstIndex)
        {
            var lastIndex = value.LastIndexOf("\n", StringComparison.Ordinal);
            var delimiter = value.Substring(firstIndex, lastIndex - firstIndex); 
            CustomDelimiter = delimiter.ToCharArray().Select(c => c.ToString()).ToArray();
            SplitValuesToSumOnDelimiter(value, CustomDelimiter);
        }
        
        private void ThrowInvalidDelimiterException()
        {
            if (InvalidDelimiter(CustomDelimiter))
            {
                throw new ArgumentException("Invalid delimiter passed.");
            }
        }
        
        private bool InvalidDelimiter(string[] delimiter)
        {
            var numberFoundOnEdge = false;
            for (var index = 0; index < delimiter.Length; index++)
            {
                var d = delimiter[index];
                var rx = new Regex(@"(^\d)|(\d$)");
                numberFoundOnEdge = rx.IsMatch(d);
                if (numberFoundOnEdge)
                {
                    break;
                }
            }
            return numberFoundOnEdge;
        }
        
        private void SplitValuesToSumOnDelimiter(string value, string[] _delimiterArray)
        {
            var splitStringNumbers = value.Split("\n");
            var valuesToSum = splitStringNumbers[1];
            var stringNumbers = valuesToSum.Split(_delimiterArray, StringSplitOptions.None);
            Numbers = ConvertToInt(stringNumbers);
        }
        
        private void ExtractNumbersToAddAsIntegers(string value)
        {
            var stringNumbers = RemoveDefaultDelimiters(value);
            Numbers = ConvertToInt(stringNumbers);
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

        private int SumOfNumbers()
        {
            Result = Numbers.Sum();
            return Result;
        }
    }
}