using System;
using UnityEngine;

namespace Pipes
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Section : MonoBehaviour
    {
        [SerializeField]
        InfiniteGenerator generator;

        void OnBecameInvisible()
        {
            generator.MoveCurrentSection();
        }
    }
}
