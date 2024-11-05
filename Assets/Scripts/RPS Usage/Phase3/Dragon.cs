using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MouseScriptBase
{
    void Start()
    {
        controls.OnLeftClick += Controls_OnLeftClick;
        rend = GetComponent<Renderer>();

    }

    private void Controls_OnLeftClick(object sender, EventArgs e)
    {
        
        if (ReturnMouse && Instance == this)
        {
            RunInputEvent(iconListSO, iconSO);
            rend.material.color = Color.blue;
        }
    }
}
