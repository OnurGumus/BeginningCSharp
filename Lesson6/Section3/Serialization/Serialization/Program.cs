using Newtonsoft.Json;
using System;
using System.IO;

namespace Serialization
{
    class GameScore
    {
        public string PlayerName { get; set; }
        public int BestAttempt { get; set; }

        public override string ToString()
        {
            return $"Player {PlayerName} made the highest score as : {BestAttempt} attempts!";
        }
    }

    class Game
    {
        protected const string filename = "Highscore.txt";

        public virtual void DisplayHighScore()
        {
            var highScore = this.GetHighScore();
            if (highScore == null)
            {
                Console.WriteLine("There is no high score yet!");
            }
            else
            {
                Console.WriteLine(highScore);
            }
        }

        public virtual GameScore GetHighScore()
        {

            if (!File.Exists(filename))
            {
                return null;
            }

            var content = File.ReadAllText(filename);

            using (var stream = File.OpenRead(filename))
            using (var reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<GameScore>(content);
        }
        public virtual void SaveHighScoreIfNecessary(GameScore currentGame)
        {
            var bestGame = GetHighScore();
            if (bestGame == null || bestGame.BestAttempt > currentGame.BestAttempt)
            {

                var serializer = new JsonSerializer();
                File.Delete(filename);
                using (var stream = File.OpenWrite(filename))
                using (var streamWriter = new StreamWriter(stream))
                {
                    serializer.Serialize(streamWriter, currentGame);
                }
            }

        }
        public GameScore Play(string playerName)
        {
            var r = new Random();
            var pickedNumber = r.Next(100) + 1;

            int guessCount = 0;
            do
            {
                Console.Write("Make a guess:");
                var guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess > pickedNumber)
                {
                    Console.WriteLine("Too big!");
                }
                else if (guess < pickedNumber)
                {
                    Console.WriteLine("Too small");
                }
                else
                {
                    Console.WriteLine($"Congrats! You have found in {guessCount} attempts.");
                    break;
                }

            } while (true);

            return new GameScore
            {
                PlayerName = playerName,
                BestAttempt = guessCount
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            while (true)
            {
                game.DisplayHighScore();
                var highScore = game.Play("Onur");
                game.SaveHighScoreIfNecessary(highScore);
            }
        }







    }
}
