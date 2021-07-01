using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите произвольный набор чисел от 0 до 255");
            string numbers = Console.ReadLine();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new FileStream("numbers.bin", FileMode.OpenOrCreate), numbers);
        }
    }
}