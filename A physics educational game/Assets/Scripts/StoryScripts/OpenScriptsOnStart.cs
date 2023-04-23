using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScriptsOnStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> nextScripts;

    [SerializeField] private bool shouldDelete = true;

    private void Start()
    {
        foreach (var obj in nextScripts)
        {
            obj.SetActive(true);
        }
        if (shouldDelete) Destroy(gameObject);
    }
}
