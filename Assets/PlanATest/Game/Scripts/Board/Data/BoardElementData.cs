using UnityEngine;

namespace PlanATest.Game.Board.Data
{
    [System.Serializable]
    public class BoardElementData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
