using Xunit;

namespace Connect4.Tests
{
    public class GameStateTests
    {
        private readonly GameState m_state;

        public GameStateTests()
        {
            m_state = new GameState();
        }

        [Fact]
        public void Player1GoesFirst()
        {
            Assert.Equal(CurrentPlayer.Player1, m_state.CurrentPlayerUp);
        }

        [Fact]
        public void Player2GoesNext()
        {
            m_state.Move(2);
            Assert.Equal(CurrentPlayer.Player2, m_state.CurrentPlayerUp);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(8)]
        [InlineData(17)]
        public void InvalidMoveThrows(int move)
        {
            Assert.Throws<InvalidMoveException>(() => m_state.Move(move));
        }

    }
}
