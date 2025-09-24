using System;
using PlanATest.Game.Score.Interfaces;

namespace PlanATest.Game.Score.Manager
{
    public class ScoreManager : IScoreManager
    {
        public int CurrentScore { get; private set; }

        public Action<int> OnScoreChanged { get; set; }

        public void AddScore(int amount)
        {
            CurrentScore += amount;
            OnScoreChanged?.Invoke(CurrentScore);
        }

        public void Reset()
        {
            CurrentScore = 0;
            OnScoreChanged?.Invoke(CurrentScore);
        }
    }
}
