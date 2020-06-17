namespace TicTacToe
{
    public class Game
    {
        // //Player Class
        // private int _player = 2; 
        // private string _playerToken = "";
        //
        // private string _playerMove = "0,0";
        // public void Play()
        // {
        //     _output.OutputText(string.Format(Prompts.TakeTurn, _player));
        //
        //     _playerToken = _player switch
        //     {
        //         1 => "X",
        //         2 => "O",
        //         _ => _playerToken
        //     };
        //     
        //     do
        //     {
        //         _playerMove =_input.InputText();
        //         
        //         if (_playerMove == "q")
        //         {
        //             ExitApp();
        //             break;
        //         }
        //         if (ValidCoordinates(_playerMove) ) // && board.IsUsed == false
        //         {
        //             PlayMove();
        //         }
        //         else
        //         {
        //             _output.OutputText("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:");
        //         }
        //     } while (!ValidCoordinates(_playerMove));
        //     
        // }
        //
        // private void PlayMove()
        // {
        //     EstablishTokenCoordinates(_playerMove);
        //     _output.OutputText(Prompts.MoveAccepted);
        //     _board.PrintBoard();
        // }
        //
        // private void EstablishTokenCoordinates(string playerMove)
        // {
        //     int parsedXCoordinate = 0;
        //     int parsedYCoordinate = 0;
        //     var xInput = playerMove[0].ToString();
        //     var yInput = playerMove[2].ToString();
        //
        //     if (short.TryParse(xInput, out var xCoordinate))
        //     {
        //         parsedXCoordinate =  xCoordinate - 1;
        //     }
        //     
        //     if (short.TryParse(yInput, out var yCoordinate))
        //     {
        //         parsedYCoordinate =  yCoordinate - 1;
        //     }
        //     _board.GetCellByCoordinates(parsedXCoordinate, parsedYCoordinate).Value = _playerToken;
        // }
        //
        // private static bool ValidCoordinates(string PlayerMove)
        // {
        //     var regex = new Regex(@"^[1-3],[1-3]$");
        //     return regex.IsMatch(PlayerMove);
        // }
    }
}