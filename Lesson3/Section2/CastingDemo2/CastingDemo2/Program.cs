using System;
using System.Globalization;

namespace CastingDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            int? j = null;
            //implicit casting
            j = i;
            Console.WriteLine(j);
            j = null;
            //  throws an exception
            //i = (int)j;
            Console.WriteLine(i);
            //implicit conversion
            Currency c = 5;
            int value = (int) c;
            //explicit conversion
            Console.WriteLine(value);

            //string representation
            var s = c.Value.ToString();

            //forced parsing;
            var v = int.Parse(s);

            s = Convert.ToString(v);

            v = Convert.ToInt32(s);
            if(int.TryParse(s, out var s2))
            {
                Console.WriteLine(s2);
            }
        }
    }


    class Currency
    {
        public int Value { get; }
        public Currency(int value)
        {
            this.Value = value;
        }

        public static implicit operator Currency(int i)
            => new Currency(i);

        public static explicit operator int(Currency c)
            => c.Value
    }
}
