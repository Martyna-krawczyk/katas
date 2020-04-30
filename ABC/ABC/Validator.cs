using System.Text.RegularExpressions;

namespace ABC
{
    public class Validator
    {
        public static bool ValidWord(string customWord)
        {
            return Regex.IsMatch(customWord, @"^[a-zA-Z]+$");
        }
    }
}