using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentBehaviour : MonoBehaviour
{
    private RectTransform rectTransform;
    private Image img;
    private System.Random random;

    [SerializeField] private Sprite left;
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private Slider health;

    [SerializeField] private GameObject successScript;

    private double yMove;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        random = new System.Random();
        yMove = minSpeed;
        img.sprite = up;
    }

    private void Update()
    {
        if (health.value <= 0)
        {
            successScript.SetActive(true);
            enabled = false;
        }

        rectTransform.localPosition += new Vector3(0, (float)yMove, 0);
    }

    public void ChangeDirection(int multiplier)
    {
        if (yMove > 0)
            img.sprite = down;
        else
            img.sprite = up;

        yMove = (minSpeed + random.NextDouble() * (maxSpeed - minSpeed)) * (multiplier);
    }
}
