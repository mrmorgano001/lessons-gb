using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                N = 2,
                Expected = true,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 3,
                Expected = true,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 5,
                Expected = true,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 7,
                Expected = false,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = 11,
                Expected = false,
                ExpectedException = null
            };

            Test(testCase1);
            Test(testCase2);
            Test(testCase3);
            Test(testCase4);
            Test(testCase5);
        }

        public static bool Check(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                else
                {
                    i++;
                }
            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public class TestCase
        {
            public int N { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void Test(TestCase testCase)
        {
            try
            {
                var actual = Check(testCase.N);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST!");
                }
                else
                {
                    Console.WriteLine("INVALID TEST!");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

    }
}
