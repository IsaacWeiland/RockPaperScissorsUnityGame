using System;
using UnityEngine;

namespace RPS_Usage
{
    public class Rock : MouseScriptBase
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
                rend.material.color = Color.black;
            }
        }
    }
}
