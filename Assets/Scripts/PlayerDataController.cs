using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-100)]
public class PlayerDataController : MonoBehaviour
{
    [SerializeField] public TestPlayerData testPlayerData; //デバッグ用データ
    private Dictionary<ItemType, int> _playerResourceData = new Dictionary<ItemType, int>();
    public string playerName;
    public static PlayerDataController Instance;
    public Dictionary<ItemType, int> PlayerResourceData { get => _playerResourceData; }

    public event Action<Dictionary<ItemType,int>> OnUpdateResource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        playerName = testPlayerData.testPlayerName;
    }

    public void AddResource(ItemType itemType, int num)
    {
        if (_playerResourceData.ContainsKey(itemType))
            _playerResourceData[itemType] += num;
        else
            _playerResourceData.Add(itemType, num);
        OnUpdateResource?.Invoke(_playerResourceData);
    }
}
