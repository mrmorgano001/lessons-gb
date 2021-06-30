using System;

namespace seasons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Введите номер месяца: ");
            if (Int32.TryParse(Console.ReadLine(), out number))
            {
                if (number < 1 || number > 12)
                    Console.WriteLine("Не верное значение");
                else
                    Console.WriteLine(CheckSeasons.finalSeason(CheckSeasons.choiseSeason(number)));
            }
            else
            {
                Console.WriteLine("Вы ввели текст, попробуйте еще раз");
            }
        }
    }
}