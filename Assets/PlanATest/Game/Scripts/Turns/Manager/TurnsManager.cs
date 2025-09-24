using System;
using PlanATest.Game.Game.Data;
using PlanATest.Game.Game.Interfaces;
using PlanATest.Game.Turns.Interfaces;
using Zenject;

namespace PlanATest.Game.Turns.Manager
{
    public class TurnsManager : IInitializable, ITurnsManager
    {
        public Action<int> OnTurnsChanged { get; set; }
        public Action OnNoTurnsLeft { get; set; }
        public int CurrentTurns { get; private set; }

        [Inject] private LevelData _levelData;
        [Inject] private IGameManager _gameManager;

        public void Initialize()
        {
            CurrentTurns = _levelData.Turns;
            OnTurnsChanged?.Invoke(CurrentTurns);
        }

        public void AddTurn()
        {
            CurrentTurns++;
            OnTurnsChanged?.Invoke(CurrentTurns);
        }

        public void RemoveTurn()
        {
            if (CurrentTurns > 0)
            {
                CurrentTurns--;
                OnTurnsChanged?.Invoke(CurrentTurns);
            }
            else
            {
                OnNoTurnsLeft?.Invoke();
            }
        }

        public void Reset()
        {
            CurrentTurns = 0;
            OnTurnsChanged?.Invoke(CurrentTurns);
        }
    }
}
