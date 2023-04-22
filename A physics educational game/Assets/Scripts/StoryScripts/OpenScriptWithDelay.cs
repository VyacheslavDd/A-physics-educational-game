using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScriptWithDelay : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private GameObject nextScript;

    private void Start()
    {
        StartCoroutine(DoDelay());
    }

    private IEnumerator DoDelay()
    {
        yield return new WaitForSeconds(delay);
        nextScript.SetActive(true);
        Destroy(gameObject);
    }
}
