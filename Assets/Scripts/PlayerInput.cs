using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterBase
{
    [SerializeField] private PlayerStateData playerStateData;
    InGameManager _inGameManager;

    private void Awake()
    {
        _inGameManager = InGameManager.Instance;
        _inGameManager.AddCharacterTransforms(this.transform);
        _inGameManager.playerTransform = this.transform;
        MoveSpeed = playerStateData.moveSpeed;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vec = new Vector2(h, v);
        if (Input.GetButtonDown("Fire1") && IsAttackable)
        {
            Attack();
            IsAttackable = false;
        }
    }

    protected override void Attack()
    {
        _inGameManager.CheckHitAttack(transform, 1);
    }
}
