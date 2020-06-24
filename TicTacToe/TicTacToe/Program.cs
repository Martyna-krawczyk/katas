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
                new Player("Player 1", "X"),
                new Player("Player 2", "O")
            };
            var board = new Board(output);
            var runner = new AppRunner(input, output, players, board);
            
            runner.Run();
        }
    }
}
