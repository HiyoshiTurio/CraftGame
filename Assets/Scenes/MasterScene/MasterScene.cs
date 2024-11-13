using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterSceneScript : MonoBehaviour
{
    //MasterSceneで管理されているこのSceneManagerを使いゲームシーンを遷移する。
    public static MasterSceneScript Instance;
    private Scene _openingScene;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
           SceneManager.LoadScene(1, LoadSceneMode.Additive);
           _openingScene = SceneManager.GetSceneAt(1);
        }
        else
        {
            _openingScene = SceneManager.GetActiveScene();
            Debug.Log(_openingScene);
        }
    }

    public void SceneMove(Scene loadScene)
    {
        SceneManager.UnloadSceneAsync(_openingScene);
        SceneManager.LoadScene(loadScene.name, LoadSceneMode.Additive);
        _openingScene = loadScene;
    }
}