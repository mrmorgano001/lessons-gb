using System;
using System.Runtime.Remoting;

namespace MonthChecker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите порядковый номер месяца: ");
                var month = Convert.ToInt32(Console.ReadLine());
                if (month == 1)
                    Console.Write("Январь");
                else if (month == 2)
                    Console.Write("Февраль");
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
                    Console.Write("Декабрь");
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