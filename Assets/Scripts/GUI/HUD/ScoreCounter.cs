using System;
using UnityEngine;
using UnityEngine.UI;

namespace GUI.HUD
{
    [RequireComponent(typeof(Text))]
    public class ScoreCounter : MonoBehaviour
    {
        Text scoreContents;

        public void Awake()
        {
            scoreContents = GetComponent<Text>();
        }

        public string ScoreContents
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    scoreContents.text = value;
                }
            }
        }
    }
}
