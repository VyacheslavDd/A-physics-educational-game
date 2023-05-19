using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMagnetEntered : MonoBehaviour
{
    private bool entered = false;

    private float remainedRotation = 0;

    [SerializeField] private float yFinalDestination;
    [SerializeField] private float yRotationPush;

    [SerializeField] private float timeRotation;
    [SerializeField] private float yRotationValuePerTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.GetComponent<MagnetController>() != null)
        {
            remainedRotation += yRotationPush;
            if (!entered) StartCoroutine(Push());
            entered = true;
        }
    }

    private IEnumerator Push()
    {
        while (transform.parent.eulerAngles.y <= yFinalDestination)
        {
            if (remainedRotation > 0)
            {
                transform.parent.Rotate(new Vector3(0, yRotationValuePerTime, 0));
                remainedRotation -= yRotationValuePerTime;
            }
            yield return new WaitForSeconds(timeRotation);
        }
    }
}
