using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButtonBase : MonoBehaviour
{
    public ItemType craftItemType;

    public void ClickCraftItemButton()
    {
        Debug.Log(PlayerDataController.Instance.CraftItem(craftItemType));
    }
}
