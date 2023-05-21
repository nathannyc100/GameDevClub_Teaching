using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event EventHandler OnCameraChanged;
    public event EventHandler OnFired;
    public event EventHandler FireToggle;
    public event EventHandler AimToggle;
    public Vector2 velocity;

    public void OnChangeCamera(InputAction.CallbackContext ctx){
        if (ctx.phase == InputActionPhase.Performed){
            OnCameraChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnWASD(InputAction.CallbackContext ctx){
        velocity = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx){
        if (ctx.phase == InputActionPhase.Performed){
            OnFired?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnFireToggle(InputAction.CallbackContext ctx){
        if (ctx.phase == InputActionPhase.Performed){
            FireToggle?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnAimToggle(InputAction.CallbackContext ctx){
        if (ctx.phase== InputActionPhase.Performed){
            AimToggle?.Invoke(this, EventArgs.Empty);  
        }
    }
}
