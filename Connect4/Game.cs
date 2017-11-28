using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SuccincT.Options;

namespace Connect4
{
    public class Game
    {
        public Result Play(IEnumerable<int> moves)
        {
            var state = new GameState();
            try
            {
                foreach (var move in moves)
                {
                    state.Move(move);
                    Console.WriteLine("Move is {0}", move);
                    Console.WriteLine(state.GetBoardAsString());
                }
            }
            catch (InvalidMoveException)
            {
                return Result.Invalid;
            }

            return Evaluator(state).Match<Result>()
                .None().Do(Result.Invalid)
                .Some().Where(x => x == CurrentPlayer.Player1).Do(Result.Player1)
                .Some().Where(x => x == CurrentPlayer.Player2).Do(Result.Player2)
                .Result();
        }

        public Option<CurrentPlayer> Evaluator(GameState state)
        {
            return Option<CurrentPlayer>.None();
        }

    }

    public class InvalidMoveException : Exception { }

    public enum Position
    {
        Open = 0,
        Player1 = 1,
        Player2 = 2
    }

    public enum CurrentPlayer
    {
        Player1 = 1,
        Player2 = 2
    }
}
