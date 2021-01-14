using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Gameplay/DataContainer", menuName = "ScriptableObjects/Gameplay/DataContainer", order = 1)]
    public class DataContainer : ScriptableObject
    {
        const int initialValue = 0;

        public int ScoreNumber { get; private set; }

        internal void IncrementScoreNumber()
        {
            Assert.IsTrue(ScoreNumber < int.MaxValue);
            ScoreNumber++;
        }

        internal void Reset()
        {
            ScoreNumber = initialValue;
        }
    }
}
