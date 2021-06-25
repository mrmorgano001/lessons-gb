using System;

namespace SeaFight
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[,] seaFight = new string [10,10];
            
            for (int i = 0; i < seaFight.GetLength(0); i++)
            {
                for (int j = 0; j < seaFight.GetLength(1); j++)
                {
                    seaFight[i, j] = "O";
                    seaFight[j, j] = "X";
                    
                    Console.Write($"{seaFight[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}