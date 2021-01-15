using UnityEngine;
using UnityEngine.Assertions;

namespace Level.Pipes
{
    public class InfiniteGenerator : MonoBehaviour
    {
        readonly Vector2 graveyardPosition = new Vector2(-100.0f, 0.0f);

        [Range(0.0f, 5.0f)]
        [SerializeField]
        float minHorizontalSeparation;

        [Range(5.0f, 10.0f)]
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

        float HorizontalOffset
        {
            get
            {
                return Random.Range(minHorizontalSeparation, maxHorizontalSeparation);
            }
        }

        float LastPipeSectionX
        {
            get
            {
                float lastX = 0;
                float sectionX = 0;

                foreach (var section in sections)
                {
                    sectionX = section.transform.position.x;
                    lastX = (sectionX > lastX) ? sectionX : lastX;
                }
                Assert.IsTrue(lastX <= float.MaxValue);
                return lastX;
            }
        }

        float VerticalOffset
        {
            get
            {
                return Random.Range(minVerticalOffset, maxVerticalOffset);
            }
        }

        void Awake()
        {
            SentAllToGraveyard();
            for (int x = 0; x < sections.Length; x++)
            {
                sections[x].transform.position = new Vector2(player.transform.position.x + (HorizontalOffset * (x + 1)), VerticalOffset);
            }
        }

        public void MoveCurrentSection(int index)
        {
            sections[index].transform.position = new Vector2(LastPipeSectionX + HorizontalOffset, VerticalOffset);
        }

        void SentAllToGraveyard()
        {
            foreach (var section in sections)
            {
                if (!section.activeInHierarchy)
                {
                    section.SetActive(true);
                }
                else if (!section.GetComponent<SpriteRenderer>().isVisible)
                {
                    section.transform.position = graveyardPosition;
                }
            }
        }
    }
}
