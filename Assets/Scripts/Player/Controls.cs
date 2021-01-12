using System;
using UnityEngine;

namespace Player
{
    public class Controls : MonoBehaviour
    {
        /// <remarks>
        /// Not the best solution. Events would be strongly preferred, however
        /// probably there is not a solution in unity that implements it for
        /// mobile input. Eg. Rewired implements it. Note that it's a sufficient
        /// solution for in-editor handling.
        /// </remarks>
        void Update()
        {
#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
        }

        void HandleMouseInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                throw new NotImplementedException();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                throw new NotImplementedException();
            }
        }

        void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        throw new NotImplementedException();
                
                    case TouchPhase.Ended:
                        throw new NotImplementedException();
    
                    default:
                        break;
                }
            }
        }
    }
}
