using System;
using System.Threading;

namespace TicTacToe
{
    public class BadComputerMove : IInput
    {
        public BadComputerMove(IInput input, int boardSize)
        {
            _input = input;
            _boardSize = boardSize;
        }
        
        private readonly IInput _input;
        private int _boardSize;

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
            return random.Next(0, _boardSize);
        }
        
        private Coordinate SetCoordinate(int boardSize)
        {
            return CoordinateParser.GetCoordinates(ChooseIntegerForCoordinate(0, _boardSize), ChooseIntegerForCoordinate(0, _boardSize));
        }
    }
}