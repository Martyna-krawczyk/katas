using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        [Fact]
        public void ComputerPlayerTokenIsX()
        {
            var computer = new Player("Computer", "X");
            
            Assert.Equal("X", computer.Token);
        }
        [Fact]
        public void HumanPlayerTokenIsO()
        {
            var player = new Player("Player", "O");
            
            Assert.Equal("O", player.Token);
        }

        public void HumanPlayerMove()
        {
            
        }
    }
}