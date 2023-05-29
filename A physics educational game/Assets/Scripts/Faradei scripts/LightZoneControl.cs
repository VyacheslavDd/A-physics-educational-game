using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZoneControl : MonoBehaviour
{
    [SerializeField] private MandrelController mandrelController;

    private float timePassedInZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.InChangeLightZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MandrelController>() != null)
        {
            mandrelController.InChangeLightZone = false;
        }
    }

    private void Update()
    {
        if (mandrelController.InChangeLightZone)
            timePassedInZone += Time.deltaTime;
    }

    public float GetTimeInZone()
    {
        return timePassedInZone;
    }
}
