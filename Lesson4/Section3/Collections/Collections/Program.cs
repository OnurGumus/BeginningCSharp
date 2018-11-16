using System;
using System.Collections.Generic;

namespace Collections
{
    class MyClass<T> where T : class
    {
        public T MyProperty { get; set; }

        public T this[int x] { get { return null; } set { } }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            var arr2 = new[] { 1, 2, 3, 4, 5 };
            var arr3 = Array.CreateInstance(typeof(int), 5);
            Console.WriteLine(arr[0]);

            var list = new List<int> { 1, 2, 3, 4,5 };
            list[4] = 0;
            Console.WriteLine(list[4]);


            var set = new HashSet<string> { "Foo", "Bar", "Doo" };

            Console.WriteLine(set.Contains("F"));

            Console.WriteLine(set.Add("Foo"));


            var dictionary = new Dictionary<string, int> { { "Key1", 1 } , { "Key2", 2 } };

            dictionary.Add("Key3", 3);

            Console.WriteLine(dictionary["Key3"]);



            var linkedList = new LinkedList<string>();
            var firstNode = linkedList.AddFirst("First"); ;
            linkedList.AddAfter(firstNode, "Second");

        }
    }
}
