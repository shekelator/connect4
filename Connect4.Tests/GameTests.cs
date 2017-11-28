using System.Collections.Generic;
using System.Linq;
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

        [Fact(Skip="TODO")]
        public void GameCanBeWon()
        {
            var moves = new List<int> {1, 1, 2, 2, 3, 3, 4};
            var result = m_game.Play(moves);

            Assert.Equal("Player1", result.ToString());
        }

        [Fact(Skip="TODO")]
        public void TooManyMovesIsInvalid()
        {
            var moves = new List<int> {1, 1, 2, 2, 3, 3, 4, 2};
            var result = m_game.Play(moves);

            Assert.Equal(InvalidResult, result.ToString());
        }
    }
}
