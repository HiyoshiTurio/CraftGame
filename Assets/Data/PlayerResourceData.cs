using UnityEngine;

[CreateAssetMenu(menuName = "TestPlayerData")]
public class PlayerResourceData : ScriptableObject
{
    [SerializeField] public PlayerItemData[] testPlayerItemData;
}
