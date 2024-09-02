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


    void TestDataToPlayerData()
    {
        Resource[] obj = PlayerDataController.Instance.testPlayerData.testPlayerResourceData;
        foreach (var data in obj)
        {
            //PlayerDataController.Instance.PlayerResourceData[data.itemType] += data.resourceCount;
            if (PlayerDataController.Instance.PlayerResourceData.ContainsKey(data.itemType))
                PlayerDataController.Instance.PlayerResourceData[data.itemType] += data.resourceCount;
            else
                PlayerDataController.Instance.PlayerResourceData.Add(data.itemType, data.resourceCount);
        }
    }
}