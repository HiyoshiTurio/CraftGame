using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected InGameManager InGameManager;
    protected float MoveSpeed = 0.5f;
    protected bool IsAttackable = true;
    protected float AttackCoolTime = 6.0f;
    private float _timer = 0.0f;
    private Vector2 _vec;

    protected Vector2 Vec
    {
        get { return _vec; }
        set
        {
            _vec = value;
            _vec.Normalize();
        }
    }


    protected virtual void Attack()
    {
        
    }

    public virtual void DamageAction(int damage)
    {
        
    }

    private void Move() //vecは向きのベクトル
    {
        transform.position += new Vector3(Vec.x * MoveSpeed, Vec.y * MoveSpeed);
    }

    private void Start()
    {
        InGameManager = InGameManager.Instance;
    }

    private void FixedUpdate()
    {
        Move();
        if (!IsAttackable)
        {
            _timer += 0.1f;
            if (_timer >= AttackCoolTime)
            {
                IsAttackable = true;
                _timer = 0.0f;
            }
        }
    }
}