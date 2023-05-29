using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTimePassed : MonoBehaviour
{
    [SerializeField] private LightZoneControl lightControl;
    [SerializeField] private float timeForExperiment;

    [SerializeField] private GameObject nextScript;

    private void Update()
    {
        if (lightControl.GetTimeInZone() >= timeForExperiment)
        {
            nextScript.SetActive(true);
            enabled = false;
        }
    }
}
