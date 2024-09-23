using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIconBase : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public void SetItemID(ItemType itemType)
    {
        int itemID = (int)itemType;
        GetComponent<Image>().sprite = DataManager.Instance.IconData.itemDatas[itemID].icon;
    }
    public void OnPointerEnter(PointerEventData eventData){} //カーソルがアイコン内に入ったとき{ }
    public void OnPointerExit(PointerEventData eventData){} //カーソルがアイコンから出たとき{ }
}
