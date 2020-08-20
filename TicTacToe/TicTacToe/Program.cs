using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = 3;
            
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var board = new Board(output, boardSize);
            var badComputerInput = new BadComputerInput(input, board);
            
            var players = new List<Player>()
            {
                new Player("Player 1", "O", input, output),
                new Player("Bad Computer Player", "X", badComputerInput, output)
            };
            
            var coordinateParser = new CoordinateParser();
            var game = new Game(output, players, board, coordinateParser);
            
            game.Run();
        }
    }
}
