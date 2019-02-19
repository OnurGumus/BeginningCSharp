using System;
using System.Collections.Generic;
using System.Linq;

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

            var lettersBetweenAtoD = AlphabetSubset3('a', 'd');
            foreach (var letter in lettersBetweenAtoD)
            {
                Console.WriteLine(letter);
            }
          
            var sum = 0;

            var values = new object[] { 0, 1, new int[] { 1, 2, 3 }, Array.Empty<int>(), new object[0], DateTime.Now, null };
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<int> subList when subList.Any():
                        sum += subList.Sum();
                        break;
                    case object[] subList2:
                        break;
                    case null:
                        break;
                    case object o:
                        break;
                    //    case var ax:

                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
        }
        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }
    }
}
