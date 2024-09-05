using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestPlayerData")]
public class TestPlayerData : ScriptableObject
{
    public string testPlayerName;
    [SerializeField] public Resource[] testPlayerResourceData;
}
