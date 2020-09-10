using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void PrintBoardMethodPrintsCorrectBoardAsGenerated()
        {
            var output = new TestOutput();
            var board = new Board(3);
            
            output.OutputText(BoardFormatter.PrintBoard(board));

            Assert.Contains(". . . \n. . . \n. . . ", output.CalledText);
        }
        
        [Fact]
        public void CellOutsideOfBoardBounds_ReturnsNotification()
        {
            var input = new TestInput(new[] {"4,5", "q"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Player 1", "X", input)};
            var board = new TestBoard(new[] {false});
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(validCoordinateResults: false, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();

            Assert.Contains("Oh no, those coordinates are outside the bounds of this board. Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void CellNotAvailable_ReturnsNotification()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new TestBoard(new bool[] {false});
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator( validCoordinateResults: true, true);
            var  game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();

            Assert.Contains("Oh no, a piece is already at this place! Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void ExitAppCalledOnQInput()
        {
            var input = new TestInput(new string[] {"q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(validCoordinateResults: true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Equal(GameStatus.GameOver, game.GameStatus);
            Assert.Equal(1, input.CalledCount);
        }

        [Fact]
        public void ValidPlayerMoveFormatDoesNotPrintError()
        {
            var input = new TestInput(new[] {"1,2", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new TestBoard(new[] {true});
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(validCoordinateResults: true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.DoesNotContain("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(1, board.CalledCount);
        }
        
        [Fact]
        public void InvalidPlayerMoveFormatDoesNotCallBoardIsValidCoordinate()
        {
            var input = new TestInput(new[] {"1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new TestBoard(new[] {false});
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(validCoordinateResults: true, false);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Contains("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(0, board.CalledCount);
        }
        
        [Fact]
        public void BoardPrintsWithCorrectCoordinates()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Contains("X . . \n. . . \n. . . ", output.CalledText);
        }
        
        [Fact]
        public void BoardPrintsWithMultipleCoordinates()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Player 1", "X", input), new Player("Player 2", "O", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Contains("X O X \nO O X \nX X O ", output.CalledText);
        }
        
        [Fact]
        public void DrawReturnsNotification_IfBoardSize3()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Player 1", "X", input), new Player("Player 2", "O", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Contains("It's a draw!", output.CalledText);
            Assert.Equal(9, input.CalledCount);
        }

        [Fact]
        public void WinReturnsNotification()
        {
            var input = new TestInput(new string[] {"1,1", "1,2", "2,2", "2,3", "3,3"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input), new Player("Player 2", "O", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Contains("Congratulations Player 1! You have won!", output.CalledText);
            Assert.Equal(5, input.CalledCount);
        }

        [Fact]
        public void WinCallsExitApp()
        {
            var input = new TestInput(new[] {"1,1", "2,2", "1,2", "3,1", "1,3"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Player 1", "X", input), new Player("Player 2", "O", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);

            game.Run();
            
            Assert.Equal(GameStatus.GameOver, game.GameStatus);
            Assert.Equal(5, input.CalledCount);
        }
        
        [Fact]
        public void DrawCallsExitApp()
        {
            var input = new TestInput(new[] {"1,1", "1,2", "1,3", "2,1", "2,3", "2,2", "3,1", "3,3", "3,2"});
            var output = new TestOutput();
            var players = new List<Player> {new Player("Player 1", "X", input), new Player("Player 2", "O", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var testValidator = new TestValidator(true, true);
            var game = new Game(output, players, board, coordinateParser, testValidator);
            
            game.Run();
            
            Assert.Equal(GameStatus.GameOver, game.GameStatus);
            Assert.Equal(9, input.CalledCount);
        }
        
        [Fact]
        public void BoardPrintsWithCorrectCoordinates_ImplementationTest()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var validator = new Validator();
            var game = new Game(output, players, board, coordinateParser, validator);

            game.Run();
            
            Assert.Contains("X . . \n. . . \n. . . ", output.CalledText);
        }
        
        [Fact]
        public void InvalidPlayerMoveReturnsNotification_ImplementationTest()
        {
            var input = new TestInput(new[] {"1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X", input)};
            var board = new Board(3);
            var coordinateParser = new CoordinateParser();
            var validator = new Validator();
            var game = new Game(output, players, board, coordinateParser, validator);

            game.Run();
            
            Assert.Contains("Sorry - that format is incorrect! Try again...", output.CalledText);
        }
    }
}