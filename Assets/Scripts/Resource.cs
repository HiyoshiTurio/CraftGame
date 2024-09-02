using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Resource
{
    public ItemType itemType;
    public int resourceCount;
}

public class CraftingData
{
    public List<ItemType> AxCraftData = new List<ItemType>() { ItemType.Stone, ItemType.Stone, ItemType.Wood };
    public List<ItemType> Sword = new List<ItemType>() { ItemType.Iron, ItemType.Iron, ItemType.Wood, ItemType.Wood };
}

public enum ItemType
{ 
    Ax,
    Sword,
    Wood,
    Stone,
    Iron,
}
