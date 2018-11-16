using System;

namespace Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = int.MaxValue;
            var max1 = max + 1;
            Console.WriteLine(max1);
            checked
            {
                var max2 = max + 1;
                Console.WriteLine(max2);

            }
        }
    }
}
