using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace GUI.HUD
{
    [RequireComponent(typeof(Text))]
    public class ScoreCounter : MonoBehaviour
    {
        int scoreNumber = 0;
        Text scoreContents;

        public void Awake()
        {
            scoreContents = GetComponent<Text>();
        }

        public void IncrementScoreNumber()
        {
            Assert.IsTrue(scoreNumber < int.MaxValue);
            scoreNumber++;
            scoreContents.text = scoreNumber.ToString();
        }
    }
}
