using PlanATest.Game.Turns.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace PlanATest.Game.Turns.Views
{
    public class TurnsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _turnsText;

        [Inject] private ITurnsManager _turnsManager;

        private void Start()
        {
            _turnsManager.OnTurnsChanged += UpdateTurnsDisplay;
            UpdateTurnsDisplay(_turnsManager.CurrentTurn);
        }

        private void OnDestroy()
        {
            _turnsManager.OnTurnsChanged -= UpdateTurnsDisplay;
        }

        private void UpdateTurnsDisplay(int newTurns)
        {
            _turnsText.SetText(newTurns.ToString());
        }
    }
}
