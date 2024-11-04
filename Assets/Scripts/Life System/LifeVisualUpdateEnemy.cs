using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LifeVisualUpdateEnemy : MonoBehaviour
{
    [SerializeField] private Image[] redX;
    public LifeSystemScript lifeSystemScript;
    void Start()
    {
        lifeSystemScript.GetComponent<LifeSystemScript>();
        lifeSystemScript.UpdateEnemyLives += LifeSystemScript_OnUpdateEnemyLives;
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


    private void LifeSystemScript_OnUpdateEnemyLives(object sender, LifeSystemScript.LifeCount e)
    {
        redX[e.EnemyLife].gameObject.SetActive(true);
    }

}
