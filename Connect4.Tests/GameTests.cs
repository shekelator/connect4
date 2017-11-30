using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Connect4.Tests
{
    public class GameTests
    {
        private const string InvalidResult = "Invalid";
        private readonly Game m_game;

        public GameTests()
        {
            m_game =new Game();
        }

        [Fact]
        public void NoMovesIsAnInvalidGame()
        {
            var result = m_game.Play(new List<int>());

            Assert.Equal(InvalidResult, result.ToString());
        }

        [Theory]
        [InlineData(new [] {3, 6, 0})]
        [InlineData(new [] {17, 3, 2})]
        [InlineData(new [] {417})]
        [InlineData(new int[0])]
        public void OutOfRangeMovesResultInInvalidGame(int[] moves)
        {
            var result = m_game.Play(moves);
            Assert.Equal(InvalidResult, result.ToString());
        }

        [Theory]
        [InlineData(new [] {1, 1, 2, 2, 3, 3, 4 }, "Player1")]
        public void GameCanBeWon(int[] moves, string winner)
        {
            var result = m_game.Play(moves);

            Assert.Equal(winner, result.ToString());
        }

        [Fact]
        public void TooManyMovesIsInvalid()
        {
            var moves = new List<int> {1, 1, 2, 2, 3, 3, 4, 2};
            var result = m_game.Play(moves);

            Assert.Equal(InvalidResult, result.ToString());
        }

        [Fact]
        public void CanBeADraw()
        {
            var moves = new List<int> {1, 1, 1, 1, 2, 2, 2, 2, 3, 4, 3, 4, 4, 3, 3, 4, 6, 5, 7, 5, 6, 7, 6, 7, 5, 1, 2, 3, 4, 6, 5, 7, 7, 5, 6};
            var result = m_game.Play(moves);

            Assert.Equal("Draw", result.ToString());
        }
    }
}
