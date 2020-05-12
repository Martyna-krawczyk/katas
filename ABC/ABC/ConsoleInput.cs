using System;

namespace ABC
{
    public class ConsoleInput : IInput
    {
        public string InputText()
        {
            return Console.ReadLine();
        }
    }
}