using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemIconBase : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text detailText;
    [SerializeField] private GameObject detailPanel;

    public void SetItemID(ItemType itemType)
    {
        int itemID = (int)itemType;
        GetComponent<Image>().sprite = DataManager.Instance.IconData.itemDatas[itemID].icon;
        detailText.text = DataManager.Instance.IconData.itemDatas[itemID].itemType.ToString();
        detailPanel.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        detailPanel.gameObject.SetActive(true);
    } //カーソルがアイコン内に入ったとき{ }

    public void OnPointerExit(PointerEventData eventData)
    {
        detailPanel.gameObject.SetActive(false);
    } //カーソルがアイコンから出たとき{ }
}
