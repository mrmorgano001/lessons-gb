using System;

namespace Prognoz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int average = 0;
            Console.Write("Введите порядковый номер месяца: ");
            if (Int32.TryParse(Console.ReadLine(), out int month))
            {
                if (month == 1 || month == 2 || month == 12)
                {
                    Console.Write("Введите максимальную температуру: ");
                    int max = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите минимальную температуру: ");
                    int min = Convert.ToInt32(Console.ReadLine());
                    average = (max + min) / 2;
                }
                switch (month)
                    {
                        case 1:
                            Console.WriteLine("Январь");
                            if (average > 0)
                                Console.WriteLine("Дождливая зима");
                            break;
                        case 2:
                            Console.WriteLine("Февраль");
                            if (average > 0)
                                Console.WriteLine("Дождливая зима");
                            break;
                        case 3:
                            Console.WriteLine("Март");
                            break;
                        case 4:
                            Console.WriteLine("Апрель");
                            break;
                        case 5:
                            Console.WriteLine("Май");
                            break;
                        case 6:
                            Console.WriteLine("Июнь");
                            break;
                        case 7:
                            Console.WriteLine("Июль");
                            break;
                        case 8:
                            Console.WriteLine("Август");
                            break;
                        case 9:
                            Console.WriteLine("Сентябрь");
                            break;
                        case 10:
                            Console.WriteLine("Октябрь");
                            break;
                        case 11:
                            Console.WriteLine("Ноябрь");
                            break;
                        case 12:
                            Console.WriteLine("Декабрь");
                            if (average > 0)
                                Console.WriteLine("Дождливая зима");
                            break;
                        default:
                            Console.WriteLine("Такого месяца нет");
                            break;
                    }
                }
            else
                    Console.WriteLine("Вы ввели не число");
                Console.ReadKey();
            }
        }
}
