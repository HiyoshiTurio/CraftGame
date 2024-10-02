using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestEnemyData")]
public class TestEnemyData : ScriptableObject
{
    public string enemyName;
    public int Hp;
    public int Atk;
    public List<ItemType> dropItemList;
}