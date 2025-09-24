using PlanATest.Game.Board.Data;

namespace PlanATest.Game.Board.Interfaces
{
    public interface IBoardManager
    {
        Cell[,] GetAllCells();
        int GetWidth();
        int GetHeight();
    }
}
