using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Cell[,] _cell;
        private readonly IOutput _output;
        public int Size { get; set; }
        private List<string> cellList;
       
        
        public Board(IOutput output, int size)
        {
            _output = output;
            Size = size;
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            _cell = new Cell[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _cell[x, y] = new Cell(".");
                }
            }
        }
        
        public string GetBoardCellValues(Coordinate coordinate)
        {
            var value = "";
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    cellList.Add(GetCellByCoordinates(coordinate).Value);
                }
            }
            return value;
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).Value = player.Token;
            MarkCellAsUsed(coordinate);
        }
        
        public bool IsValidCoordinate(Coordinate coordinate)
        {
            return coordinate.X < Size && coordinate.X >= 0 && coordinate.Y < Size && coordinate.Y >= 0;
        }

        private void MarkCellAsUsed(Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).IsAvailable = false;
        }
        
        public bool CellIsAvailable(Coordinate coordinate)
        {
            return GetCellByCoordinates(coordinate).IsAvailable;
        }
        
        public Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }

        // public string GetCellValueByCoordinate(Coordinate coordinate)
        // {
        //     return GetCellByCoordinates(coordinate).Value; //Could this be a better way to print Board?!!
        // }
        
        public void PrintBoard()
        {
            _output.OutputText(
                string.Format(Prompts.BoardCoordinates, _cell[0,0].Value, _cell[0,1].Value, _cell[0,2].Value) 
                + Environment.NewLine 
                + string.Format(Prompts.BoardCoordinates, _cell[1,0].Value, _cell[1,1].Value, _cell[1,2].Value) 
                + Environment.NewLine 
                + string.Format(Prompts.BoardCoordinates, _cell[2,0].Value, _cell[2,1].Value, _cell[2,2].Value));
        }
    }
}
