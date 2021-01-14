using System;
using UnityEngine;
using UnityEngine.UI;

namespace GUI.HUD
{
    [RequireComponent(typeof(Text))]
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField]
        Gameplay.DataContainer gameplayDataContainer;

        Text scoreContents;

        public void Awake()
        {
            scoreContents = GetComponent<Text>();
        }

        void Update()
        {
            string currentScoreNumber = gameplayDataContainer.ScoreNumber.ToString();
            if (scoreContents.text != currentScoreNumber)
            {
                scoreContents.text = currentScoreNumber;
            }
        }
    }
}
