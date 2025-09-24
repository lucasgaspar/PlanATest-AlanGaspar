using PlanATest.Game.Game.Data;
using UnityEngine;

namespace PlanATest.Game.Game.ScriptableObjects
{
    [CreateAssetMenu(menuName = "PlanA/LevelDataSO")]
    public class LevelDataSO : ScriptableObject
    {
        [field: SerializeField] public LevelData Data { get; private set; }
    }
}
