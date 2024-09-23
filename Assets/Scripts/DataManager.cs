using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private IconData iconData;
    static DataManager instance;
    public IconData IconData { get { return iconData; } }
    public static DataManager Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)instance = this;
        else Destroy(gameObject);
    }
}
