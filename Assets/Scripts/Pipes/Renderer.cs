using System;
using UnityEngine;

namespace Pipes
{
    public class Renderer : MonoBehaviour
    {
        readonly Vector3 graveyardPosition = new Vector3(-100.0f, 0.0f, 0.0f);

        float minHorizontalSeparationOffset = 5.0f;
        float maxHorizontalSeparationOffset = 10.0f;
        int currentSectionIndex = 0;

        [SerializeField]
        GameObject[] sections;

        void Awake()
        {
            foreach (var section in sections)
            {
                section.transform.position = graveyardPosition;
                section.SetActive(true);
            }
        }

        [Obsolete("Temponary and CPU-heavy solution. Use events in production.")]
        void Update()
        {
            if (!sections[currentSectionIndex].GetComponentInChildren<SpriteRenderer>().isVisible)
            {

            }
        }
    }
}
