using System;
namespace MinMaxTemp
{
  internal class Program
  {
    public static void Main(string[] args)
    {
    Console.WriteLine("Введите максимальную температуру: ");
    var max = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите минимальную температуру: ");
    var min = Convert.ToInt32(Console.ReadLine());
    int average = (min + max) / 2;
    Console.WriteLine($"Средняя температура за сутки: {average}");
    Console.ReadKey();
    }
  }
}