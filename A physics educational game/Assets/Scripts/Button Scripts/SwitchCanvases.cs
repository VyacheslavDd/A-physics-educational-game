using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvases : MonoBehaviour
{
    [SerializeField] private GameObject canvasOff;
    [SerializeField] private GameObject canvasOn;

    public void Switch()
    {
        canvasOff.SetActive(false);
        canvasOn.SetActive(true);
    }
}
