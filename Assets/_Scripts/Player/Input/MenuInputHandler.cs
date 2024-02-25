using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputHandler : MonoBehaviour
{
    public event Action MoveUpRequest;
    public event Action MoveDownRequest;
    public event Action MoveRightRequest;
    public event Action MoveLeftRequest;

    public Vector2 RawMovementInput { get; private set; }

    public void OnMoveUpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            MoveUpRequest.Invoke();
        }  
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
        
            RawMovementInput = context.ReadValue<Vector2>();

            int NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            int NormInputY = Mathf.RoundToInt(RawMovementInput.y);

            if (NormInputX < 0)
            {
                MoveLeftRequest.Invoke();
            }
            else if (NormInputX > 0)
            {
                MoveRightRequest.Invoke();
            }

            if (NormInputY < 0)
            {
                MoveDownRequest.Invoke();
            }
            else if (NormInputY > 0)
            {
                MoveUpRequest.Invoke();
            }
        }
    }
}

