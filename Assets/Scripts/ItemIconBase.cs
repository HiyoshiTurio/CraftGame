using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIconBase : MonoBehaviour
{
    public int itemID;

    public void SetItemID(ItemType itemType)
    {
        itemID = (int)itemType;
        GetComponent<SpriteRenderer>().sprite = DataManager.Instance.IconData.itemDatas[itemID].icon;
    }
}
