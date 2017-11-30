using SuccincT.Options;

namespace Connect4
{
    public class GameState
    {
        public Board Board { get; }
        public CurrentPlayer CurrentPlayerUp { get; private set; } = CurrentPlayer.Player1;

        public GameState()
        {
            Board = new Board();
        }

        public void Move(int column)
        {
            Board.PutMoveOnBoard(CurrentPlayerUp, column);
            TogglePlayer();
        }

        private void TogglePlayer()
        {
            CurrentPlayerUp =
                CurrentPlayerUp == CurrentPlayer.Player1
                    ? CurrentPlayer.Player2
                    : CurrentPlayer.Player1;
        }

        public Option<Result> GetWinner()
        {
            return Board.GetWinner();
        }

    }
}