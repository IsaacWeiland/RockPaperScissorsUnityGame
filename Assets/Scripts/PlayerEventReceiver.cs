using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerEventReceiver : MonoBehaviour
{
    public MouseScriptBase iconLink;
    [SerializeField] private GameLogic logic;
    
    void Start()
    {
        iconLink.PlayerInput += MouseOnPlayerInput;
    }

    private void MouseOnPlayerInput(object sender, MouseScriptBase.PlayersChoice e)
    {
        logic.Run(e.Send, e.Name);
    }

}
