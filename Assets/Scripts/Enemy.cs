using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterMove
{
    [SerializeField] private TestEnemyData enemyData;
    [SerializeField] private float findPlayerRange = 5f;
    [SerializeField] private float findPlayerRangeMinValue = 1f;
    [SerializeField] private float attackRange = 2f;
    private Transform _player;
    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (CheckPlayerInFindRange())
        {
            transform.up = _player.transform.position - transform.position;
            Vector3 tmp = _player.transform.position - transform.position;
            Vec = tmp;
        }
        else
        {
            Vec = Vector3.zero;
        }
    }

    bool CheckPlayerInFindRange()
    {
        float X = transform.position.x - _player.transform.position.x;
        float Y = transform.position.y - _player.transform.position.y;
        if (X * X + Y * Y < findPlayerRange * findPlayerRange &&
            X * X + Y * Y > findPlayerRangeMinValue * findPlayerRangeMinValue) return true;
        return false;
    }

    void InAttackRange()
    {
        //Attack();
    }
}
[Serializable]
public class EnemyState
{
    public string enemyName;
    public int Hp;
    public int Atk;
    public List<ItemType> dropItemList;
}
