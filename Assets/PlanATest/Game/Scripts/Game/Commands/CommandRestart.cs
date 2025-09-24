using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlanATest.Game.Game.Commands
{
    public class CommandRestart : MonoBehaviour
    {
        public void Execute()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
