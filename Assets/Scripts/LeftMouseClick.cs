using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftMouseClick : MonoBehaviour
{
    private MouseControls _leftClick;
    public event EventHandler OnLeftClick;
    void Start()
    {
        _leftClick = new MouseControls();
        _leftClick.UseMouse.Enable();
        _leftClick.UseMouse.LeftClick.performed += LeftClick_OnPerformed;
    }

    private void LeftClick_OnPerformed(InputAction.CallbackContext obj)
    {
        OnLeftClick?.Invoke(this,EventArgs.Empty);
    }
}
