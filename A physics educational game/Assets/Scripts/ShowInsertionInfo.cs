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

    private void Start()
    {
        infoText.text = info;
        insertionCanvas.SetActive(true);
        control.enabled = false;
        control.ResetAnimations();
        if (shouldEnableControl)
            StartCoroutine(AwaitInsertion());
        else
        {
            insertionCanvas.SetActive(false);
            Destroy(gameObject);
        }
    }

    private IEnumerator AwaitInsertion()
    {
        yield return new WaitForSeconds(5f);
        control.enabled = true;
        insertionCanvas.SetActive(false);
        Destroy(gameObject);
    }

}
