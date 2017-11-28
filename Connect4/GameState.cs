using System;
using System.ComponentModel.Design.Serialization;
using System.Net.Sockets;
using System.Text;

namespace Connect4
{
    public class GameState
    {
        private const int BoardWidth = 7;
        private const int BoardHeight = 5;

        public Position[,] Board { get; }
        public CurrentPlayer CurrentPlayerUp { get; private set; } = CurrentPlayer.Player1;

        public GameState()
        {
            Board = new Position[BoardHeight,BoardWidth];
            for (var i = 0; i < BoardHeight; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    Board[i, j] = Position.Open;
                }
            }
        }

        public void Move(int column)
        {
            if (column <= 0 || column > BoardWidth)
            {
                throw new InvalidMoveException();
            }

            PutMoveOnBoard(column);
            TogglePlayer();
        }

        private void PutMoveOnBoard(int column)
        {
            var zeroIndexedColumn = column - 1;
            for (var i = BoardHeight - 1; i > 0; i--)
            {
                if (Board[i, zeroIndexedColumn] != Position.Open) continue;

                Board[i, zeroIndexedColumn] = CurrentPlayerUp == CurrentPlayer.Player1
                    ? Position.Player1
                    : Position.Player2;
                return;
            }

            throw new InvalidMoveException();
        }

        public string GetBoardAsString()
        {
            var builder = new StringBuilder(BoardHeight * BoardWidth);
            for (var i = 0; i < BoardHeight; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    char charToShow;
                    switch (Board[i, j])
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


        private void TogglePlayer()
        {
            CurrentPlayerUp =
                CurrentPlayerUp == CurrentPlayer.Player1
                    ? CurrentPlayer.Player2
                    : CurrentPlayer.Player1;
        }
    }
}