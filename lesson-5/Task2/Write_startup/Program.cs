using System;
using System.IO;

namespace Write_startup
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "text.txt";
            Console.WriteLine("На данный момент системное время: " + DateTime.Now.ToString("HH:mm:ss"));
            File.AppendAllText(filename, $"{Environment.NewLine + DateTime.Now:HH:mm:s}");
        }
    }
}