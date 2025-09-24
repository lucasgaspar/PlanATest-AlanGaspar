using PlanATest.Game.Score.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Score.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        [Inject] private IScoreManager _scoreManager;

        private void Start()
        {
            _scoreManager.OnScoreChanged += UpdateScoreDisplay;
            UpdateScoreDisplay(_scoreManager.CurrentScore);
        }

        private void OnDestroy()
        {
            _scoreManager.OnScoreChanged -= UpdateScoreDisplay;
        }

        private void UpdateScoreDisplay(int newScore)
        {
            _scoreText.text = $"{newScore:0.000}";
        }
    }
}
