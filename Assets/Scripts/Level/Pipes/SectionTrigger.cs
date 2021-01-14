using System;
using UnityEngine;

namespace Level.Pipes
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SectionTrigger : MonoBehaviour
    {
        [SerializeField]
        Gameplay.Controller gameplayController;

        [SerializeField]
        InfiniteGenerator generator;

        [SerializeField]
        int index;

        void OnBecameInvisible()
        {
            generator.MoveCurrentSection(index);
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            gameplayController.IncrementScoreNumber();
        }
    }
}
