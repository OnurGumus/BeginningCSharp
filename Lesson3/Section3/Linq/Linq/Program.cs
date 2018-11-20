using System;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(1, 100).ToList();

            //even numbers

            var evenNumbers = items.Where(x => x % 2 == 0).ToList();

            Func<int, bool> oddFilter = x => x % 2 == 1;

            var oddNumbers = items.Where(oddFilter).ToList();

            var sumOfNumbersDivisbleByFive =
                (from x in items
                 where x % 5 == 0
                 let i = x.ToString().Length
                 select i).Sum();


            var firstNumberDivisbleBy7 = items.First(i => i % 7 == 0);
            var lastNumberDivisbleBy7 = items.Last(i => i % 7 == 0);

            int firstNumberDivisbleby101 = items.FirstOrDefault(x => x % 101 == 0);


            var itemsQ = items.AsQueryable();

            var multiplicationOfOddnumbers = itemsQ.Where(x => x % 2 == 1).Aggregate(1, (x, y) => x * y);



        }
    }
}
