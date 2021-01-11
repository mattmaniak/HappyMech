using UnityEngine;
using UnityEngine.Assertions;

namespace Pipes
{
    public class Renderer : MonoBehaviour
    {
        const float minHorizontalSeparationOffset = 5.0f;
        const float maxHorizontalSeparationOffset = 10.0f;
        const float minVerticalSeparationOffset = -2.0f;
        const float maxVerticalSeparationOffset = 2.0f;
        readonly Vector3 graveyardPosition = new Vector3(-100.0f, 0.0f, 0.0f);

        [SerializeField]
        GameObject[] sections;

        [SerializeField]
        Transform playerPosition;

        int currentSectionIndex;

        float HorizontalOffset
        {
            get
            {
                Assert.IsTrue(playerPosition.transform.position.x <= float.MaxValue);
                return Random.Range(minHorizontalSeparationOffset, maxHorizontalSeparationOffset) + playerPosition.transform.position.x;
            }
        }

        float VerticalOffset
        {
            get
            {
                return Random.Range(minVerticalSeparationOffset, maxVerticalSeparationOffset);
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
            foreach (var section in sections)
            {
                section.transform.position = graveyardPosition;
                section.SetActive(true);
            }
        }

        [System.Obsolete("Temponary and CPU-heavy solution. Use events in production.")]
        void Update()
        {
            if (!sections[currentSectionIndex].GetComponentInChildren<SpriteRenderer>().isVisible)
            {
                MoveCurrentSection();
            }
        }

        void MoveCurrentSection()
        {
            currentSectionIndex = NextSectionIndex;
            sections[currentSectionIndex].transform.position = new Vector3(HorizontalOffset, VerticalOffset, 0.0f);
        }
    }
}
