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

        private void Start()
        {
            SetupBoard();
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
                }
            }
        }
    }
}
