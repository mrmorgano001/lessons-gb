using System;
using System.IO;

namespace TextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите произвольные данные: ");
            string line = Console.ReadLine();
            File.WriteAllText("text.txt", line);
            Console.ReadKey();
        }
    }
}