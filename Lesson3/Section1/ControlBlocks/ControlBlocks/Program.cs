using System;

namespace ControlBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Console.ReadLine() is var x && x == "hello")
            {
                int i = 0;
                do
                {
                    Console.WriteLine($"Current number for do while loop is {i}");
                    i++;
                } while (i <= 10);

                for (var j = 10; j > 0; j--)
                {
                    Console.WriteLine($"Current number for for loop is {j}");
                }
            }

            var z = 0;

            while (z < 10)
            {
                Console.WriteLine($"Current number while loop is {z}");
                ++z;
            }

            var myArray = new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 };

            foreach (var i in myArray)
            {
                switch (i.ToString())
                {
                    case "1":
                        Console.WriteLine("i is 1");
                        break;
                    default:

                        Console.WriteLine("i is not 1");
                        break;
                }
            }
        }
    }
}
