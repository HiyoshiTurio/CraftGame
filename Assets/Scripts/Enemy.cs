using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : CharacterBase
{
    [SerializeField] private EnemyStateData enemyStateData;
    [SerializeField] private float findPlayerRange = 5f;
    [SerializeField] private float findPlayerRangeMinValue = 1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private Text healthText;

<<<<<<< HEAD
    private Transform Player => InGameManager.Instance.playerTransform; 
    

=======
    private Transform Player
    {
        get { return InGameManager.Instance.playerTransform; }
    }
>>>>>>> 9b7b78dc161f08198b3a38dc9a93c0752b0ae3eb
    public int EnemyHp
    {
        get { return enemyStateData.Hp; }
        set
        {
            enemyStateData.Hp = value;
            healthText.text = enemyStateData.Hp.ToString();
        }
    }

    private void Start()
    {
        InGameManager.Instance.AddCharacterTransforms(this.transform);
        MoveSpeed = enemyStateData.moveSpeed;
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
=======
        Debug.Log($"Enemy Hit!");
>>>>>>> 9b7b78dc161f08198b3a38dc9a93c0752b0ae3eb
        EnemyHp -= damage;
    }
}
