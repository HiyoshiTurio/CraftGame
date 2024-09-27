using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInput : CharacterMove
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vec = new Vector2(h, v);
        if (Input.GetButtonDown("Fire1"))
        {
            Attack((_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position));
        }
    }
}
