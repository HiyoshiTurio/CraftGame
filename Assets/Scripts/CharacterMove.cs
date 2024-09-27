using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    private Vector2 _vec;
    [SerializeField] GameObject enemy;

    protected Vector2 Vec
    {
        get { return _vec; }
        set
        {
            _vec = value;
            _vec.Normalize();
        }
    }

    protected void Attack(Vector2 direction)
    {
        Vector2 enemyPos = enemy.transform.position;
        float range = 1; //攻撃範囲
        float angleRange = 60; //
        if (this.gameObject.transform.position.x - enemyPos.x * this.gameObject.transform.position.x - enemyPos.x +
            this.gameObject.transform.position.y - enemyPos.y * this.gameObject.transform.position.y - enemyPos.y <=
            range * range)
        {
            float dot = Vector2.Dot(direction.normalized, transform.position);
            Debug.Log($"dot:{dot} {Mathf.Acos(angleRange)}");
            if (dot > Mathf.Cos(angleRange))
            {
                Debug.Log("Hit");
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }

    private void Move() //vecは向きのベクトル
    {
        transform.position += new Vector3(Vec.x * moveSpeed, Vec.y * moveSpeed);
    }

    private void FixedUpdate()
    {
        Move();
    }
}