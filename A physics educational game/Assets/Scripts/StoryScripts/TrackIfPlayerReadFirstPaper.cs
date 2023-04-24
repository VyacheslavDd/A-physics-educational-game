using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackIfPlayerReadFirstPaper : MonoBehaviour
{
    [SerializeField] private GameObject theoryPage;
    [SerializeField] private GameObject nextScript;
    private bool beenOpened;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && theoryPage.activeSelf) beenOpened = true;
        if (beenOpened && !theoryPage.activeSelf)
        {
            nextScript.SetActive(true);
            Destroy(gameObject);
        }
    }
}
