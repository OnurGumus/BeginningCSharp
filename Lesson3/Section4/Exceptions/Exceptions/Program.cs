using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var length  = Length("Hello World!");

            try
            {
                var length2 = Length(null);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentNullException e) when (e.ParamName == "test")
            {
                Console.WriteLine(e);
            }
            catch (ArgumentNullException e) when (e.ParamName == "s")
            {
                Console.WriteLine("thrown for s");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }

        static int Length (string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            return s.Length;
        }
    }
}
