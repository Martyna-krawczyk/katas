using System;

namespace ABC
{
    public class ConsoleInput : IConsoleInput
    {
        public string InputText()
        {
            return Console.ReadLine();
        }
    }
}