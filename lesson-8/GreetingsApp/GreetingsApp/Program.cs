using System;

namespace GreetingsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName) || string.IsNullOrEmpty(Properties.Settings.Default.UserProfession) || string.IsNullOrEmpty(Properties.Settings.Default.UserAge))
            {
                Console.Write("Введите свое имя: ");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Console.Write("Введите свой возраст: ");
                Properties.Settings.Default.UserAge = Console.ReadLine();
                Console.Write("Введите свою профессию: ");
                Properties.Settings.Default.UserProfession = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.UserName;
            string userAge = Properties.Settings.Default.UserAge;
            string userProfession = Properties.Settings.Default.UserProfession;
            Console.WriteLine($"Привет {userName}, твой возраст {userAge}, твоя профессия {userProfession}!");
            Console.ReadKey();
        }
    }
}
