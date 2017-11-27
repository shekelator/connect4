namespace Connect4
{
    public class GameState
    {
        public Position[,] Board { get; }
        public CurrentPlayer CurrentPlayerUp { get; private set; } = CurrentPlayer.Player1;

        public GameState()
        {
            Board = new Position[5,7];
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    Board[i, j] = Position.Open;
                }
            }
        }

        public void Move(int column)
        {
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