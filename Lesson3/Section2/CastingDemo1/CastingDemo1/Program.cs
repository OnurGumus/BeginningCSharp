using System;

namespace CastingDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            //implicit testing from smaller to larger type
            double d = i;
            Console.WriteLine(d);
            d = 5.8;
            //data lost
            i = (int)d;

            Console.WriteLine(i);
            string s = "test";
            //casting to base class
            object o = s;
            Console.WriteLine(o);
            //downcasting
            s = (string)o;
            Console.WriteLine(s);
        }
    }
}
