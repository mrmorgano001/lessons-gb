using System;

namespace Task_1
{
    public class GetUser
    {
        public static int GetInfo(int count)
        {
            return count;
        }

        public static string GetGullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} + {lastName} + {patronymic}";
        }
    }
}