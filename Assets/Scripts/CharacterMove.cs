using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
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

    public void Attack()
    {
        
    }

    public void Move() //vecは向きのベクトル
    {
        transform.position += new Vector3(Vec.x * moveSpeed, Vec.y * moveSpeed);
    }

    private void FixedUpdate()
    {
        Move();
    }
}