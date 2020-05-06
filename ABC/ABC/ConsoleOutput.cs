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
        
        public void OutputText(string text1, string text2 ,string text3, string text4 )
        {
            Console.WriteLine(text1, text2, text3, text4);
        }
    }
}