using System;

namespace TicTacToe
{
    public class ConsoleInput : IInput
    {
        public string InputText()
        {
            return Console.ReadLine()?.Trim();
        }
        
        public string PlayMove()
        {
            return GetPlayerMove(InputText());
        }

        public string GetPlayerMove(string input)
        {
            return input;
        }
    }
}