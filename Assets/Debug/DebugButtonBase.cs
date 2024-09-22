using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButtonBase : MonoBehaviour
{
    public ItemType itemType;
    private Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<Text>();
        PlayerDataController.Instance.OnUpdateResource += UpdateDebugResourceText;
    }

    public void AddItem(int num)
    {
        PlayerDataController.Instance.AddItem(itemType, num);
    }

    public void UpdateDebugResourceText(Dictionary<ItemType, int> resourceData)
    {
        _text.text = $"{itemType.ToString()} : {resourceData[itemType].ToString("D3")}";
    }
}
