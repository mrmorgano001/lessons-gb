using System;

namespace HelloUserName
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите имя пользователя: ");
            var userName = Console.ReadLine();
            var dateTime = DateTime.Now;
            Console.WriteLine($"Привет {userName}, сейчас {dateTime} !");
            Console.ReadKey();
        }
    }
}