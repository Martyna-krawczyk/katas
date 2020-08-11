using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Cell[,] _cell;

        public Board(IOutput output, int size)
        {
            _output = output;
            Size = size;
            CreateBoard();
        }

        private readonly IOutput _output;
        public int Size { get; }

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

        public IEnumerable<bool> GetAllCellsAvailabilityFromBoard()
        {
            var cellsAvailabilityList = new List<bool>();
            
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    cellsAvailabilityList.Add(_cell[x, y].IsAvailable);
                }
            }
            return cellsAvailabilityList;
        }
        
        public IEnumerable<List<string>> GetAllBoardWinningLineValues()
        {
            var linesValuesList = new List<List<string>>();
            var diagonalListLtr = new List<string>();
            var diagonalListRtl = new List<string>();
            
            var reverseIndexer = Size - 1;
            
            for (var row = 0; row < Size; row++)
            {
                var rowList = new List<string>();
                var columnList = new List<string>();

                diagonalListLtr.Add(_cell[row,row].Value);
                diagonalListRtl.Add(_cell[row, reverseIndexer].Value);
                
                for (var col = 0; col < Size; col++)
                {
                    rowList.Add(_cell[row,col].Value);
                    columnList.Add(_cell[col,row].Value);
                }
                reverseIndexer--;
                
                linesValuesList.Add(rowList);
                linesValuesList.Add(columnList);
            }
            linesValuesList.Add(diagonalListLtr);
            linesValuesList.Add(diagonalListRtl);
            return linesValuesList;
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).Value = player.Token;
            MarkCellAsUnavailable(coordinate);
        }
        
        private void MarkCellAsUnavailable(Coordinate coordinate)
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

        public void PrintBoard()
        {
            var boardString = "";  
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    boardString +=_cell[x,y].Value + " ";
                }
                if (x < Size - 1)
                {
                    boardString += Environment.NewLine;
                }
            }
            _output.OutputText(boardString);
        }

        public IEnumerable<Cell> GetAvailableCells()
        {
            var availableCellsList = new List<Cell>();
            
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    if (_cell[x,y].IsAvailable)
                    {
                        availableCellsList.Add(_cell[x, y]);
                    }
                }
            }
            return availableCellsList;
        }
    }
}
