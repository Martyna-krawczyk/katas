using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var badComputerInput = new BadComputerMove(input);
            var output = new ConsoleOutput();
            var players = new List<Player>()
            {
                new Player("Player 1", "O", input, output),
                new Player("Player 2", "X", badComputerInput, output)
            };
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var game = new Game(output, players, board, coordinateParser);
            
            game.Run();
        }
    }
}
