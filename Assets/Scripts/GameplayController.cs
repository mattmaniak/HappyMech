using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    GUI.HUD.ScoreCounter scoreCounter;

    int scoreNumber = 0;

    public void IncrementScoreNumber()
    {
        Assert.IsTrue(scoreNumber < int.MaxValue);
        scoreNumber++;
        scoreCounter.ScoreContents = scoreNumber.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadSceneAsync("GameOverMenu");
    }
}
