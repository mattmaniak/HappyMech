using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controls : MonoBehaviour
    {
        Rigidbody2D rigidbody;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (rigidbody.velocity.y > Movement.maxVelocity)
            {
                rigidbody.velocity = new Vector2(0.0f, Movement.maxVelocity);
            }
            else if (rigidbody.velocity.y < -Movement.maxVelocity)
            {
                rigidbody.velocity = new Vector2(0.0f, -Movement.maxVelocity);
            }
        }

        /// <remarks>
        /// Not the best solution. Events would be strongly preferred, however
        /// probably there is not a solution in unity that implements it for
        /// mobile input. Eg. Rewired implements it. Note that it's a sufficient
        /// solution for in-editor handling.
        /// </remarks>
        void Update()
        {
#if UNITY_EDITOR
            HandleKeyboardInput();
#else
            HandleTouchInput();
#endif
        }

        void GainAltitude()
        {
            rigidbody.AddForce(Vector2.up * Movement.maxVelocity * 2.0f);
        }

        void HandleKeyboardInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GainAltitude();
            }
        }

        void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        GainAltitude();
                        break;

                    case TouchPhase.Ended:
                    default:
                        break;
                }
            }
        }
    }
}
