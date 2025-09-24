using System;
using PlanATest.Game.Game.Data;
using PlanATest.Game.Turns.Interfaces;
using Zenject;

namespace PlanATest.Game.Turns.Manager
{
    public class TurnsManager : IInitializable, ITurnsManager
    {
        public int CurrentTurn { get; private set; }
        public Action<int> OnTurnsChanged { get; set; }
        public Action OnNoTurnsLeft { get; set; }

        [Inject] private LevelData _levelData;

        public void Initialize()
        {
            CurrentTurn = _levelData.Turns;
            OnTurnsChanged?.Invoke(CurrentTurn);
        }

        public void AddTurn()
        {
            CurrentTurn++;
            OnTurnsChanged?.Invoke(CurrentTurn);
        }

        public void RemoveTurn()
        {
            CurrentTurn--;
            OnTurnsChanged?.Invoke(CurrentTurn);
            if (CurrentTurn == 0)
            {
                OnNoTurnsLeft?.Invoke();
            }
        }

        public void Reset()
        {
            CurrentTurn = 0;
            OnTurnsChanged?.Invoke(CurrentTurn);
        }
    }
}
