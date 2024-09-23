using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class ItemData//アイテムのデータクラス
{
    public ItemType itemType; //アイテムの種類
    public Sprite icon; //アイテムのアイコン
}
[Serializable]
public class CraftRecipe //アイテムをクラフトする際に必要な素材のデータクラス
{
    public ItemType CraftItem; //クラフト結果のアイテム
    public List<ItemType> RequiredItems; //クラフトに必要な素材のリスト
}

public enum ItemType
{ 
    Ax,
    Sword,
    Wood,
    Stone,
    Iron,
    Coal,
    Gold,
    Diamond,
}
