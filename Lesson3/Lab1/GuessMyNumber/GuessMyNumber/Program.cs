using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var pickedNumber = r.Next(100) + 1;

            int guessCount = 0;
            do
            {
                Console.Write("Make a guess:");
                var guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess> pickedNumber)
                {
                    Console.WriteLine("Too big!");
                }
                else if(guess < pickedNumber)
                {
                    Console.WriteLine("Too small");
                }
                else
                {
                    Console.WriteLine($"Congrats! You have found in {guessCount} attempts.");
                    break;
                }

            } while (true);
        }
    }
}
