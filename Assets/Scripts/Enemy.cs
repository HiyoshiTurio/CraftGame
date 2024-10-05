using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : CharacterBase
{
    [SerializeField] private TestEnemyData enemyData;
    [SerializeField] private float findPlayerRange = 5f;
    [SerializeField] private float findPlayerRangeMinValue = 1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private Text healthText;
    private Transform _player;

    public int EnemyHp
    {
        get { return enemyData.Hp; }
        set
        {
            enemyData.Hp = value;
            healthText.text = enemyData.Hp.ToString();
        }
    }
    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        InGameManager.Instance.AddCharacterTransforms(this.transform);
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
    public override void DamageAction(int damage)
    {
        Debug.Log($"Enemy Hit!");
        EnemyHp -= damage;
    }
}
