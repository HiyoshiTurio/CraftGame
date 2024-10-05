using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButtonBase : MonoBehaviour
{
    [SerializeField] GameObject craftItemIconPrefab;
    public ItemType craftItemType;

    private void Start()
    {
        craftItemIconPrefab.GetComponent<ItemIconBase>().SetItemID(craftItemType);
    }

    public void ClickCraftItemButton()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(craftItemType));
    }
}