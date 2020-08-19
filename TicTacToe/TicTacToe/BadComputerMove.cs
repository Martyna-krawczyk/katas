using System;
using System.Threading;

namespace TicTacToe
{
    public class BadComputerMove : IInput
    {
        public BadComputerMove(IInput input)
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
    }
}