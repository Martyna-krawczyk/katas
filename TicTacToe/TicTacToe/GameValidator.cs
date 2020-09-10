namespace TicTacToe
{
    public static class GameValidator
    {
        public static void TakeTurn(Player player, IBoard board, IOutput output, Game game, IValidator validator, ICoordinateParser coordinateParser)
        {
            do
            {
                output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                var playerMove = player.InputText();
                if (game.ExitIntent(playerMove)) break;
                
                Coordinate coordinate;
                if (validator.IsValidFormat(playerMove))
                {
                    coordinate = coordinateParser.GetNewCoordinate(playerMove);
                }
                else
                {
                    output.OutputText(Resources.IncorrectFormat);
                    continue;
                }
                
                if (validator.IsValidCoordinate(coordinate, board))
                {
                    if (board.CellIsAvailable(coordinate))
                    {
                        game.RunPlayerMove(player, coordinate);
                        break;
                    }
                    output.OutputText(string.Format(Resources.CellUnavailable)); 
                }
                else
                {
                    output.OutputText(string.Format(Resources.OutsideOfBounds));
                }
            } while (true);
        }
    }
}