using System;

namespace TicTacToe
{
    public class ConsoleInput : IInput
    {
        public string InputText()
        {
            return Console.ReadLine().Trim();
        }
    }
}