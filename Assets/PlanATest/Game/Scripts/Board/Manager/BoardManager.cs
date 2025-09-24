using System;
using System.Collections.Generic;
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

        public Action<BoardChangeData> OnBoardChanged { get; set; }

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

        public void ClickedElement(Vector2Int position)
        {
            var elementsToDestroy = GetElementsToDestroy(position);
            if (elementsToDestroy.Count == 0)
            {
                return;
            }

            DestroyElements(elementsToDestroy);
            var elementToMove = GetElementsToMove();
            MoveElements(elementToMove);
            var elementsToSpawn = GetElementsToSpawn();
            SpawnElements(elementsToSpawn);

            var boardChangeData = new BoardChangeData(elementsToDestroy, elementToMove, elementsToSpawn);
            OnBoardChanged?.Invoke(boardChangeData);
        }

        private List<ElementToDestroy> GetElementsToDestroy(Vector2Int position, List<ElementToDestroy> elements = null, BoardElementData elementType = null)
        {
            elements ??= new List<ElementToDestroy>();

            if (position.x < 0 || position.x >= _levelData.Width || position.y < 0 || position.y >= _levelData.Height)
            {
                return elements;
            }

            var cell = _cells[position.x, position.y];
            if (cell.IsEmptyCell() || elements.Exists(e => e.Position == position))
            {
                return elements;
            }

            if (elements.Count > 0 && cell.ElementData != elementType)
            {
                return elements;
            }

            elements.Add(new ElementToDestroy(cell.Position));
            GetElementsToDestroy(position + Vector2Int.up, elements, cell.ElementData);
            GetElementsToDestroy(position + Vector2Int.down, elements, cell.ElementData);
            GetElementsToDestroy(position + Vector2Int.left, elements, cell.ElementData);
            GetElementsToDestroy(position + Vector2Int.right, elements, cell.ElementData);
            return elements;
        }

        private void DestroyElements(List<ElementToDestroy> elementsToDestroy)
        {
            foreach (var element in elementsToDestroy)
            {
                _cells[element.Position.x, element.Position.y].ClearCell();
            }
        }

        private List<ElementToMove> GetElementsToMove()
        {
            List<ElementToMove> elementsToMove = new();

            for (int x = 0; x < _levelData.Width; x++)
            {
                int emptyCount = 0;
                for (int y = 0; y < _levelData.Height; y++)
                {
                    if (_cells[x, y].IsEmptyCell())
                    {
                        emptyCount++;
                    }
                    else if (emptyCount > 0)
                    {
                        var from = new Vector2Int(x, y);
                        var to = new Vector2Int(x, y - emptyCount);
                        elementsToMove.Add(new ElementToMove(from, to));
                    }
                }
            }

            return elementsToMove;
        }

        private void MoveElements(List<ElementToMove> elementsToMove)
        {
            foreach (var element in elementsToMove)
            {
                var fromCell = _cells[element.From.x, element.From.y];
                var toCell = _cells[element.To.x, element.To.y];
                toCell.ElementData = fromCell.ElementData;
                fromCell.ClearCell();
            }
        }

        private List<ElementToSpawn> GetElementsToSpawn()
        {
            List<ElementToSpawn> elementsToSpawn = new();

            for (int x = 0; x < _levelData.Width; x++)
            {
                int emptyCount = 0;
                for (int y = 0; y < _levelData.Height; y++)
                {
                    if (_cells[x, y].IsEmptyCell())
                    {
                        emptyCount++;
                    }
                }

                for (int i = 0; i < emptyCount; i++)
                {
                    var position = new Vector2Int(x, _levelData.Height - emptyCount + i);
                    var elementData = GetRandomElement(_levelData);
                    elementsToSpawn.Add(new ElementToSpawn(position, elementData));
                }
            }

            return elementsToSpawn;
        }

        private void SpawnElements(List<ElementToSpawn> elementsToSpawn)
        {
            foreach (var element in elementsToSpawn)
            {
                var cell = _cells[element.Position.x, element.Position.y];
                cell.ElementData = element.ElementData;
            }
        }
    }
}
