using System;

namespace CastingDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Derived();

            Base b = d;
            d = (Derived)b;
            I i = d;
            b = (Base)i;
            d = b as Derived;
            if(b is Derived d2)
            {
                //use d2
            }


            int j = 5;
            //boxing
            object o = j;
            //will fail
            //j = (int)(long)o;
            //unboxing
            j = (int)o;
            //

        }

        static object StructCreator()
        {
            var s = new ComplicatedStruct();
            return (object)s;
        }

    }

    struct ComplicatedStruct
    {
        //lots of members
    }

    interface I
    {

    }
    class Base : I
    {

    }

    class Derived : Base
    {

    }
}
