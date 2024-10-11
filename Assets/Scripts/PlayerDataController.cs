using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerDataController : MonoBehaviour
{
    [SerializeField] public PlayerResourceData playerResourceData; //プレイヤー所持アイテムデータ
    [SerializeField] public CraftRecipeData craftRecipeData; //クラフト用データ
    private Dictionary<ItemType, int> _playerResource = new Dictionary<ItemType, int>();
    public string playerName;
    public static PlayerDataController Instance;

    public Dictionary<ItemType, int> PlayerResourceData
    {
        get => _playerResource;
    }

    public event Action<Dictionary<ItemType, int>> OnUpdateResource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var variable in Enum.GetValues(typeof(ItemType)))
        {
            if (!_playerResource.ContainsKey((ItemType)variable))
                _playerResource.Add((ItemType)variable, 0);
        }
    }

    public void AddItem(ItemType itemType, int num)
    {
        _playerResource[itemType] += num;
        OnUpdateResource?.Invoke(_playerResource);
    }

    public bool CraftItem(ItemType CraftItem) //アイテムクラフトメソッド
    {
        if (CheckResourceForCraftingItem(CraftItem))
        {
            int i = craftRecipeData.CraftRecipeList.FindIndex(x => x.CraftItem == CraftItem);
            _playerResource[CraftItem]++;
            foreach (var VARIABLE in craftRecipeData.CraftRecipeList[i].RequiredItems)
            {
                _playerResource[VARIABLE]--;
            }
            OnUpdateResource?.Invoke(_playerResource);
            return true;
        }
        return false;
    }

    public bool CheckResourceForCraftingItem(ItemType craftItem) //クラフト用のリソースチェック
    {
        int i = craftRecipeData.CraftRecipeList.FindIndex(x => x.CraftItem == craftItem); 
        if (i == -1) return false;　//対象のアイテムのレシピがなかった場合Falseを返す

        if (craftRecipeData.CraftRecipeList[i].CraftItem == craftItem)
        {
            Dictionary<ItemType, int> needResource = new Dictionary<ItemType, int>();
            foreach (var VARIABLE in craftRecipeData.CraftRecipeList[i].RequiredItems)
            {
                if (needResource.ContainsKey(VARIABLE)) needResource[VARIABLE]++;
                else needResource.Add(VARIABLE, 1);
            }

            foreach (var VARIABLE in needResource)
            {
                if (_playerResource[VARIABLE.Key] < VARIABLE.Value) return false;
            }

            return true;
        }

        return false;
    }
}
[Serializable]
public class PlayerItemData //プレイヤー所持アイテムデータ
{
    public ItemType itemType;
    public int num;
}