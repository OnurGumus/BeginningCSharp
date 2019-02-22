using Lab4.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Game
    {
        readonly int pickedNumber;

        int guessCount;
        readonly string playerName;

        public Game(string playerName)
        {
            this.playerName = playerName;
            this.pickedNumber = new Random().Next(1, 101);
        }
        public async Task<GameScore> GetHighScore()
        {
            var httpClient = new HttpClient();
            var data = await httpClient.GetAsync("http://10.0.2.2:5000/api/GameScore");

            return await data.Content.ReadAsAsync<GameScore>();
        }

        public async Task SaveHighScore()
        {
            var gameScore = new GameScore { BestAttempt = guessCount, PlayerName = this.playerName };
            var httpClient = new HttpClient();
            await httpClient.PostAsJsonAsync("http://10.0.2.2:5000/api/GameScore", gameScore);
        }


        public async Task<string> MakeGuess(int guess)
        {
            guessCount++;
            if (guess < pickedNumber)
            {
                return "Too small";
            }
            if (guess > pickedNumber)
            {
                return "Too big";
            }
            await SaveHighScore();
            return $"Congrats! You have found in {guessCount} attempts!";


        }

    }
}