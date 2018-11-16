using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Monitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 10000000).Reverse().ToList();

            Console.WriteLine("Total memory:" + GC.GetTotalMemory(true));
            Console.WriteLine("Total memory:" + Process.GetCurrentProcess().PrivateMemorySize64);

            var sw = Stopwatch.StartNew();
            var sorted = list.OrderBy(x => x).ToList();

            Console.WriteLine("Elapsed:" + sw.Elapsed);
            Console.WriteLine("Total memory:" + GC.GetTotalMemory(true));
            Console.WriteLine("Total memory:" + Process.GetCurrentProcess().PrivateMemorySize64);

            sw.Restart();
            list.Sort();

            Console.WriteLine("Elapsed:" + sw.Elapsed);
            Console.WriteLine("Total memory:" + GC.GetTotalMemory(true));
            Console.WriteLine("Total memory:" + Process.GetCurrentProcess().PrivateMemorySize64);

            Console.WriteLine(list.Count);

        }
    }
}
