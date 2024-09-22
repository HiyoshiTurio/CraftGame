using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButton : MonoBehaviour
{
    [SerializeField] GameObject debugPrefab;
    [SerializeField] GameObject parentObject;

    private void Start()
    {
        foreach (var value in Enum.GetValues(typeof(ItemType)))
        {
            GameObject obj = Instantiate(debugPrefab, parentObject.transform);
            obj.GetComponent<DebugButtonBase>().itemType = (ItemType)value;
        }
    }
}
