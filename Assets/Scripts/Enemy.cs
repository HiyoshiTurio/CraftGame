using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterMove
{
    [SerializeField] private EnemyState enemyState;
}
[Serializable]
public class EnemyState
{
    public string enemyName;
    public int Hp;
    public int Atk;
    public Resource[] dropItem;
}
