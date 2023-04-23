using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNextScripts : MonoBehaviour
{
    [SerializeField] private List<GameObject> nextScript;
    [SerializeField] private GameObject objToEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objToEnter)
        {
            foreach (var obj in nextScript)
            {
                obj.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
