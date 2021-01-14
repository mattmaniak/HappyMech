using UnityEngine;

namespace Level.Player
{
    public class Movement : MonoBehaviour
    {
        public const float maxVelocity = 5.0f;

        [SerializeField]
        float horizontalSpeed;

        void FixedUpdate()
        {
            transform.Translate(horizontalSpeed * Vector3.right * Time.fixedDeltaTime);
        }
    }
}
