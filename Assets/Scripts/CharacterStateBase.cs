using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class CharacterStateBase : MonoBehaviour
{
    private int _hp;
    private int _maxHp;
    private int _atk;
    private int _speed;

    public int HP
    {
        get { return _hp; }
        set
        {
            if (value > _maxHp)
            {
                _hp = _maxHp;
            }
            else
            {
                _hp = value;
            }

            OnUpdateHp?.Invoke(_hp);
        }
    }

    public int Atk
    {
        get { return _atk; }
        set { _atk = value; }
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public event Action<int> OnUpdateHp;
}