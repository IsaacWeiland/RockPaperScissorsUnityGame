using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeVisualUpdatePlayer : MonoBehaviour
{
    [SerializeField] private Image[] redX;
    public LifeSystemScript lifeSystemScript;
    void Start()
    {
        lifeSystemScript.GetComponent<LifeSystemScript>();
        lifeSystemScript.UpdatePlayerLives += LifeSystemScript_OnUpdatePlayerLives;
        lifeSystemScript.AdvanceGame += LifeSystemScript_OnAdvanceGame;
        foreach (var image in redX)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void LifeSystemScript_OnAdvanceGame(object sender, EventArgs e)
    {
        foreach (var image in redX)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void LifeSystemScript_OnUpdatePlayerLives(object sender, LifeSystemScript.LifeCount e)
    {
        redX[e.PlayerLife].gameObject.SetActive(true);
    }

}
