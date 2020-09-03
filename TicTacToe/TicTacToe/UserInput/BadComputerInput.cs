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
            return GetAvailableCell(_board).ToString();
        }
        
        public Coordinate GetAvailableCell(IBoard board)
        {
            while (true)
            { 
                var coordinate = SetCoordinate();

                if (board.CellIsAvailable(coordinate))
                {
                    return coordinate;
                }
            }
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