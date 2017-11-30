using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using SuccincT.Options;

namespace Connect4
{
    public class Board
    {
        private Position[,] Positions { get; }
        
        private const int BoardWidth = 7;
        private const int BoardHeight = 5;

        private List<Position[]> Rows => Positions.ToJaggedArray().ToList();

        private List<Position[]> Columns
        {
            get
            {
                return Enumerable.Range(1, BoardWidth)
                    .Select(col => Enumerable.Range(1, BoardHeight).Select(row => Positions[row-1, col-1]).ToArray())
                    .ToList();
            }
        }

        public bool BoardFilled => Rows.SelectMany(r => r).All(p => p != Position.Open);

        public Board()
        {
            Positions = new Position[BoardHeight,BoardWidth];
            for (var i = 0; i < BoardHeight; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    Positions[i, j] = Position.Open;
                }
            }
        }

        public void PutMoveOnBoard(CurrentPlayer player, int column)
        {
            if (column <= 0 || column > BoardWidth)
            {
                throw new InvalidMoveException();
            }

            var zeroIndexedColumn = column - 1;
            for (var i = BoardHeight - 1; i >= 0; i--)
            {
                if (Positions[i, zeroIndexedColumn] != Position.Open) continue;

                Positions[i, zeroIndexedColumn] = player == CurrentPlayer.Player1
                    ? Position.Player1
                    : Position.Player2;
                return;
            }

            throw new InvalidMoveException();
        }
        public override string ToString()
        {
            var builder = new StringBuilder(BoardHeight * BoardWidth);
            for (var i = 0; i < BoardHeight; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    char charToShow;
                    switch (Positions[i, j])
                    {
                        case Position.Open:
                            charToShow = 'x';
                            break;
                        case Position.Player1:
                            charToShow = '1';
                            break;
                        case Position.Player2:
                            charToShow = '2';
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    builder.Append(charToShow);
                    builder.Append(' ');
                }
                builder.Append('\n');
            }
            return builder.ToString();
        }

        public Option<Result> GetWinner()
        {
            // check rows
            var winningRow = Rows.FirstOrDefault(r => FindWinner(r) != Position.Open);
            if (winningRow != null)
            {
                return PositionOwnedBy(FindWinner(winningRow));
            }

            // check columns
            var winningColumn = Columns.FirstOrDefault(c => FindWinner(c) != Position.Open);
            if (winningColumn != null)
            {
                return PositionOwnedBy(FindWinner(winningColumn));
            }

            return Option<Result>.None();
        }

        private Position FindWinner(Position[] positions)
        {
            var counter = new Stack<Position>();
            foreach (var pos in positions)
            {
                var any = counter.TryPeek(out var currentlyOnStack);
                if (!any || pos == currentlyOnStack)
                {
                    counter.Push(pos);
                    if (counter.Count == 4)
                    {
                        return pos;
                    }
                }
                else
                {
                    counter.Clear();
                    counter.Push(pos);
                }
            }
            return Position.Open;
        }

        private Result PositionOwnedBy(Position player)
        {
            switch (player)
            {
                case Position.Player1:
                    return Result.Player1;
                case Position.Player2:
                    return Result.Player2;
                default:
                    return Result.Invalid;
            }
        }
    }

    /// <summary>
    /// From https://stackoverflow.com/a/45794393/43271
    /// </summary>
    internal static class ExtensionMethods
    {
        internal static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex - rowsFirstIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex - columnsFirstIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = 0; j < numberOfColumns; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i + rowsFirstIndex, j + columnsFirstIndex];
                }
            }
            return jaggedArray;
        }
    }
}