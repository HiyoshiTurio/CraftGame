using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-101)]
public class DebugPlayerDataText : MonoBehaviour
{
    [SerializeField] private Text debugText;

    private void Awake()
    {
        //PlayerDataController.Instance.OnUpdateResource += UpdateDebugText;
    }

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
        PlayerDataController.Instance.AddResource(ItemType.Wood,num);
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
        Resource[] obj = PlayerDataController.Instance.testPlayerData.testPlayerResourceData;
        foreach (var data in obj)
        {
            PlayerDataController.Instance.AddResource(data.itemType,data.resourceCount);
        }
    }
}