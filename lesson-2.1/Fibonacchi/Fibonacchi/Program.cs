using System;

namespace Fibonacchi
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static int Fibonacchi1(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacchi1(n - 1) + Fibonacchi1(n - 2);
            }
        }
        static int Fibonacchi2(int n)
            {
                int a = 0;
                int b = 1;
                for (int i = 0; i < n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return a;
            }
        static void TestFibonacchi(TestCase testCase)
        {
            try
            {
                var result = Fibonacchi1(testCase.N);
                var result2 = Fibonacchi2(testCase.N);
                if (result == testCase.Expected && result2 == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST!");
                }
                else
                {
                    Console.WriteLine("INVALID TEST!");
                }
            }
            
        }
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                N = 10,
                Expected = 55,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 0,
                Expected = 0,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 13,
                Expected = 100,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = 15,
                Expected = 101,
                ExpectedException = null
            };
            TestFibonacchi(testCase1);
            TestFibonacchi(testCase2);
            TestFibonacchi(testCase3);
            TestFibonacchi(testCase4);
            TestFibonacchi(testCase5);
        }
    }
}
