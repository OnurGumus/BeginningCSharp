using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine(s);
            Console.Beep();
            Console.ReadKey();

        }
    }
}
