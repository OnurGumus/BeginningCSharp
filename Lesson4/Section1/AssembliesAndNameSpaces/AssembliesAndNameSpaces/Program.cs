using System;
using ClassLibrary1;
namespace AssembliesAndNameSpaces
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(ClassLibrary1.Class1));
            Console.WriteLine(typeof(Class1));
        }
    }

    namespace Another
    {
        class Program2
        {

        }
    }
}
