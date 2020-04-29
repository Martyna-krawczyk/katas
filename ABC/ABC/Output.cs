using System;

namespace ABC
{
    public class Output : IOutput
    {
        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }
    }
}