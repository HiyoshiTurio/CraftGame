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
[Serializable]
public class CraftRecipe
{
    public ItemType CraftItem;
    public List<ItemType> RequiredResources;
}

public enum ItemType
{ 
    Ax,
    Sword,
    Wood,
    Stone,
    Iron,
}
