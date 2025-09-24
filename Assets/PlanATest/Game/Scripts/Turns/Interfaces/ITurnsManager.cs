using System;

namespace PlanATest.Game.Turns.Interfaces
{
    public interface ITurnsManager
    {
        Action<int> OnTurnsChanged { get; set; }
        Action OnNoTurnsLeft { get; set; }

        void AddTurn();
        void RemoveTurn();
        void Reset();
    }
}
