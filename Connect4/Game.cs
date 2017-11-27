using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4
{
    public class Game
    {
        public Result Play(List<int> moves)
        {
            return Result.Invalid;
        }
    }

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
