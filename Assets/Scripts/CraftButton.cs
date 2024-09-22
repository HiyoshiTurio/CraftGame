using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    [SerializeField] GameObject debugPrefab;
    [SerializeField] GameObject parentObject;

    void Start()
    {
        
        PlayerDataController playerDataController = PlayerDataController.Instance;
        Debug.Log(playerDataController.craftRecipeData.CraftRecipeList.Count);
        for (int i = 0; i < playerDataController.craftRecipeData.CraftRecipeList.Count; i++)
        {
            GameObject obj = Instantiate(debugPrefab, parentObject.transform);
            obj.GetComponent<CraftButtonBase>().craftItemType = playerDataController.craftRecipeData.CraftRecipeList[i].CraftItem;
            string textStr = "";
            
            Dictionary<ItemType, int> resourceDict = new Dictionary<ItemType, int>();
            foreach (var item in playerDataController.craftRecipeData.CraftRecipeList[i].RequiredResources)
            {
                if (resourceDict.ContainsKey(item)) resourceDict[item]++;
                else resourceDict.Add(item, 1);
            }

            foreach (var item in resourceDict)
            {
                textStr += "\n" + item.Key.ToString() + ": " + item.Value.ToString();
            }

            textStr += " => " + playerDataController.craftRecipeData.CraftRecipeList[i].CraftItem.ToString();
            obj.GetComponent<Text>().text = textStr;
        }
        // GameObject obj = Instantiate(debugPrefab, parentObject.transform);
        // obj.GetComponent<CraftButtonBase>().craftItemType = (ItemType)value;
        // obj.GetComponent<Text>().text = ((ItemType)value).ToString();
    }
}
