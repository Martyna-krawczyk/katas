using System.Threading;

namespace TicTacToe
{
    public class BadComputerPlay : IMove
    {
        private readonly IOutput _output;
        private readonly IBoard _board;

        public BadComputerPlay(IOutput output, IBoard board)
        {
            _output = output;
            _board = board;
        }
        public void Move(Player player)
        {
            while (true)
            {
                _output.OutputText(string.Format(Resources.ComputerTakeTurn, player.Name));
                Thread.Sleep(2000);
                var coordinate = SetCoordinate();
                if ( _board.CellIsAvailable(coordinate))
                {
                    PlayMove(player, coordinate);
                }
                else
                {
                    continue;
                }
                break;
            }
        }

        private Coordinate SetCoordinate()
        {
            return CoordinateParser.GetCoordinates(SelectCoordinates(), SelectCoordinates());
        }

        private int SelectCoordinates()
        {
            return TurnSelector.ChooseIntegerForCoordinate(0, _board.Size);
        }

        public void PlayMove(Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.ClearConsole();
            _output.OutputText(Resources.MoveAccepted);
            _board.PrintBoard();
        }
    }
}