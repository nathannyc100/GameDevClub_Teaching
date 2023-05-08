using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event EventHandler OnCameraChanged;
    public Vector2 velocity;

    public void OnChangeCamera(InputAction.CallbackContext ctx){
        if (ctx.phase == InputActionPhase.Performed){
            OnCameraChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnWASD(InputAction.CallbackContext ctx){
        velocity = ctx.ReadValue<Vector2>();
    }
}
