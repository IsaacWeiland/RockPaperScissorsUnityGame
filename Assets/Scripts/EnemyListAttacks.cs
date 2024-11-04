using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;

public class EnemyListAttacks : MonoBehaviour
{
    [SerializeField] private IconListSO listSo;
    [SerializeField] private GameLogic gameLogic;

    public IconListSO GetIconList()
    {
        return listSo;
    }
}
