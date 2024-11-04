using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystemScript : MonoBehaviour
{
    public GameLogic fromLogic;
    private int _playerLivesCurrent;
    private const int PlayerLivesMin = 0;
    private int _enemyLivesCurrent;
    private const int EnemyLivesMin = 0;
    public event EventHandler<LifeCount> UpdateEnemyLives;
    public event EventHandler<LifeCount> UpdatePlayerLives;
    public event EventHandler AdvanceGame;

    public class LifeCount : EventArgs
    {
        public int PlayerLife;
        public int EnemyLife;
    }

    private void Start()
    {
        fromLogic.GetComponent<GameLogic>();
        _playerLivesCurrent = PlayerLivesMin;
        _enemyLivesCurrent = EnemyLivesMin;
        fromLogic.UpdateLives += FromLogic_OnUpdateLives;
    }

    private void Update()
    {
        if (_playerLivesCurrent >= 3)
        {
            Debug.Log("Your Loser");
        }

        if (_enemyLivesCurrent >= 3)
        {
            Debug.Log("Phase 1 complete");
            AdvanceGame?.Invoke(this,EventArgs.Empty);
        }
        
    }

    private void FromLogic_OnUpdateLives(object sender, GameLogic.LifeClass e)
    {
        Debug.Log("Life system updating");
        if (e.HitEnemy)
        {
            Debug.Log("Its a hit");
            UpdateEnemyLives?.Invoke(this, new LifeCount
            {
                PlayerLife = _playerLivesCurrent,
                EnemyLife = _enemyLivesCurrent
            });
            _enemyLivesCurrent += 1;
        }
        else
        {
            Debug.Log("Youre hit");
            UpdatePlayerLives?.Invoke(this,new LifeCount
            {
                PlayerLife = _playerLivesCurrent,
                EnemyLife = _enemyLivesCurrent
            });
            _playerLivesCurrent += 1;
        }
    }
}
