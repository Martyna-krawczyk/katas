using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        private readonly Board _board;
        public int _boardSize;
        private Cell _cell;
        private Coordinate _coordinate;
        public bool Running { get; set; } = true;

        private readonly List<Player> _players;
        private readonly IInput _input;
        private readonly IOutput _output;

        public AppRunner(IInput input, IOutput output, List<Player> players)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = new Board(_output, _boardSize, _coordinate, _players);
        }
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            _board.PrintBoard();

            do
            {
                var player = _players[turns % _players.Count];
                RunPlay(player);
                turns++;
                //Check for wins - horizontal, vertical, diagonal
                //check for draw = turns == 10
            } while (Running);
        }


        private void RunPlay(Player player)
        {
            _output.OutputText(string.Format(Prompts.TakeTurn, player.Name));
            string playerMove;
            do
            {
                playerMove =_input.InputText();
                
                if (playerMove == "q")
                {
                    ExitApp();
                    break;
                }
                if (ValidCoordinates(playerMove) ) // && board.IsUsed == false
                {
                    PlayMove(playerMove, player, _coordinate);
                }
                else
                {
                    _output.OutputText("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:");
                }
            } while (!ValidCoordinates(playerMove));
            
        }

        private void PlayMove(string playerMove, Player player, Coordinate coordinate)
        {
            CoordinateParser(playerMove, player, coordinate);
            // _board.GetCellByCoordinates(_coordinate);
            // _board.AssignTokenToCell(player, _coordinate);
            _output.OutputText(Prompts.MoveAccepted);
            _board.PrintBoard();
        }

        private void CoordinateParser(string playerMove, Player player, Coordinate coordinate)
        {
            
            var stringCoordinates = playerMove.Split(",");
            var parsedXCoordinate = Convert.ToInt32(stringCoordinates[0]);
            var parsedYCoordinate = Convert.ToInt32(stringCoordinates[1]);
            var finalXCoordinate = parsedXCoordinate - 1;
            var finalYCoordinate = parsedYCoordinate - 1;
            //check coordinates are within the bounds of the board
            Coordinate data = new Coordinate(finalXCoordinate,finalYCoordinate);
            if (finalXCoordinate <= _board._boardSize && finalXCoordinate > 0 
                                                      && finalYCoordinate <= _board._boardSize && finalYCoordinate > 0)
            {
               data  = new Coordinate(finalXCoordinate,finalYCoordinate);
                
            }
            
            _board.GetCellByCoordinates(data).Value = player.Token;
            //_board.AssignTokenToCell(_player);
            //validate that the parsed x and y coordinates are within the bounds of the board
        }
        
        private static bool ValidCoordinates(string PlayerMove)
        {
            var regex = new Regex(@"^[1-3],[1-3]$");
            return regex.IsMatch(PlayerMove);
        }

        private void ExitApp()
        {
            Running = false;
        }

    }
}