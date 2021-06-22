using System;

namespace Prognoz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int max = 0;
                int min = 0;
                int average = 0;
                Console.Write("Введите порядковый номер месяца: ");
                var month = Convert.ToInt32(Console.ReadLine());
                if (month == 1 || month == 2 || month == 12)
                {
                    Console.Write("Введите максимальную температуру: ");
                    max = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите минимальную температуру: ");
                    min = Convert.ToInt32(Console.ReadLine());
                    average = (min + max) / 2;
                }
                
                if (month == 1)
                {
                    Console.WriteLine("Январь");
                    if (average > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                }
                else if (month == 2)
                {
                    Console.WriteLine("Февраль");
                    if (average > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                }
                else if (month == 3)
                    Console.Write("Март");
                else if (month == 4)
                    Console.Write("Апрель");
                else if (month == 5)
                    Console.Write("Май");
                else if (month == 6)
                    Console.Write("Июнь");
                else if (month == 7)
                    Console.Write("Июль");
                else if (month == 8)
                    Console.Write("Август");
                else if (month == 9)
                    Console.Write("Сентябрь");
                else if (month == 10)
                    Console.Write("Октябрь");
                else if (month == 11)
                    Console.Write("Ноябрь");
                else if (month == 12)
                {
                    Console.WriteLine("Декабрь");
                    if (average > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                }
                else 
                    Console.Write("Введите корректный номер месяца");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}