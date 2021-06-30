using System;
using System.Configuration;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int j = 0;
            Console.WriteLine("Сколько будет пользователей? ");
            int i = Convert.ToInt32(Console.ReadLine());
            string[] users = new string[i];
            for (j = 0; j < users.Length; j++)
            {
                Console.Write("Введите фамилию: ");
                string firstName = Console.ReadLine();
                Console.Write("Введите имя: ");
                string lastName = Console.ReadLine();
                Console.Write("Введите отчество: ");
                string patronymic = Console.ReadLine();
                users[j] = GetFullName(firstName,lastName,patronymic);
            }
            
            for (j = 0; j < users.Length; j++)
            {
                Console.WriteLine(j + 1 + "-й " + users[j]);
            }
        }
        public static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {lastName} {patronymic}";
        }
    }
}