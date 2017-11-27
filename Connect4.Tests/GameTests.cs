using System.Collections.Generic;
using Xunit;

namespace Connect4.Tests
{
    public class GameTests
    {
        private Game _game;

        public GameTests()
        {
            _game =new Game();
        }

        [Fact]
        public void NoMovesIsAnInvalidGame()
        {
            var result = _game.Play(new List<int>());

            Assert.Equal("Invalid", result.ToString());
        }

        [Fact]
        public void GameCanBeWon()
        {
            var moves = new List<int> {1, 1, 2, 2, 3, 3, 4};
            var result = _game.Play(moves);

            Assert.Equal("Player1", result.ToString());
        }
    }
}
