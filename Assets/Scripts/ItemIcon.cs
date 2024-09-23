using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] GameObject icon;

    private void Start()
    {
        foreach (var VARIABLE in Enum.GetValues(typeof(ItemType)))
        {
            InstanceIcon((ItemType)VARIABLE);
        }
    }

    GameObject InstanceIcon(ItemType itemType) 
    {
        GameObject newIcon = Instantiate(icon);
        newIcon.GetComponent<ItemIconBase>().SetItemID(itemType);
        return newIcon;
    } 
}
