using System.Collections.Generic;
using UnityEngine;

namespace PlanATest.Game.Board.Data
{
    public class BoardChangeData
    {
        public List<ElementToDestroy> ElementsToDestroy { get; private set; } = new();
        public List<ElementToMove> ElementsToMove { get; private set; } = new();
        public List<ElementToSpawn> ElementsToSpawn { get; private set; } = new();

        public BoardChangeData(List<ElementToDestroy> elementsToDestroy, List<ElementToMove> elementsToMove, List<ElementToSpawn> elementsToSpawn)
        {
            ElementsToDestroy = elementsToDestroy;
            ElementsToMove = elementsToMove;
            ElementsToSpawn = elementsToSpawn;
        }
    }

    public class ElementToDestroy
    {
        public Vector2Int Position { get; private set; }

        public ElementToDestroy(Vector2Int position)
        {
            Position = position;
        }
    }

    public class ElementToMove
    {
        public Vector2Int From { get; private set; }
        public Vector2Int To { get; private set; }

        public ElementToMove(Vector2Int from, Vector2Int to)
        {
            From = from;
            To = to;
        }
    }

    public class ElementToSpawn
    {
        public Vector2Int Position { get; private set; }
        public BoardElementData ElementData { get; private set; }

        public ElementToSpawn(Vector2Int position, BoardElementData elementData)
        {
            Position = position;
            ElementData = elementData;
        }
    }
}
