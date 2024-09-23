using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject parentObj;

    private void Start()
    {
        foreach (var VARIABLE in Enum.GetValues(typeof(ItemType)))
        {
            InstanceIcon((ItemType)VARIABLE);
        }
    }

    GameObject InstanceIcon(ItemType itemType) 
    {
        GameObject newIcon = Instantiate(icon, parentObj.transform);
        newIcon.GetComponent<ItemIconBase>().SetItemID(itemType);
        return newIcon;
    } 
}
