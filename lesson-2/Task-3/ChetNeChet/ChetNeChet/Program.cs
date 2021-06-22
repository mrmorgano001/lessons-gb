using System;

namespace ChetNeChet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            var number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Число четное.");
            }else 
                Console.WriteLine("Число нечетное.");

            Console.ReadKey();
        }
    }
}