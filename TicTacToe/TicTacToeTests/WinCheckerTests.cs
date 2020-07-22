using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class WinCheckerTests
    {
        [Fact]
          public void HorizontalWinReturnsTrue() 
          {
              var output = new TestOutput();
              var board = new Board(output, 3);
              var player = new Player("Player 1", "X");
              board.AssignTokenToCell(player, new Coordinate(0,0));
              board.AssignTokenToCell(player, new Coordinate(0,1));
              board.AssignTokenToCell(player, new Coordinate(0,2));
              var winChecker = new WinChecker();
         
              var result = winChecker.HasWin(player, board.GetCellArray() );
              
              Assert.True(result);
          } 
          [Fact]
          public void VerticalWinReturnsTrue()
          {
              var output = new TestOutput();
              var board = new Board(output, 3);
              var player = new Player("Player 1", "X");
              board.AssignTokenToCell(player, new Coordinate(0,0));
              board.AssignTokenToCell(player, new Coordinate(1,0));
              board.AssignTokenToCell(player, new Coordinate(2,0));
              var winMonitor = new WinChecker();
         
              var result = winMonitor.HasWin(player, board.GetCellArray());
              
              Assert.True(result);
          }
          [Fact]
          public void LTRDiagonalWinReturnsTrue()
          {
              var output = new TestOutput();
              var board = new Board(output, 3);
              var player = new Player("Player 1", "X");
              board.AssignTokenToCell(player, new Coordinate(0,0));
              board.AssignTokenToCell(player, new Coordinate(1,1));
              board.AssignTokenToCell(player, new Coordinate(2,2));
              var winMonitor = new WinChecker();
         
              var result = winMonitor.HasWin(player, board.GetCellArray());
              
              Assert.True(result);
          }
          [Fact]
          public void RTLDiagonalWinReturnsTrue()
          {
              var output = new TestOutput();
              var board = new Board(output, 3);
              var player = new Player("Player 1", "X");
              board.AssignTokenToCell(player, new Coordinate(0,2));
              board.AssignTokenToCell(player, new Coordinate(1,1));
              board.AssignTokenToCell(player, new Coordinate(2,0));
              var winMonitor = new WinChecker();
         
              var result = winMonitor.HasWin(player, board.GetCellArray());
              
              Assert.True(result);
          }
    }
}