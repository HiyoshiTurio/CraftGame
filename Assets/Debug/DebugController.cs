using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-101)]
public class DebugController : MonoBehaviour
{
    [SerializeField] private Text debugText;


    private void Start()
    {
        PlayerDataController.Instance.OnUpdateResource += UpdateDebugText;
        TestDataToPlayerData();
        UpdateDebugText(PlayerDataController.Instance.PlayerResourceData);
    }

    void UpdateDebugText(Dictionary<ItemType, int> playerData)
    {
        debugText.text = "";
        foreach (var data in playerData)
        {
            debugText.text += $"{data.Key} : {data.Value}\n";
        }
    }

    public void AddWood(int num)
    {
        PlayerDataController.Instance.AddItem(ItemType.Wood,num);
    }

    public void TestSwordCraft()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(ItemType.Sword));
    }

    public void TestWoodCraft()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(ItemType.Wood));
    }
    public void TestStoneCraft()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(ItemType.Stone));
    }
    
    public void TestIronCraft()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(ItemType.Iron));
    }


    void TestDataToPlayerData()
    {
        PlayerItemData[] obj = PlayerDataController.Instance.playerResourceData.testPlayerItemData;
        foreach (var data in obj)
        {
            PlayerDataController.Instance.AddItem(data.itemType,data.num);
        }
    }
}