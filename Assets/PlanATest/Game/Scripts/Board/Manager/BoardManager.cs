using PlanATest.Game.Board.Data;
using PlanATest.Game.Board.Interfaces;
using PlanATest.Game.Game.Data;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Board.Manager
{
    public class BoardManager : IInitializable, IBoardManager
    {
        private Cell[,] _cells;

        [Inject] private LevelData _levelData;

        public void Initialize()
        {
            int Width = _levelData.Width;
            int Height = _levelData.Height;

            _cells = new Cell[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var elementData = GetRandomElement(_levelData);
                    _cells[x, y] = new Cell(elementData, new Vector2Int(x, y));
                }
            }
        }

        public int GetWidth()
        {
            return _levelData.Width;
        }

        public int GetHeight()
        {
            return _levelData.Height;
        }

        public Cell[,] GetAllCells()
        {
            return _cells;
        }

        private BoardElementData GetRandomElement(LevelData levelData)
        {
            return levelData.Elements[UnityEngine.Random.Range(0, levelData.Elements.Count)].Data;
        }
    }
}
