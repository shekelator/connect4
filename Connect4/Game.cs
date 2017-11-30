using System;
using System.Collections.Generic;
using SuccincT.Options;

namespace Connect4
{
    public class Game
    {
        public Result Play(IEnumerable<int> moves)
        {
            var state = new GameState();
            Option<Result> winner;
            try
            {
                foreach (var move in moves)
                {
                    winner = state.GetWinner();
                    if (winner.HasValue)
                    {
                        throw new InvalidMoveException();
                    }
                    
                    state.Move(move);
                }
            }
            catch (InvalidMoveException)
            {
                return Result.Invalid;
            }

            return state.GetWinner().Match<Result>()
                .None().Do(Result.Invalid)
                .Some().Do(x => x)
                .Result();
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
