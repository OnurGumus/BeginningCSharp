using System;
using System.IO;
#nullable enable
namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var length2 = Length(null);
            }
#nullable disable
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

        static int Length(string? s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            return s.Length;
        }
    }
}
