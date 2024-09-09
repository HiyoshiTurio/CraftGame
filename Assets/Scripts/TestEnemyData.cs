using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestEnemyData")]
public class TestEnemyData : ScriptableObject
{
    [SerializeField] public EnemyState enemyState;
}
