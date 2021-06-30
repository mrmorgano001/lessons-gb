using System;

namespace Calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                sum += Convert.ToInt32(words[i]);
            }
            Console.WriteLine($"{sum}");
        }
    }
}