using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "TestPlayerData")]
public class TestPlayerData : ScriptableObject
{
    public string testPlayerName;
    public Resource[] testPlayerResourceData;
}
