using System;

namespace Diagonal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var space = " ";
            string[,] array =
            {
                {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"},
                {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"}, {"1", "0"},
            };
            for (var i = 0; i < array.GetLength(0); i++)
            {
                space = space + " ";
                Console.WriteLine();
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(space + array[i,j]);
                } 
            }
        }
    }
}