using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Linq;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var world = "world";
            var helloWorld = hello + world;
            helloWorld = $"{hello} {world}";
            var builder = new StringBuilder();
            builder.Append("d");
            var s = string.Format("One = {0}", 1);

            var escape = "\n\r\t\"" + Environment.NewLine;
            Console.WriteLine(escape);
            var nonescape = @"\n\r\t""";
            Console.WriteLine(nonescape);
            var nonEscape2 = @"Hello
World";
            Console.WriteLine(nonEscape2);
            var myDouble = "5,4";
            var turkishCulture = CultureInfo.GetCultureInfo("tr-TR");
            Console.WriteLine(Double.Parse(myDouble, CultureInfo.InvariantCulture));
            Console.WriteLine(Double.Parse(myDouble, turkishCulture));

            var description = "Description";

            Console.WriteLine(description.ToUpper() == "DESCRIPTION");
            Console.WriteLine(description.ToUpper().Equals("DESCRIPTION"));
            Console.WriteLine(Object.ReferenceEquals(description.ToUpper(), "DESCRIPTION"));

            Thread.CurrentThread.CurrentCulture = turkishCulture;

            Console.WriteLine(description.ToUpper() == "DESCRIPTION");
            Console.WriteLine(description.ToUpperInvariant() == "DESCRIPTION");

            Console.WriteLine(description.Equals("DESCRIPTION", StringComparison.OrdinalIgnoreCase));

            var dt = "05/01/2012";
            Console.WriteLine(DateTime.Parse(dt).ToLongDateString());
            Console.WriteLine(DateTime.Parse(dt).ToString("dddd, MMMM dd yyyy"));
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(DateTime.Parse(dt).ToString("dddd, MMMM dd yyyy"));
            Console.WriteLine(DateTime.ParseExact(dt, "MM/dd/yyyy", turkishCulture).ToString("dddd, MMMM dd yyyy"));

            var fruits = "Apple,Orange,Banana".Split(",");

            var fruitsContainingA =
                from fruit in fruits
                from fruitLetter in fruit
                where fruitLetter == 'a'
                select fruit;

            foreach(var fruit in fruitsContainingA)
            {
                Console.WriteLine(fruit);
            }


            var original = String.Join(",", fruits);
            Console.WriteLine(original);



            Console.WriteLine(11.ToString("X"));
            Console.WriteLine(11.ToString("C"));



        }
    }
}
