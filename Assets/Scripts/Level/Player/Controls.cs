using System;
using UnityEngine;

namespace Level.Player
{
    [RequireComponent(typeof(Movement))]
    public class Controls : MonoBehaviour
    {
        Movement movement;

        void Start()
        {
            movement = GetComponent<Movement>();
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

        void HandleKeyboardInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                movement.GainAltitude();
            }
        }

        void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        movement.GainAltitude();
                        break;

                    case TouchPhase.Ended:
                    default:
                        break;
                }
            }
        }
    }
}
