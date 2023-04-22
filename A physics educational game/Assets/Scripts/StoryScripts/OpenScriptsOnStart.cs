using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScriptsOnStart : MonoBehaviour
{
    [SerializeField] private GameObject nextScript;

    private void Start()
    {
        nextScript.SetActive(true);
        Destroy(gameObject);
    }
}
