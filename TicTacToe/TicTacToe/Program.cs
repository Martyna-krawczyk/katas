using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = 3;

            IInput input = null;
            var output = new ConsoleOutput();
            var board = new Board(output, boardSize);
            
            output.OutputText(Resources.WelcomeMessage);
            output.OutputText(Resources.ComputerOrPersonPlayerSelection);
            
            do
            {
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        output.OutputText(Resources.ComputerPlayerChosen);
                        input = new BadComputerInput(board);
                        break;
                    case "2":
                        input = new ConsoleInput();
                        break;
                    default:
                        output.OutputText(Resources.IncorrectPlayerSelection);
                        output.OutputText(Resources.ComputerOrPersonPlayerSelection);
                        break;
                }
            } while (input == null);

            var players = new List<Player>()
            {
                new Player("Player 1", "O", new ConsoleInput()),
                new Player("Player 2", "X", input)
            };
            
            var coordinateParser = new CoordinateParser();
            var game = new Game(output, players, board, coordinateParser);
            
            game.Run();
        }
    }
}
