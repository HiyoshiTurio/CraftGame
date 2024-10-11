using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerStateData")]
public class PlayerStateData : ScriptableObject
{
    public int hp;
    public int atk;
    public float moveSpeed;
}
