using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        DataContainer data;

        [SerializeField]
        GUI.HUD.ScoreCounter scoreCounter;

        void Awake()
        {
            data.Reset();
        }

        public void IncrementScoreNumber()
        {
            data.IncrementScoreNumber();
        }

        public void GameOver()
        {
            SceneManager.LoadSceneAsync("GameOverMenu");
        }
    }
}
