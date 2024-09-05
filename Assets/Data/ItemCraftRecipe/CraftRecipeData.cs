using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CraftRecipeData")]
public class CraftRecipeData : ScriptableObject
{
    [SerializeField]public List<CraftRecipe> CraftRecipe;
}
