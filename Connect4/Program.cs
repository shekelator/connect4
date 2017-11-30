using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            // var moves = new[] {1, 1, 2, 2, 3, 3, 4, 4};
            var moves = new[] {1, 1, 2, 2, 3, 3, 5, 4, 5, 4};
            var result = game.Play(moves);
            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }
}
