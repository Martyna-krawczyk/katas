using System;
using System.Collections.Generic;

namespace ABC
{
    public class ConsoleOutput : IOutput
    {
        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }
        
    }
}