using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCount : MonoBehaviour
{
    public static int SceneLoadCount { get; private set; }
    private static SceneCount instance;

    private bool lost = false; // resets counter



    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        SceneLoadCount = -1;
        SceneManager.sceneLoaded += IncrementSceneLoad;
 
    }


    private void Update()
    {
        Debug.Log(SceneLoadCount);
    }


    private void IncrementSceneLoad(Scene scene, LoadSceneMode mode)
    {

        SceneLoadCount++;

    }
}
