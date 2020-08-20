using System;
using System.Net;
using System.Threading;

namespace TicTacToe
{
    public class BadComputerInput : IInput
    {
        public BadComputerInput(IInput input, IBoard board)
        {
            _input = input;
            _board = board;
        }
        
        private readonly IInput _input;
        private readonly IBoard _board;

        public string GetPlayerMove(string input)
        {
            return input;
        }
        
        public string InputText()
        {
            Thread.Sleep(2000);
            return CoordinateParser.ConvertCoordinateToString(GetAvailableCell(_board));
        }

        public string PlayMove()
        {
            return GetPlayerMove(_input.InputText());
        }
        
        public Coordinate GetAvailableCell(IBoard board)
        {
            var coordinate = SetCoordinate();
            if (!board.CellIsAvailable(coordinate))
            {
                GetAvailableCell(board);
            }
            return coordinate;
        }

        private Coordinate SetCoordinate()
        {
            return CoordinateParser.GetCoordinates(ChooseIntegerForCoordinate(), ChooseIntegerForCoordinate());
        }
        
        public int ChooseIntegerForCoordinate()
        {
            var random = new Random();
            return random.Next(0, _board.Size);
        }
    }
}