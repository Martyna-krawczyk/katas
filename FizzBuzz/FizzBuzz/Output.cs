using System;

namespace FizzBuzz
{
    public class Output : IOutput
    {
        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }
    }
}