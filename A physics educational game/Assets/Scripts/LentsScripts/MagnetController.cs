using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    public bool IsHeld { get; set; }
    public bool IsRotated { get; set; }

    private float startY;

    private RectTransform rectTransform;
    [SerializeField] private float moveSpeed = 5;

    [SerializeField] private Transform lentsApparatus;

    private bool canHold;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startY = rectTransform.eulerAngles.y;
    }

    private float CalculateAngleDependingOnLents()
    {
        var y = (startY - lentsApparatus.eulerAngles.y) + (IsRotated ? 180 : 0);
        if (Math.Abs(y) - 90 <= 1f && Math.Abs(y) - 90 >= 0) y += 2;
        return y;
    }

    private void Update()
    {
        rectTransform.localRotation = Quaternion.Euler(rectTransform.eulerAngles.x, CalculateAngleDependingOnLents(), rectTransform.eulerAngles.z);

        if (Input.GetKey(KeyCode.W))
        {
            rectTransform.localPosition += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rectTransform.localPosition += new Vector3(0, -moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rectTransform.localPosition += new Vector3(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rectTransform.localPosition += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.E) && canHold)
        {
            IsHeld = true;
        }
        if (!Input.GetKey(KeyCode.E))
        {
            IsHeld = false;
        }
    }

    public void EnablePossibilityToHold()
    {
        canHold = true;
    }
}
