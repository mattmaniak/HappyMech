using UnityEngine;

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

        public int CurrentSectionIndex { get; internal set; } = 0;

        float horizontalOffset
        {
            get
            {
                return Random.Range(minHorizontalSeparationOffset, maxHorizontalSeparationOffset);
            }
        }

        float verticalOffset
        {
            get
            {
                return Random.Range(minVerticalSeparationOffset, maxVerticalSeparationOffset);
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

        void Start()
        {
            sections[CurrentSectionIndex].transform.position = new Vector3(horizontalOffset, verticalOffset, 0.0f);
        }

        [System.Obsolete("Temponary and CPU-heavy solution. Use events in production.")]
        void Update()
        {
            if (!sections[CurrentSectionIndex].GetComponentInChildren<SpriteRenderer>().isVisible)
            {

            }
        }
    }
}
