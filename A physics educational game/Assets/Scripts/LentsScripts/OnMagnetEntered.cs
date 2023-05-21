using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMagnetEntered : MonoBehaviour
{
    private bool entered = false;

    private float remainedRotation = 0;

    [SerializeField] private float yRotationPush;

    [SerializeField] private float timeRotation;
    [SerializeField] private float yRotationValuePerTime;

    [SerializeField] private MagnetController controller;

    [SerializeField] private GameObject nextScript;

    [SerializeField] private int counterInteraction;

    [SerializeField] private bool doBackwards = false;

    [SerializeField] private OnMagnetEntered neighbour;

    [SerializeField] private GameObject arrowRight;
    [SerializeField] private GameObject arrowLeft;

    private int counter = 0;

    private void Start()
    {
        controller.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.GetComponent<MagnetController>() != null && remainedRotation <= 0 && !controller.IsHeld && !doBackwards
            && (neighbour == null || neighbour.GetRemainedRotation() <= 0))
        {
            DoPushing();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.GetComponent<MagnetController>() != null && remainedRotation <= 0 && !controller.IsHeld && doBackwards
            && neighbour.GetRemainedRotation() <= 0)
        {
            DoPushing();
        }
    }

    private void DoPushing()
    {
        //if (transform.parent.eulerAngles.y > 0 && transform.parent.eulerAngles.y <= 180 && yRotationPush < 0) if (!doBackwards) yRotationPush *= -1;
        //if (transform.parent.eulerAngles.y <= 0 && transform.parent.eulerAngles.y > -180 && yRotationPush > 0) if (!doBackwards) yRotationPush *= -1;
        counter += 1;
        remainedRotation += Math.Abs(yRotationPush);
        if (!entered) StartCoroutine(Push());
        entered = true;
        SetArrowDestination();
    }

    private IEnumerator Push()
    {
        while (true)
        {
            if (Math.Abs(transform.parent.eulerAngles.y) - 90 <= 1f && Math.Abs(transform.parent.eulerAngles.y) - 90 >= 0)
            {
                remainedRotation += 3f;
            }
            if (remainedRotation > 0)
            {
                //if (controller.enabled && !doBackwards) controller.enabled = false;
                transform.parent.Rotate(new Vector3(0, yRotationPush > 0 ? yRotationValuePerTime : -yRotationValuePerTime, 0));
                remainedRotation -= yRotationValuePerTime;
            }
            else
            {
                remainedRotation = 0;
                //if (!controller.enabled) controller.enabled = true;
            }
            yield return new WaitForSeconds(timeRotation);
            if (counter == counterInteraction)
            {
                yield return new WaitForSeconds(1.5f);
                controller.enabled = true;
                nextScript.SetActive(true);
            }
        }
    }

    private void SetArrowDestination()
    {
        arrowRight.SetActive(yRotationPush > 0 ? true : false);
        arrowLeft.SetActive(yRotationPush < 0 ? true : false);
    }

    public void ForcePush()
    {
        counter = counterInteraction + 1;
        remainedRotation = 0;
        StartCoroutine(Push());
    }

    public float GetRemainedRotation()
    {
        return remainedRotation;
    }
}
