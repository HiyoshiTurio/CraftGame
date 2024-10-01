using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : CharacterMove
{
    private Camera _camera;
    [SerializeField] GameObject _enemy;
    InGameManager _inGameManager;

    private void Start()
    {
        _camera = Camera.main;
        _inGameManager = InGameManager.Instance;
        _inGameManager.playerTransform = transform;
        InGameManager.Instance.AddCharacterTransforms(this.transform);
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vec = new Vector2(h, v);
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        _inGameManager.CheckHitAttack(transform, 1);
    }
}
