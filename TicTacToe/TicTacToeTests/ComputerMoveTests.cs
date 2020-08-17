using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class ComputerMoveTests
    {
        [Fact]
        public void BoardCellAvailableRunsPlayMoveForComputerTurn()
        {
            var output = new TestOutput();
            var players  = new List<Player>{new Player("Computer", "X")};
            var player = players[0];
            var board = new Board(output, 3);
            var computer = new BadComputerPlay(output, board);
            var coordinate = new Coordinate(0, 0);

            computer.PlayMove(player, coordinate);
            
            Assert.Contains("Move accepted, here's the current board:", output.CalledText);
        }
    }
}

