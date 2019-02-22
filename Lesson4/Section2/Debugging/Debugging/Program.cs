using System;
using System.Collections.Generic;
using System.Linq;
namespace Debugging
{

    class Foo
    {
        public string Name { get; } = "Some name;";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }

        public static int Factorial(int n)
        {
            var x = new List<Foo> { new Foo() };
            if (n < 2) return 1;
            return n * Factorial(n - 1);
        }
    }
}
