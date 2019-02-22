using System;
//This is a namespace

namespace KeywordsClasses
{
    class Program
    {
        //This is a method
        static void Main(string[] args)
        {
            // This is a statement.
            Console.WriteLine("Hello World!");
        }
    }

    //This is a comment.
    //Below is a class

    public class Test1
    {
        //This is a static integer field
        public Test1(int x)
        {
            this.X = x;
        }
        internal protected int X { get; } 
        
        //This is a public string property

        public string S { get; private set; }
    }
}
