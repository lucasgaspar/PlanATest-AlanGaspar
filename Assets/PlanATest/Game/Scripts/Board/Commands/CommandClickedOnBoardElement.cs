using PlanATest.Game.Board.Interfaces;
using PlanATest.Game.Board.View;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Board.Commands
{
    public class CommandClickedOnBoardElement : MonoBehaviour
    {
        [SerializeField] private BoardElementView _boardElementView;

        [Inject] private IBoardManager _boardManager;

        public void Execute()
        {
            _boardManager.ClickedElement(_boardElementView.GetPosition());
        }
    }
}
