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

    private Transform Player
    {
        get { return InGameManager.Instance.playerTransform; }
    }

    public int enemyHP
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
    }

    private void Start()
    {
        InGameManager.Instance.AddCharacterTransforms(this.transform);
    }

    private void Update()
    {
        if (CheckPlayerInFindRange())
        {
            transform.up = Player.transform.position - transform.position;
            Vector3 tmp = Player.transform.position - transform.position;
            Vec = tmp;
        }
        else
        {
            Vec = Vector3.zero;
        }
    }

    bool CheckPlayerInFindRange()
    {
        float X = transform.position.x - Player.position.x;
        float Y = transform.position.y - Player.position.y;
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
<<<<<<< HEAD
        enemyHP -= damage;
=======
        Debug.Log($"Enemy Hit!");
        EnemyHp -= damage;
>>>>>>> 7048c80cb5966b640f297e0c05fd0b34828b1940
    }
}
