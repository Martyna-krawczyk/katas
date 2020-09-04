using System;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestBadComputerInput : IInput
    {
        public string InputText()
        {
            return SetNewCoordinate().ToString();
        }
        
        private static Coordinate SetNewCoordinate()
        {
            return new Coordinate(1, 2);
        }
    }
}