using System;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }

        public static int Factorial (int n)
        {
            if (n < 2) return 1;
            return n * Factorial(n - 1);
        }
    }
}
