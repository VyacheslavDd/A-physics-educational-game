using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoading : MonoBehaviour
{
    [SerializeField] private Loader sceneLoader;
    [SerializeField] private GameObject canvasToOff;
    [SerializeField] private string sceneName;

    public void StartLoadingScene()
    {
        sceneLoader.canvasToOff = canvasToOff;
        sceneLoader.LoadScene(sceneName);
    }
}
