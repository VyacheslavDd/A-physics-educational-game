using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNotClosedCircleEnter : MonoBehaviour
{
    [SerializeField] private GameObject nextScript;
    [SerializeField] private MagnetController controller;

    private bool entered = false;

    private void Start()
    {
        controller.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.GetComponent<MagnetController>() != null && !entered)
        {
            entered = true;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        nextScript.SetActive(true);
    }
}
