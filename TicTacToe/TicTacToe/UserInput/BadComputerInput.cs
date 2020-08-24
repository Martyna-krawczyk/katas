using System;
using System.Net;
using System.Threading;

namespace TicTacToe
{
    public class BadComputerInput : IInput
    {
        public BadComputerInput(IBoard board)
        {
            _board = board;
        }
        
        private readonly IBoard _board;

        public string InputText()
        {
            Thread.Sleep(2000);
            return CoordinateParser.ConvertCoordinateToString(GetAvailableCell(_board));
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