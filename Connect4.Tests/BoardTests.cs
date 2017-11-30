using System;
using System.Linq;
using SuccincT.Options;
using Xunit;

namespace Connect4.Tests
{
    public class BoardTests
    {
        private readonly Board m_board;

        public BoardTests()
        {
            m_board = new Board();
        }

        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1, 1 })]
        public void InvalidMovesThrow(int[] moves)
        {
            Action a = () =>
            {
                foreach (var move in moves)
                {
                    m_board.PutMoveOnBoard(CurrentPlayer.Player1, move);
                }
            };

            Assert.Throws<InvalidMoveException>(a);
        }

        [Theory]
        [InlineData(1, "x x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \n1 x x x x x x \n")]
        [InlineData(7, "x x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x 1 \n")]
        public void BoardPrintsCorrectly(int move, string expected)
        {
            m_board.PutMoveOnBoard(CurrentPlayer.Player1, move);

            var printed = m_board.ToString();
            Assert.Equal(expected, printed);
        }

        [Theory]
        [InlineData(new [] { 1, 1, 2, 2, 3, 3, 4 })]
        [InlineData(new [] { 1, 2, 1, 2, 1, 2, 1 })]
        public void CanDetectWinner(int[] moves)
        {
            var i = 0;
            foreach (var move in moves)
            {
                var player = i++ % 2 == 0
                    ? CurrentPlayer.Player1
                    : CurrentPlayer.Player2;
                
                m_board.PutMoveOnBoard(player, move);
            }

            Assert.Equal(m_board.GetWinner().Value, Result.Player1);
        }
    }
}