using System;
using System.Threading;

namespace TicTacToe
{
    public class BadComputerMove : IInput
    {
        public BadComputerMove(IInput input, int boardSize)
        {
            _input = input;
        }
        
        private readonly IInput _input;
        
        public string GetPlayerMove(string input)
        {
            return input;
        }

        public string PlayMove()
        {
            return GetPlayerMove(_input.InputText());
        }
        
        public string InputText()
        {
            return "2,1";
        }

        public int ChooseIntegerForCoordinate(int i, in int boardSize)
        {
            var random = new Random();
            return random.Next(0, boardSize);
        }
    }
}