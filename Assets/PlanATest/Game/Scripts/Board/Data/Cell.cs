using UnityEngine;

namespace PlanATest.Game.Board.Data
{
    public class Cell
    {
        public BoardElementData ElementData { get; set; }
        public Vector2Int Position { get; set; }

        public Cell(BoardElementData elementData, Vector2Int position)
        {
            ElementData = elementData;
            Position = position;
        }

        public bool IsEmptyCell()
        {
            return ElementData == null;
        }

        public void ClearCell()
        {
            ElementData = null;
        }
    }
}
