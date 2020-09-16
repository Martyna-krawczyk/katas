using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Resources.WelcomeMessage);
            
            var output = new ConsoleOutput();
            const int boardSize = 3;
            var board = new Board(boardSize);
            
            const int numberOfPlayers = 2;
            var numberOfComputerPlayers = ProgramInitializer.UserSetsPlayerPreference();
            
            var players = new List<Player>();
            var tokens = new List<string> {"O","X"};
            ProgramInitializer.InitialisePlayerList(numberOfPlayers, numberOfComputerPlayers, players, tokens, board);
            
            var coordinateParser = new CoordinateParser();
            var validator = new Validator();
            var game = new Game(output, board, coordinateParser, validator);
            
            output.OutputText(Resources.BoardIntro); 
            output.OutputText(BoardFormatter.PrintBoard(board));
            
            var turns = 0;
            do
            {
                var player = players[turns % players.Count];
                game.Run(player);
                turns++;
            } while (game.GameStatus == GameStatus.InProgress);
        }
    }
}
