using System;
using UnityEngine;

namespace Pipes
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SectionTrigger : MonoBehaviour
    {
        [SerializeField]
        Gameplay.Controller gameplayController;

        [SerializeField]
        InfiniteGenerator generator;

        void OnBecameInvisible()
        {
            generator.MoveCurrentSection();
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            gameplayController.IncrementScoreNumber();
        }
    }
}
