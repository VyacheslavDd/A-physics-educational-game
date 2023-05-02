using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScriptsWhenCalled : MonoBehaviour
{
    [SerializeField] private List<GameObject> scripts;

    public void DoLoading()
    {
        foreach (var script in scripts)
        {
            script.SetActive(true);
        }
    }
}
