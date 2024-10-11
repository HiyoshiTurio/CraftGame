using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create EnemyStateData")]
public class EnemyStateData : ScriptableObject
{
    public string enemyName;
    public int Hp;
    public int Atk;
    public float moveSpeed;
    public List<ItemType> dropItemList;
}