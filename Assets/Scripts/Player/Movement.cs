using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        float horizontalSpeed;

        void FixedUpdate()
        {
            transform.Translate(horizontalSpeed * Vector3.forward * Time.fixedDeltaTime);
        }
    }
}
