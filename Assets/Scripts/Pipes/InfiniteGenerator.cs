using UnityEngine;
using UnityEngine.Assertions;

namespace Pipes
{
    public class InfiniteGenerator : MonoBehaviour
    {
        readonly Vector3 graveyardPosition = new Vector3(-100.0f, 0.0f, 0.0f);

        [Range(0.0f, 10.0f)]
        [SerializeField]
        float minHorizontalSeparation;

        [Range(10.0f, 20.0f)]
        [SerializeField]
        float maxHorizontalSeparation;

        [Range(-5.0f, 0.0f)]
        [SerializeField]
        float minVerticalOffset;

        [Range(0.0f, 5.0f)]
        [SerializeField]
        float maxVerticalOffset;

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
                return Random.Range(minHorizontalSeparation, maxHorizontalSeparation) + player.transform.position.x;
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
        void FixedUpdate()
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
