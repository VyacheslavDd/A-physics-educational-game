using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNextScripts : MonoBehaviour
{
    [SerializeField] private GameObject nextScript;
    [SerializeField] private GameObject objToEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objToEnter)
        {
            nextScript.SetActive(true);
            Destroy(gameObject);
        }
    }
}
