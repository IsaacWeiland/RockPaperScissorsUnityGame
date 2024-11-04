using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseScriptBase : MonoBehaviour
{
    [SerializeField] protected Renderer rend;
    [SerializeField] protected LeftMouseClick controls;
    [SerializeField] protected IconSO iconSO;
    [SerializeField] protected IconListSO iconListSO;
    protected bool ReturnMouse = false;
    protected MouseScriptBase Instance;
    public event EventHandler<PlayersChoice> PlayerInput;
    public class PlayersChoice : EventArgs
    {
        public IconListSO Send;
        public IconSO Name;
    }
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
    
    private void OnMouseEnter()
    {
        rend.material.color = Color.yellow;
        ReturnMouse = true;
        Instance = this;
    }
    private void OnMouseExit()
    {
        rend.material.color = Color.white;
        ReturnMouse = false;
        Instance = null;
    }
    protected void RunInputEvent(IconListSO playerSelect, IconSO iconName)
    {
        PlayerInput?.Invoke(this, new PlayersChoice
        {
            Send = playerSelect,
            Name = iconName
        });
    }
}
