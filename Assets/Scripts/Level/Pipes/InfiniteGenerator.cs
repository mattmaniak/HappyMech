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
            InitializeSections();
        }

        public void MoveInvisibleSectionFurther(int index)
        {
            sections[index].transform.position = new Vector2(LastPipeSectionX + HorizontalOffset, VerticalOffset);
        }

        void InitializeSections()
        {
            sections[0].SetActive(true);
            sections[0].transform.position = new Vector2(HorizontalOffset, VerticalOffset);

            for (int x = 1; x < sections.Length; x++)
            {
                sections[x].SetActive(true);
                sections[x].transform.position = new Vector2(LastPipeSectionX + HorizontalOffset, VerticalOffset);
            }
        }
    }
}
