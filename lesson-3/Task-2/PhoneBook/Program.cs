using System;

namespace PhoneBook
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[,] phonebook = {{"Михаил", "89539595959"}, {"Валерий", "949494949494"}, {"Ваня", "84884848484"}, {"Максим", "949494949494"},{"Владислав", "949494949494"}};

            for (var i = 0; i < phonebook.GetLength(0); i++)
            {
                for (var j = 0; j < phonebook.GetLength(1); j++)
                {
                    Console.Write(phonebook[i,j] + Environment.NewLine);
                }
            }
        }
    }
}