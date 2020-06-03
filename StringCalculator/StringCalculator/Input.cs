using System;

namespace StringCalculator
{
    public class Input : IInput
    {
        public string InputText()
        {
            return Console.ReadLine();
        }
    }
}
