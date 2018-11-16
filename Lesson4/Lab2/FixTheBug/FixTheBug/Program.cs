using System;

namespace FixTheBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var greet = "Hello ";
            SayHello(greet, "Onur");
            Console.WriteLine(greet);

        }

        static void SayHello (string greet, string name)
        {
            greet += name;
        }
    }
}
