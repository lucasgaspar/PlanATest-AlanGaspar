using System;

namespace PlanATest.Game.Score.Interfaces
{
    public interface IScoreManager
    {
        int CurrentScore { get; }
        Action<int> OnScoreChanged { get; set; }
        void AddScore(int amount);
        void Reset();
    }
}
