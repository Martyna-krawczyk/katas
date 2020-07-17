using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void CellOutsideOfBoardBounds_ReturnsNotification()
        {
            var input = new TestInput(new string[] {"4,5", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {false}, new bool[] { });
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();

            Assert.Contains("Oh no, those coordinates are outside the bounds of this board. Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void CellNotAvailable_ReturnsNotification()
        {
            var input = new TestInput(new string[] {"1,3", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {true}, new bool[] {false});
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();

            Assert.Contains(
                "Oh no, a piece is already at this place! Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }


        [Fact]
        public void ExitAppCalledOnQInput()
        {
            var input = new TestInput(new string[] {"q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new Board(output, 3);
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();

            Assert.False(runner.Running);
            Assert.Equal(1, input.CalledCount);
        }

        [Fact]
        public void ValidPlayerMoveFormatDoesNotPrintError()
        {
            var input = new TestInput(new string[] {"1,3", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {true}, new bool[] {false});
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();
            
            Assert.DoesNotContain("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(0, board.CalledCount);
        }
        
        [Fact]
        public void InvalidPlayerMoveFormatDoesNotCallBoardIsValidCoordinate()
        {
            var input = new TestInput(new string[] {"1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {false}, new bool[] {false});
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();
            
            Assert.Contains("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(-1, board.CalledCount);
        }
        
        [Fact]
        public void BoardPrintsWithCorrectCoordinates()
        {
            var input = new TestInput(new string[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new Board(output, 3);
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();
            
            Assert.Contains("X . .\n. . .\n. . .", output.CalledText);
        }
        
        [Fact]
        public void DrawRegisteredAfterNineTurnsWithoutWin()
        {
            var input = new TestInput(new string[] {"1,1", "1,2", "1,3", "2,1", "2,2", "2,3", "3,1", "3,2", "3,3"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X"), new Player("Player 2", "O")};
            var board = new Board(output, 3);
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();
            
            Assert.Contains("It's a draw!", output.CalledText);
            Assert.Equal(9, input.CalledCount);
        }
        
        [Fact]
        public void HorizontalWinCallsExitApp()
        {
            var input = new TestInput(new string[] {"1,1", "2,2", "1,2", "3,1", "1,3"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X"), new Player("Player 2", "O")};
            var board = new Board(output, 3);
            List<string> cellList = new List<string>();
            var runner = new Game(input, output, players, board, cellList);

            runner.Run();
            
            Assert.False(runner.Running);
            Assert.Equal(5, input.CalledCount);
        } 
        
        // [Fact]
        //  public void HorizontalWinReturnsTrue()
        //  {
        //      //List<string> boardValues = new List<string>();
        //      var output = new TestOutput();
        //      var board = new Board(output, 3);
        //      var player = new Player("Player 1", "X");
        //      board.AssignTokenToCell(player, new Coordinate(0,0));
        //      board.AssignTokenToCell(player, new Coordinate(1,0));
        //      board.AssignTokenToCell(player, new Coordinate(2,0));
        //      var winMonitor = new WinConditionRuleChecker(board, new List<string>);
        //
        //      var result = winMonitor.HasWin(player, new Coordinate(0,0));
        //      
        //      Assert.True(result);
        //  }
    }
}