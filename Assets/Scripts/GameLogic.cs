using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private EnemyListAttacks enemy;
    private IconListSO allAttacks;
    public LifeSystemScript lifeSystemScript;
    private int _currentEnemyAttackNumber;
    public event EventHandler<LifeClass> UpdateLives;
    
    public class LifeClass : EventArgs
    {
        public bool HitEnemy;
    }
    private void Start()
    {
        _currentEnemyAttackNumber = 3;
        lifeSystemScript.GetComponent<LifeSystemScript>();
        allAttacks = enemy.GetIconList();
        lifeSystemScript.AdvanceGame += LifeSystemScriptOnAdvanceGame;
    }

    private void LifeSystemScriptOnAdvanceGame(object sender, EventArgs e)
    {
        _currentEnemyAttackNumber = 9;
    }

    public void Run(IconListSO playerInput, IconSO iconName)
    {
        var enemyChoice = Enemy();
        if (iconName == enemyChoice)
        {
            Debug.Log("It's a tie!");
        }
        else if (ComparePlayerEnemy(playerInput, enemyChoice))
        {
            RunLifeEvent(true);
        }
        else
        {
            RunLifeEvent(false);
        }
    }

    private IconSO Enemy()
    {
        Random r = new Random();
        int random = r.Next(0, _currentEnemyAttackNumber);
        return allAttacks.IconSOList[random];
    }

    private bool ComparePlayerEnemy(IconListSO playerInput, IconSO enemyInput)
    {
        foreach (var iconSO in playerInput.IconSOList)
        {
            if (iconSO == enemyInput)
            {
                return true;
            }
        }
        return false;
    }

    private void RunLifeEvent(bool hitEnemy)
    {
        Debug.Log("Event Method running");
        UpdateLives?.Invoke(this, new LifeClass{ HitEnemy = hitEnemy});
    }
}
