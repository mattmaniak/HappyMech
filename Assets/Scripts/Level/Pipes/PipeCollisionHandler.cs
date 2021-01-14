using UnityEngine;

namespace Level.Pipes
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class PipeCollisionHandler : MonoBehaviour
    {
        [SerializeField]
        Gameplay.Controller gameplayController;

        void OnCollisionEnter2D(Collision2D collision)
        {
            gameplayController.GameOver();
        }
    }
}
