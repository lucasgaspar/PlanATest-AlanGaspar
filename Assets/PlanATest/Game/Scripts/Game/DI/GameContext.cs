using PlanATest.Game.Game.Data;
using PlanATest.Game.Game.ScriptableObjects;
using PlanATest.Game.Score.Manager;
using PlanATest.Game.Turns.Manager;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Game.Manager
{
    public class GameContext : MonoInstaller
    {
        [SerializeField] private LevelDataSO _levelDataSO;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInterfacesTo<ScoreManager>().AsSingle();
            Container.BindInterfacesTo<TurnsManager>().AsSingle();
            Container.Bind<LevelData>().FromInstance(_levelDataSO.Data).AsSingle();
        }
    }
}
