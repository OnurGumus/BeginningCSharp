using Microsoft.EntityFrameworkCore;
using Serialization;
using System;

namespace EFDemo
{
    public class GameContext : DbContext
    {
        public DbSet<GameScore> GameScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Game;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameScore>().HasKey(c => c.PlayerName);

        }
    }

    public class EFGame : Game
    {
        public override GameScore GetHighScore()
        {
            using (var db = new GameContext())
            {
                return db.GameScores.SingleOrDefaultAsync().Result;
            }
        }

        public override void SaveHighScoreIfNecessary(GameScore currentGame)
        {
            var bestGame = GetHighScore();
            if (bestGame == null || bestGame.BestAttempt > currentGame.BestAttempt)
            {
                using (var db = new GameContext())
                {
                    db.GameScores.RemoveRange(db.GameScores);
                    db.GameScores.Add(currentGame);
                    db.SaveChanges();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new EFGame();
            while (true)
            {
                game.DisplayHighScore();
                var highScore = game.Play("Onur");
                game.SaveHighScoreIfNecessary(highScore);
            }
        }
    }
}
