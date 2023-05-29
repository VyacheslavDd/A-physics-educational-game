using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MandrelController : MonoBehaviour
{
    private RectTransform rectTransform;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Image lamp;

    public bool InChangeLightZone;
    public bool CanMoveUp;
    public bool CanMoveDown;

    private float initialYPosition;

    private void ChangePosition(float yMove)
    {
        rectTransform.localPosition += new Vector3(0, yMove, 0);
    }

    private void ChangeLight()
    {
        if (InChangeLightZone)
        {
            var delta = Math.Abs(rectTransform.localPosition.y - initialYPosition);
            if (delta < 0) delta = 0;
            if (delta > 255) delta = 255;
            lamp.color = new Color32(255, 255, (byte)delta, 255);
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialYPosition = rectTransform.localPosition.y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && CanMoveDown)
        {
            ChangePosition(-moveSpeed);
            ChangeLight();
        }

        if (Input.GetKey(KeyCode.W) && CanMoveUp)
        {
            ChangePosition(moveSpeed);
            ChangeLight();
        }
    }
}
