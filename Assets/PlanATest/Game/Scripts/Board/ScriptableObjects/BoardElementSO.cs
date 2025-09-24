using PlanATest.Game.Board.Data;
using UnityEngine;

namespace PlanATest.Game.Board.ScriptableObjects
{
    [CreateAssetMenu(menuName = "PlanA/BoardElement")]
    public class BoardElementSO : ScriptableObject
    {
        [field: SerializeField] public BoardElementData Data { get; private set; }
    }
}
