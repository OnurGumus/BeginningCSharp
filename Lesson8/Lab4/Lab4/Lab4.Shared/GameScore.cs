using System;

namespace Lab4.Shared
{
    public class GameScore
    {
        public string PlayerName { get; set; }
        public int BestAttempt { get; set; }

        public override string ToString()
        {
            return $"Player {PlayerName} made the highest score as : {BestAttempt} attempts!";
        }
    }
}
