using System;
using System.IO;
using System.Linq;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = args[0];
            var outputFile = args[1];

            string[] lines;
            using (var inputStream = new StreamReader(inputFile))
            {
                lines = inputStream.ReadToEnd().Split('\n');
            }

            using (var outputStream = new StreamWriter(outputFile))
            {
                foreach (var line in lines)
                {
                    var moves = line.Split(' ').Select(int.Parse);
                    var game = new Game();
                    var result = game.Play(moves);
                    outputStream.WriteLine(result.ToString());
                }
            }

            Console.WriteLine($"Done. Output written to {outputFile}");
            Console.ReadKey();
        }
    }
}
