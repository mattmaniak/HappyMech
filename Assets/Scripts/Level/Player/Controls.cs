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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.IsGainingAltitude = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                movement.IsGainingAltitude = false;  
            }
        }

        void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        movement.IsGainingAltitude = true;  
                        break;

                    case TouchPhase.Ended:
                        movement.IsGainingAltitude = false;  
                        break;

                    default:
                        break;
                }
            }            // foreach(Touch touch in Input.touches)
            // {
            //     if (touch.phase == TouchPhase.Stationary)
            //     {
            //         movement.IsGainingAltitude = true;                        
            //         break;
            //     }
            // }
        }
    }
}
