using UnityEngine;

namespace Pipes
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class PipeCollisionHandler : MonoBehaviour
    {
        [SerializeField]
        GameplayController gameplayController;

        void OnCollisionEnter2D(Collision2D collision)
        {
            gameplayController.GameOver();
        }
    }
}
