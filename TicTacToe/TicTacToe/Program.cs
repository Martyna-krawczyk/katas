using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var players = new List<Player>()
            {
                new Player("Player 1", "O"),
                new Player("Computer", "X")
            };
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);
            
            runner.Run();
        }
    }
}
