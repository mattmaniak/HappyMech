using UnityEngine;
using UnityEngine.Assertions;

namespace Pipes
{
    public class InfiniteGenerator : MonoBehaviour
    {
        const float minHorizontalSeparationOffset = 5.0f;
        const float maxHorizontalSeparationOffset = 10f;
        const float minVerticalOffset = -3.0f;
        const float maxVerticalOffset = 3.0f;
        readonly Vector3 graveyardPosition = new Vector3(-100.0f, 0.0f, 0.0f);

        [SerializeField]
        GameObject[] sections;

        [SerializeField]
        Transform player;

        int currentSectionIndex;

        float HorizontalOffset
        {
            get
            {
                Assert.IsTrue(player.transform.position.x <= float.MaxValue);
                return Random.Range(minHorizontalSeparationOffset, maxHorizontalSeparationOffset) + player.transform.position.x;
            }
        }

        float VerticalOffset
        {
            get
            {
                return Random.Range(minVerticalOffset, maxVerticalOffset);
            }
        }

        int NextSectionIndex
        {
            get
            {
                return Random.Range(Random.Range(0, currentSectionIndex), Random.Range(currentSectionIndex + 1, sections.Length));
            }
        }

        void Awake()
        {
            SentAllToGraveyard();
            MoveCurrentSection();
        }

        [System.Obsolete("Temponary and CPU-heavy solution. Use events in production.")]
        void Update()
        {
            if (!sections[currentSectionIndex].GetComponentInChildren<SpriteRenderer>().isVisible)
            {
                MoveCurrentSection();
            }
        }

        public void MoveCurrentSection()
        {
            SentAllToGraveyard();
            currentSectionIndex = NextSectionIndex;
            sections[currentSectionIndex].transform.position = new Vector3(HorizontalOffset, VerticalOffset, 0.0f);
        }

        void SentAllToGraveyard()
        {
            foreach (var section in sections)
            {
                if (!section.activeInHierarchy)
                {
                    section.SetActive(true);
                }
                section.transform.position = graveyardPosition;
            }
        }
    }
}
