using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using PlanATest.Game.Board.Data;
using PlanATest.Game.Board.Interfaces;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Board.View
{
    public class BoardView : MonoBehaviour
    {
        private Dictionary<Vector2Int, BoardElementView> _elements = new();

        [Inject] private IBoardManager _grid;
        [Inject] private BoardElementView.Pool _boardElementViewPool;

        public bool IsMovingPieces { get; private set; }

        private void Start()
        {
            SetupBoard();
            _grid.OnBoardChanged += OnBoardChanged;
        }

        private void OnDestroy()
        {
            _grid.OnBoardChanged -= OnBoardChanged;
        }

        private void SetupBoard()
        {
            Cell[,] cells = _grid.GetAllCells();
            int width = _grid.GetWidth();
            int height = _grid.GetHeight();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var elementData = cells[x, y].ElementData;
                    var position = new Vector2Int(x, y);
                    var gridElementView = _boardElementViewPool.Spawn(elementData, position);
                    gridElementView.transform.SetParent(transform);
                    _elements[position] = gridElementView;
                    gridElementView.SetBoardView(this);
                }
            }
        }

        private async void OnBoardChanged(BoardChangeData boardChangeData)
        {
            IsMovingPieces = true;

            foreach (var elementToDestroy in boardChangeData.ElementsToDestroy)
            {
                _elements[elementToDestroy.Position].Destroy();
            }

            await UniTask.WaitForSeconds(0.5f);

            foreach (var elementToMove in boardChangeData.ElementsToMove)
            {
                var gridElementView = _elements[elementToMove.From];
                gridElementView.MoveToPosition(elementToMove.To);
                _elements.Remove(elementToMove.From);
                _elements[elementToMove.To] = gridElementView;
            }

            if (boardChangeData.ElementsToMove.Count > 0)
            {
                await UniTask.WaitForSeconds(0.5f);
            }

            foreach (var elementToSpawn in boardChangeData.ElementsToSpawn)
            {
                var gridElementView = _boardElementViewPool.Spawn(elementToSpawn.ElementData, elementToSpawn.Position);
                gridElementView.transform.SetParent(transform);
                _elements[elementToSpawn.Position] = gridElementView;
                gridElementView.SetBoardView(this);
            }

            IsMovingPieces = false;
        }
    }
}
