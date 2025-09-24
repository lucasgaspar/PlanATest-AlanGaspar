using System;
using Cysharp.Threading.Tasks;
using PlanATest.Game.Turns.Interfaces;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Game.Manager
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;

        [Inject] private ITurnsManager _turnsManager;

        private void Awake()
        {
            _turnsManager.OnNoTurnsLeft += ShowGameOver;
        }

        private void OnDestroy()
        {
            _turnsManager.OnNoTurnsLeft -= ShowGameOver;
        }

        private async void ShowGameOver()
        {
            await UniTask.WaitForSeconds(1.25f);
            _gameOverPanel.SetActive(true);
        }
    }
}
