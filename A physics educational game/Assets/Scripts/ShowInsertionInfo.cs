using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInsertionInfo : MonoBehaviour
{
    [SerializeField] private GameObject insertionCanvas;
    [SerializeField] private TextMeshProUGUI infoText;

    [SerializeField] private string info;

    [SerializeField] private bool shouldEnableControl;

    [SerializeField] private PlayerControl control;

    [SerializeField] private GameObject nextScript;

    private void Start()
    {
        infoText.text = info;
        insertionCanvas.SetActive(true);
        control.enabled = false;
        control.ResetAnimations();
        StartCoroutine(AwaitInsertion());
    }

    private IEnumerator AwaitInsertion()
    {
        yield return new WaitForSeconds(5f);
        if (shouldEnableControl) control.enabled = true;
        insertionCanvas.SetActive(false);
        if (nextScript != null) nextScript.SetActive(true);
        Destroy(gameObject);
    }

}
