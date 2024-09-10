using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerDataController : MonoBehaviour
{
    [SerializeField] public TestPlayerData testPlayerData; //デバッグ用データ
    [SerializeField] public CraftRecipeData craftRecipeData; //クラフト用データ
    private Dictionary<ItemType, int> _playerResourceData = new Dictionary<ItemType, int>();
    public string playerName;
    public static PlayerDataController Instance;

    public Dictionary<ItemType, int> PlayerResourceData
    {
        get => _playerResourceData;
    }

    public event Action<Dictionary<ItemType, int>> OnUpdateResource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        playerName = testPlayerData.testPlayerName;
        foreach (var variable in Enum.GetValues(typeof(ItemType)))
        {
            _playerResourceData.Add((ItemType)variable, 0);
        }
    }

    public void AddResource(ItemType itemType, int num)
    {
        if (_playerResourceData.ContainsKey(itemType))
            _playerResourceData[itemType] += num;
        else
            _playerResourceData.Add(itemType, num);
        OnUpdateResource?.Invoke(_playerResourceData);
    }
    public bool CraftItem(ItemType CraftItem)
    {
        if (CheckResourceForCraftingItem(CraftItem))
        {
            int i = craftRecipeData.CraftRecipe.FindIndex(x => x.CraftItem == CraftItem);
            _playerResourceData[CraftItem]++;
            foreach (var VARIABLE in craftRecipeData.CraftRecipe[i].RequiredResources)
            {
                _playerResourceData[VARIABLE]--;
            }
            return true;
        }
        return false;
    }

    public bool CheckResourceForCraftingItem(ItemType craftItem) //クラフト用のリソースチェック
    {
        int i = craftRecipeData.CraftRecipe.FindIndex(x => x.CraftItem == craftItem);
        if (i == -1) return false;

        if (craftRecipeData.CraftRecipe[i].CraftItem == craftItem)
        {
            Dictionary<ItemType, int> needResource = new Dictionary<ItemType, int>();
            foreach (var VARIABLE in craftRecipeData.CraftRecipe[i].RequiredResources)
            {
                if (needResource.ContainsKey(VARIABLE)) needResource[VARIABLE]++;
                else needResource.Add(VARIABLE, 1);
            }
            foreach (var VARIABLE in needResource)
            {
                if (_playerResourceData[VARIABLE.Key] < VARIABLE.Value) return false;
            }
            return true;
        }
        return false;
    }
}