using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    private bool _isDeiplayedDebugMenu = false;
    [SerializeField] private GameObject _debugMenu;

    private void Start()
    {
        ClickDebugMenuButton();
    }

    public void ClickDebugMenuButton()
    {
        if (!_isDeiplayedDebugMenu)
        {
            RectTransform rectTransform = _debugMenu.GetComponent<RectTransform>();
            rectTransform.position = new Vector3(rectTransform.rect.width / 2, Screen.height / 2, 0);
        }
        else
        {
            RectTransform rectTransform = _debugMenu.GetComponent<RectTransform>();
            rectTransform.position = new Vector3(- rectTransform.rect.width / 2, Screen.height / 2, 0);
        }
        _isDeiplayedDebugMenu = !_isDeiplayedDebugMenu;
    }
}
