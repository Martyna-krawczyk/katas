namespace TicTacToe
{
    public class HumanPlay : IMove
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;

        public HumanPlay(IInput input, IOutput output, IBoard board, ICoordinateParser coordinateParser)
        {
            _input = input;
            _output = output;
            _board = board;
            _coordinateParser = coordinateParser;
        }
        public void Move(Player player)
        {
            do
            {
                _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                var playerMove = _input.InputText();
                
                if (IsExitIntent(playerMove)) break;

                Coordinate coordinate;
                if (_coordinateParser.IsValidFormat(playerMove))
                {
                    coordinate = SetCoordinate(playerMove);
                }
                else
                {
                    _output.OutputText(Resources.IncorrectFormat);
                    _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                    continue;
                }
                
                if (_coordinateParser.IsValidCoordinate(coordinate, _board))
                {
                    if (_board.CellIsAvailable(coordinate))
                    {
                        PlayMove(player, coordinate);
                        break;
                    }
                    _output.OutputText(string.Format(Resources.CellUnavailable)); 
                }
                else
                {
                    _output.OutputText(string.Format(Resources.OutsideOfBounds));
                }
                _output.OutputText(string.Format(Resources.TakeTurn,player.Name));
            } while (true);
        }

        private Game game;
        public bool IsExitIntent(string playerMove) 
        {
            if (playerMove != "q") return false;
            game.ExitApp();
            return true;
        }

        private Coordinate SetCoordinate(string playerMove)
        {
            return _coordinateParser.GetCoordinates(playerMove);
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