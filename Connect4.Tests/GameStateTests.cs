using Xunit;

namespace Connect4.Tests
{
    public class GameStateTests
    {
        private GameState m_state;

        public GameStateTests()
        {
            m_state = new GameState();
        }

        [Fact]
        public void InitialStateOfBoardIsCorrect()
        {
            Assert.Equal(35, m_state.Board.Length);
            Assert.Equal(5, m_state.Board.GetLength(0));
            Assert.Equal(7, m_state.Board.GetLength(1));
            Assert.Equal(Position.Open, m_state.Board[0,0]);
            Assert.Equal(Position.Open, m_state.Board[3,6]);
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
    }
}
