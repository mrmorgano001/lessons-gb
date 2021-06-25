using System;
using System.Linq;
using System.Xml;

namespace Reverse
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Console.Write("Введите слово: ");
            var word = Console.ReadLine();
            char[] reverse = word.ToCharArray();
            Array.Reverse(reverse);
            word = new string(reverse);
            Console.WriteLine(word);
            Console.ReadKey();
        }
    }
}