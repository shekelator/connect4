using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Play(new[] {1, 1, 2, 2, 3, 5});
            Console.ReadKey();
        }
    }
}
