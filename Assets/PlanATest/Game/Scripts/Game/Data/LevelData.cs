using System.Collections.Generic;
using PlanATest.Game.Board.ScriptableObjects;
using UnityEngine;

namespace PlanATest.Game.Game.Data
{
    [System.Serializable]
    public class LevelData
    {
        [field: SerializeField] public int Height { get; private set; }
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public List<BoardElementSO> Elements { get; private set; }
        [field: SerializeField] public int Turns { get; private set; }
    }
}
