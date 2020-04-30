using System;

namespace ABC
{
    public class Input : IInput
    {
        public string InputText()
        {
            return Console.ReadLine();
        }
    }
}