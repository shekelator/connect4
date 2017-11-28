using System.ComponentModel.Design.Serialization;

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

            TogglePlayer();
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