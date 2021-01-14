using UnityEngine;


namespace Level.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [Range(0.0f, 5.0f)]
        [SerializeField]
        float maxHorizontalSpeed;

        [Range(0.0f, 10.0f)]
        [SerializeField]
        float maxVerticalSpeed;

        Rigidbody2D rigidbody;

        internal bool IsGainingAltitude { get; set; } = false;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (IsGainingAltitude)
            {
                GainAltitude();
            }
            MoveHorizontally();
            ClampVerticalSpeed();
        }

        void GainAltitude()
        {
            rigidbody.AddForce(Vector2.up * 2.0f * maxVerticalSpeed, ForceMode2D.Impulse);
        }

        void ClampVerticalSpeed()
        {
            if (rigidbody.velocity.y > maxVerticalSpeed)
            {
                rigidbody.velocity = new Vector2(maxHorizontalSpeed, maxVerticalSpeed);
            }
            else if (rigidbody.velocity.y < -maxVerticalSpeed)
            {
                rigidbody.velocity = new Vector2(maxHorizontalSpeed, -maxVerticalSpeed);
            }
        }

        void MoveHorizontally()
        {
            rigidbody.AddForce(maxHorizontalSpeed * Vector2.right);
        }
    }
}
