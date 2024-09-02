using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterMove
{
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vec = new Vector2(h, v);
    }
}
