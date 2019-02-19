using System;

namespace FixTheBug
{

    class Foo
    {
        public int X { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var greet = "Hello ";
            var foo = new Foo() { X = 3 };
           
            SayHello(ref greet, "Onur", foo);
            Console.WriteLine(foo.X);

        }

        static void SayHello (ref string greet, string name, Foo foo)
        {
            greet += name;
            foo.X = 6;
        }
    }
}
