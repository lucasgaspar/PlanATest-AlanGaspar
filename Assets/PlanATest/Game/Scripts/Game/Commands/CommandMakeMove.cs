using PlanATest.Game.Score.Interfaces;
using PlanATest.Game.Turns.Interfaces;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Game.Commands
{
    public class CommandMakeMove : MonoBehaviour
    {
        [Inject] private ITurnsManager _turnsManager;
        [Inject] private IScoreManager _scoreManager;

        public void Execute()
        {
            _turnsManager.RemoveTurn();
            _scoreManager.AddScore(10);
        }
    }
}
