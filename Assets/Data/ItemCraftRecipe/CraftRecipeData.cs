using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
[Serializable]
[CreateAssetMenu(menuName = "CraftRecipeData")]
public class CraftRecipeData : ScriptableObject
{
    [SerializeField]public List<CraftRecipe> CraftRecipeList;
}
