using System;
using PlanATest.Game.Board.Data;
using UnityEngine;

namespace PlanATest.Game.Board.Interfaces
{
    public interface IBoardManager
    {
        Cell[,] GetAllCells();
        int GetWidth();
        int GetHeight();
        void ClickedElement(Vector2Int position);
        Action<BoardChangeData> OnBoardChanged { get; set; }
    }
}
