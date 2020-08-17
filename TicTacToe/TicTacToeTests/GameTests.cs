using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        
        [Fact]
        public void ExitAppCalledOnQInput()
        {
            var input = new TestInput(new string[] {"q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new TestCoordinateParser(validCoordinateResults: true, true);
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();

            Assert.False(runner.Running);
            Assert.Equal(1, input.CalledCount);
        }
        
        [Fact]
        public void InvalidPlayerMoveFormatDoesNotCallBoardIsValidCoordinate()
        {
            var input = new TestInput(new[] {"1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Human", "O")};
            var board = new TestBoard(new[] {false});
            var coordinateParser = new TestCoordinateParser(validCoordinateResults: true, false);
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.Contains("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(0, board.CalledCount);
        }

        [Fact]
        public void BoardPrintsWithMultipleCoordinates()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.Contains("X O X \nO O X \nX X O ", output.CalledText);
        }
        
        [Fact]
        public void DrawReturnsNotification_IfBoardSize3()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.Contains("It's a draw!", output.CalledText);
            Assert.Equal(9, input.CalledCount);
        }

        [Fact]
        public void DrawReturnsNotification_IfBoardSize4()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "1,4", "2,1", "2,2", "2,3", "2,4", "3,1", "3,3", "3,2", "3,4", "4,4", "4,2", "4,3", "4,1"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 4);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);
        
            runner.Run();
            
            Assert.Contains("It's a draw!", output.CalledText);
            Assert.Equal(16, input.CalledCount);
        }
        
        [Fact]
        public void WinReturnsNotification()
        {
            var input = new TestInput(new string[] {"1,1", "1,2", "2,2", "2,3", "3,3"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.Contains("Congratulations Human! You have won!", output.CalledText);
            Assert.Equal(5, input.CalledCount);
        }

        [Fact]
        public void WinCallsExitApp()
        {
            var input = new TestInput(new[] {"1,1", "2,2", "1,2", "3,1", "1,3"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.False(runner.Running);
            Assert.Equal(5, input.CalledCount);
        }
        
        [Fact]
        public void DrawCallsExitApp()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Human", "X"), new Player("Human", "O")};
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();
            
            Assert.False(runner.Running);
            Assert.Equal(9, input.CalledCount);
        }

        [Fact]
        public void HumanPlayerTurnCallsRunPlay()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Human", "O")};
            var board = new TestBoard(new bool[] {true});
            var coordinateParser = new TestCoordinateParser( validCoordinateResults: true, true);
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();

            Assert.Contains("Human enter a coord x,y to place your X or enter 'q' to give up:", output.CalledText);
        }
        
        [Fact]
        public void ComputerPlayerTurnCallsRunComputerPlay()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Computer", "X")};
            var board = new TestBoard(new bool[] {true});
            var coordinateParser = new TestCoordinateParser( validCoordinateResults: true, true);
            var runner = new Game(input, output, players, board, coordinateParser);

            runner.Run();

            Assert.Contains("Just one moment, Computer is taking it's turn...", output.CalledText);
        }
    }
}